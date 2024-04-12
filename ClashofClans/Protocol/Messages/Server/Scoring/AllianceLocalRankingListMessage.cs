using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server.Scoring
{
    public class AllianceLocalRankingListMessage : PiranhaMessage
    {
        public AllianceLocalRankingListMessage(Device device) : base(device)
        {
            Id = 20670;
        }
        private Logic.Clan.Alliance alliance { get; set; }
        public override void EncodeAsync()
        {
            Resources.Leaderboard.Update(null, null);
            var alliances = Resources.Leaderboard.GlobalAllianceRanking;
            var count = alliances.Count;

            Writer.WriteInt(count);

            for (int i = 0; i < count; i++)
            {
                alliance = alliances[i];

                alliance.AllianceRankingEntry(Writer, i + 1);
            }

            Writer.WriteInt(0);
        }
    }
}
