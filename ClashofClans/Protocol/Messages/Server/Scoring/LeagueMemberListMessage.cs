using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server.Scoring
{
    class LeagueMemberListMessage : PiranhaMessage
    {
        public LeagueMemberListMessage(Device device) : base(device)
        {
            Id = 23805;
        }
        private Player player { get; set; }
        public override void EncodeAsync()
        {
            Resources.Leaderboard.Update(null, null);
            var players = Resources.Leaderboard.LeagueMemberList;
            var count = players.Count;

            Writer.WriteInt(TimeUtils.LeaderboardTimer);
            Writer.WriteInt(count);

            for (int i = 0; i < count; i++)
            {
                player = players[i];

                player.LeagueMemberEntry(Writer, i + 1);
            }
        }
    }
}