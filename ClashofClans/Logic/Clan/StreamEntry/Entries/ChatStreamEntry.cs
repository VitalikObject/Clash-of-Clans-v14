using ClashofClans.Utilities.Netty;
using Newtonsoft.Json;

namespace ClashofClans.Logic.Clan.StreamEntry.Entries
{
    public class ChatStreamEntry : AllianceStreamEntry
    {
        public ChatStreamEntry()
        {
            StreamEntryType = 2;
        }

        [JsonProperty("msg")] public string Message { get; set; }

        public override void Encode(ByteBuffer packet)
        {
            base.Encode(packet);

            packet.WriteString(Message);
        }
    }
}