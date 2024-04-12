using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server
{
    public class ServerErrorMessage : PiranhaMessage
    {
        public ServerErrorMessage(Device device) : base(device)
        {
            Id = 24115;
        }

        public string Reason { get; set; }

        public override void EncodeAsync()
        {
            Writer.WriteString(Reason);
        }
    }
}