using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Messages.Client.Home
{
    public class NewsSeenMessage : PiranhaMessage
    {
        public NewsSeenMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadByte();
        }
    }
}