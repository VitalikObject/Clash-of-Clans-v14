using ClashofClans.Logic;

namespace ClashofClans.Protocol.Messages.Server.Scoring
{
    public class AvatarLocalRankingListMessage : PiranhaMessage
    {
        public AvatarLocalRankingListMessage(Device device) : base(device)
        {
            Id = 21723;
        }
        private Player player { get; set; }
        public override void EncodeAsync()
        {
            Resources.Leaderboard.Update(null, null);
            var players = Resources.Leaderboard.LocalPlayerRanking[Device.Player.Home.PreferredDeviceLanguage];
            var count = players.Count;

            Writer.WriteInt(count);

            for (int i = 0; i < count; i++)
            {
                player = players[i];

                player.AvatarRankingEntry(Writer, i + 1);
            }
        }
    }
}
