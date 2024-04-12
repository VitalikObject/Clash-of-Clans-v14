using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicUnlockBuildingCommand : LogicCommand
    {
        public LogicUnlockBuildingCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingId { get; set; }

        public override void Decode()
        {
            BuildingId = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var buildings = home.GameObjectManager.GetBuildings();

            var index = buildings.FindIndex(b => b.Id == BuildingId);
            if (index > -1)
            {
                var building = buildings[index];
                var data = building.BuildingData;

                var cost = data.BuildCost[0];
                var resource = data.BuildResource;

                if (home.UseResourceByName(resource, cost))
                {
                    building.SetUpgradeLevel(-1);
                    building.StartUpgrade();
                }
                else
                {
                    Device.Disconnect("Payment failed.");
                }
            }
            else
            {
                Device.Disconnect($"Building {BuildingId} not found.");
            }
        }
    }
}