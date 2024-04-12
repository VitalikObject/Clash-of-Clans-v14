using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server;

namespace ClashofClans.Protocol.Messages.Client.Home
{
    public class VisitHomeMessage : PiranhaMessage
    {
        public VisitHomeMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public long HomeId { get; set; }
        public override void Decode()
        {
            HomeId = Reader.ReadLong();
            Reader.ReadInt();
        }
        public override async void ProcessAsync()
        {
            var player = await Resources.Players.GetPlayerAsync(HomeId, false);

            await new VisitedHomeDataMessage(Device)
            {
                Player = player
            }.SendAsync();
        }
    }
}