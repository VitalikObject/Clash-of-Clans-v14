using ClashofClans.Database;
using ClashofClans.Logic;
using ClashofClans.Logic.Clan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ClashofClans.Utilities;
using ClashofClans.Files;
using ClashofClans.Files.Logic;

namespace ClashofClans.Core.Leaderboard
{
    public class Leaderboard
    {
        private readonly System.Timers.Timer _timer = new System.Timers.Timer(20000);

        public List<Alliance> GlobalAllianceRanking = new List<Alliance>(200);
        public List<Player> LeagueMemberList = new List<Player>(200);
        public List<Player> GlobalPlayerRanking = new List<Player>(200);
        public List<Player> GlobalPreviousSeasonPlayerRanking = new List<Player>(200);
        public Dictionary<string, List<Player>> LocalPlayerRanking = new Dictionary<string, List<Player>>(18);

        public Leaderboard()
        {
            _timer.Elapsed += Update;
            _timer.Start();

            foreach (var regions in Csv.Tables.Get(Csv.Files.Regions).GetDatas())
                LocalPlayerRanking.Add(((Regions)regions).Name, new List<Player>(200));

            Update(null, null);
        }

        public async void UpdateLeagueMemberList(int league)
        {
            await Task.Run(async () =>
            {
                try
                {
                    var leagueMemberList = await PlayerDb.GetLeagueMemberListAsync(league);
                    for (var i = 0; i < leagueMemberList.Count; i++)
                        LeagueMemberList.UpdateOrInsert(i, leagueMemberList[i]);
                }
                catch (Exception exception)
                {
                    Logger.Log($"Error while updating leaderboads {exception}", GetType(), Logger.ErrorLevel.Error);
                }
            });
        }

        /// <summary>
        ///     Update all Leaderboards
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        public async void Update(object state, ElapsedEventArgs args)
        {
            await Task.Run(async () =>
            {
                try
                {
                    var currentGlobalPlayerRanking = await PlayerDb.GetGlobalPlayerRankingAsync();
                    for (var i = 0; i < currentGlobalPlayerRanking.Count; i++)
                        GlobalPlayerRanking.UpdateOrInsert(i, currentGlobalPlayerRanking[i]);

                    var previousGlobalPlayerRanking = await PlayerDb.GetPreviousSeasonGlobalPlayerRankingAsync();
                    for (var i = 0; i < previousGlobalPlayerRanking.Count; i++)
                        GlobalPreviousSeasonPlayerRanking.UpdateOrInsert(i, previousGlobalPlayerRanking[i]);

                    foreach (var (key, value) in LocalPlayerRanking)
                    {
                        var currentLocalPlayerRanking = await PlayerDb.GetLocalPlayerRankingAsync(key);
                        for (var i = 0; i < currentLocalPlayerRanking.Count; i++)
                            value.UpdateOrInsert(i, currentLocalPlayerRanking[i]);
                    }

                    var currentGlobalAllianceRanking = await AllianceDb.GetGlobalAlliancesAsync();
                    for (var i = 0; i < currentGlobalAllianceRanking.Count; i++)
                        GlobalAllianceRanking.UpdateOrInsert(i, currentGlobalAllianceRanking[i]);
                }
                catch (Exception exception)
                {
                    Logger.Log($"Error while updating leaderboads {exception}", GetType(), Logger.ErrorLevel.Error);
                }
            });
        }
    }
}
