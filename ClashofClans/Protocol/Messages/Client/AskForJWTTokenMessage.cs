using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Client
{
    public class AskForJWTTokenMessage : PiranhaMessage
    {
        public AskForJWTTokenMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
    }
}
