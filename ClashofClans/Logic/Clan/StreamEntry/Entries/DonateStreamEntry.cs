using ClashofClans.Utilities.Netty;
using Newtonsoft.Json;

namespace ClashofClans.Logic.Clan.StreamEntry.Entries
{
    public class DonateStreamEntry : AllianceStreamEntry
    {
        public DonateStreamEntry()
        {
            StreamEntryType = 1;
        }

        [JsonProperty("msg")] public string Message { get; set; }
        [JsonProperty("totalCapacity")] public int TotalCapacity { get; set; }
        [JsonProperty("usedCapacity")] public int UsedCapacity { get; set; }

        public override void Encode(ByteBuffer packet)
        {
            base.Encode(packet);

            // TODO
        }
    }
}