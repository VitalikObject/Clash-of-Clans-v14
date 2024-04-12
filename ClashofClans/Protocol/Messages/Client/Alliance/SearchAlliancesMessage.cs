using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server.Alliance;

namespace ClashofClans.Protocol.Messages.Client.Alliance
{
    public class SearchAlliancesMessage : PiranhaMessage
    {
        public SearchAlliancesMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        private string AllianceName { get; set; }
        public override void Decode()
        {
            AllianceName = Reader.ReadString();
        }
        public override async void ProcessAsync()
        {
            await new AllianceListMessage(Device)
            {
                AllianceName = AllianceName
            }.SendAsync();
        }
    }
}
