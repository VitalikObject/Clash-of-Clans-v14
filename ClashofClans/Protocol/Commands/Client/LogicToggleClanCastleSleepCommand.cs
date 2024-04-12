using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicToggleClanCastleSleepCommand : LogicCommand
    {
        public LogicToggleClanCastleSleepCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int BuildingId { get; set; }
        private byte Mode { get; set; }
        public override void Decode()
        {
            BuildingId = Reader.ReadInt();
            Mode = Reader.ReadByte();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            var home = Device.Player.Home;
            var objects = home.GameObjectManager;

            var buildings = objects.GetBuildings();

            var index = buildings.FindIndex(b => b.Id == BuildingId);

            if (index > -1)
            {
                var building = buildings[index];
                building.Mode = Mode;
            }
        }
    }
}
