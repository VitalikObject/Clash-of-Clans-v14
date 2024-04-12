using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server;

namespace ClashofClans.Protocol.Messages.Client.Home
{
    public class HomeBattleReplayMessage : PiranhaMessage
    {
        public HomeBattleReplayMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override async void ProcessAsync()
        {
            Device.CurrentState = Device.State.Visit;

            await new HomeBattleReplayDataMessage(Device).SendAsync();
        }
    }
}