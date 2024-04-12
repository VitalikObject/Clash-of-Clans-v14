using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicToggleAttackModeCommand : LogicCommand
    {
        public LogicToggleAttackModeCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        private int BuildingId { get; set; }

        public override void Decode()
        {
            BuildingId = Reader.ReadInt();
            Reader.ReadInt();

            Reader.ReadBoolean();
            Reader.ReadBoolean();

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
                building.AttackMode = !building.AttackMode;
            }
        }
    }
}
