using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server.Scoring
{
    public class AllianceRankingListMessage : PiranhaMessage
    {
        public AllianceRankingListMessage(Device device) : base(device)
        {
            Id = 24481;
        }
        private Logic.Clan.Alliance alliance { get; set; }
        public override void EncodeAsync()
        {
            int[] rewards = { 20000, 10000, 6000 };
            Resources.Leaderboard.Update(null, null);
            var alliances = Resources.Leaderboard.GlobalAllianceRanking;
            var count = alliances.Count;

            Writer.WriteInt(count);

            for (int i = 0; i < count; i++)
            {
                alliance = alliances[i];

                alliance.AllianceRankingEntry(Writer, i + 1);
            }

            Writer.WriteInt(TimeUtils.LeaderboardTimer);

            Writer.WriteInt(rewards.Length);
            foreach(int reward in rewards)
            {
                Writer.WriteInt(reward);
            }

            Writer.WriteInt(0);
        }
    }
}
