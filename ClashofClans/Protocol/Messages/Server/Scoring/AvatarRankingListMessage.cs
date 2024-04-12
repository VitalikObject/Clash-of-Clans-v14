using System;
using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server.Scoring
{
    public class AvatarRankingListMessage : PiranhaMessage
    {
        public AvatarRankingListMessage(Device device) : base(device)
        {
            Id = 26679;
        }
        private Player player { get; set; }
        public override void EncodeAsync()
        {
            Resources.Leaderboard.Update(null, null);
            var players = Resources.Leaderboard.GlobalPlayerRanking;
            var count = players.Count;

            Writer.WriteInt(count);

            for (int i = 0; i < count; i++)
            {
                player = players[i];

                player.AvatarRankingEntry(Writer, i + 1);
            }

            players = Resources.Leaderboard.GlobalPreviousSeasonPlayerRanking;
            count = players.Count;

            Writer.WriteInt(count);

            for (int i = 0; i < count; i++)
            {
                player = players[i];

                player.AvatarRankingEntry(Writer, i + 1, true);
            }

            Writer.WriteInt(TimeUtils.LeaderboardTimer);
            Writer.WriteInt(DateTime.Now.Year);
            Writer.WriteInt(DateTime.Now.Month);
            Writer.WriteInt(DateTime.Now.Year);
            Writer.WriteInt(DateTime.Now.Month - 1);
        }
    }
}
