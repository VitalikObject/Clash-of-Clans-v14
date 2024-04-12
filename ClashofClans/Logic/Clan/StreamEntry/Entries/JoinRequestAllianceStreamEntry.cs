using ClashofClans.Utilities.Netty;
using Newtonsoft.Json;

namespace ClashofClans.Logic.Clan.StreamEntry.Entries
{
    public class JoinRequestAllianceStreamEntry : AllianceStreamEntry
    {
        public JoinRequestAllianceStreamEntry()
        {
            StreamEntryType = 3;
        }

        [JsonProperty("msg")] public string Message { get; set; }
        [JsonProperty("responder_name")] public string ResponderName { get; set; }
        [JsonProperty("state")] public int State { get; set; }

        public override void Encode(ByteBuffer packet)
        {
            base.Encode(packet);

            // TODO
        }

        public void SetTarget(Player target)
        {
            ResponderName = target.Home.Name;
        }
    }
}