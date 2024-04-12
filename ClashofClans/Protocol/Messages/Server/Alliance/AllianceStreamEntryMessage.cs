using ClashofClans.Logic;
using ClashofClans.Logic.Clan.StreamEntry;

namespace ClashofClans.Protocol.Messages.Server.Alliance
{
    public class AllianceStreamEntryMessage : PiranhaMessage
    {
        public AllianceStreamEntryMessage(Device device) : base(device)
        {
            Id = 28046;
        }

        public AllianceStreamEntry Entry { get; set; }

        public override void EncodeAsync()
        {
            Entry.Encode(Writer);
        }
    }
}
