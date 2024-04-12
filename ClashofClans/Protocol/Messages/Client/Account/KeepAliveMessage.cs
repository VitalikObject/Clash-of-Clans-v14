using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server.Account;

namespace ClashofClans.Protocol.Messages.Client.Account
{
    public class KeepAliveMessage : PiranhaMessage
    {
        public KeepAliveMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override async void ProcessAsync()
        {
            await new KeepAliveServerMessage(Device).SendAsync();
        }
    }
}