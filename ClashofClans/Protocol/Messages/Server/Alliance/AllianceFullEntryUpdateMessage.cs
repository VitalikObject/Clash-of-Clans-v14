using System.Linq;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Messages.Server.Alliance
{
    public class AllianceFullEntryUpdateMessage : PiranhaMessage
    {
        public AllianceFullEntryUpdateMessage(Device device) : base(device)
        {
            Id = 22767;
        }
        public override void EncodeAsync()
        {

        }
    }
}
