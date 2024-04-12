using ClashofClans.Logic;
using System.Collections.Generic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic.Clan.StreamEntry;

namespace ClashofClans.Protocol.Messages.Server
{
    public class AllianceStreamMessage : PiranhaMessage
    {
        public AllianceStreamMessage(Device device) : base(device)
        {
            Id = 23825;
        }

        public List<AllianceStreamEntry> Entries { get; set; }

        public override void EncodeAsync()
        {
            Writer.WriteInt(0);

            Writer.WriteInt(Entries.Count);

            foreach (var entry in Entries)
            {
                entry.Encode(Writer);
            }
        }
    }
}
