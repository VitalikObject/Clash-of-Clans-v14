using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Client
{
    public class SetDeviceTokenMessage : PiranhaMessage
    {
        public SetDeviceTokenMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
    }
}