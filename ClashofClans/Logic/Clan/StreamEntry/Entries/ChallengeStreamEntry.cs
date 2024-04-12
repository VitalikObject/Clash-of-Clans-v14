using ClashofClans.Utilities.Netty;
using Newtonsoft.Json;

namespace ClashofClans.Logic.Clan.StreamEntry.Entries
{
    public class ChallengeStreamEntry : AllianceStreamEntry
    {
        public ChallengeStreamEntry()
        {
            StreamEntryType = 10;
        }

        [JsonProperty("msg")] public string Message { get; set; }
        [JsonProperty("sender_score")] public int SenderScore { get; set; }
        [JsonProperty("arena")] public int Arena { get; set; }
        [JsonProperty("closed")] public bool Closed { get; set; }
        [JsonProperty("active")] public bool Active { get; set; }
        [JsonProperty("target_name")] public string TargetName { get; set; }

        [JsonIgnore] public int Spectators { get; set; }

        public override void Encode(ByteBuffer packet)
        {
            base.Encode(packet);

            // TODO
        }

        public void SetTarget(Player target)
        {
            TargetName = target.Home.Name;
        }

        public override void SetSender(Player player)
        {
            base.SetSender(player);

            SenderScore = player.Home.Trophies;
        }
    }
}