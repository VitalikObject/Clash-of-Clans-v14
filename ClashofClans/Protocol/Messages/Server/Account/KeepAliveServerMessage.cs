using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server.Account
{
    public class KeepAliveServerMessage : PiranhaMessage
    {
        public KeepAliveServerMessage(Device device) : base(device)
        {
            Id = 20108;
        }

        public override void EncodeAsync()
        {
            Writer.WriteBytes(new byte[16]);
        }
    }
}