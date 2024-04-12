using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server.Alliance;

namespace ClashofClans.Protocol.Messages.Client.Alliance
{
    public class AskForJoinableAlliancesListMessage : PiranhaMessage
    {
        public AskForJoinableAlliancesListMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public override async void ProcessAsync()
        {
            await new JoinableAllianceListMessage(Device).SendAsync();
        }
    }
}
