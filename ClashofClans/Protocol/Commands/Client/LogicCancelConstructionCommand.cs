using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicCancelConstructionCommand : LogicCommand
    {
        public LogicCancelConstructionCommand(Device device, ByteBuffer buffer) : base(device, buffer)
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
            var objects = home.GameObjectManager;

            if (BuildingId - 503000000 < 0)
            {
                var buildings = objects.GetBuildings();

                var index = buildings.FindIndex(b => b.Id == BuildingId);
                if (index > -1)
                {
                    var building = buildings[index];

                    building.ConstructionTimer = null;

                    var amount = building.BuildingData.BuildCost[building.GetUpgradeLevel() + 1];
                    var resource = building.BuildingData.BuildResource;

                    home.AddResourceByName(resource, amount);
                }
                else
                {
                    Device.Disconnect($"Building {BuildingId} not found.");
                }
            }
            else if (BuildingId - 504000000 < 0)
            {
                var obstacles = objects.GetObstacles();

                var index = obstacles.FindIndex(b => b.Id == BuildingId);
                if (index > -1)
                {
                    var obstacle = obstacles[index];
                    var data = obstacle.ObstacleData;

                    obstacle.ClearingTimer = null;

                    var amount = data.ClearCost / 2;
                    var resource = data.ClearResource;

                    home.AddResourceByName(resource, amount);
                }
                else
                {
                    Device.Disconnect($"Obstacle {BuildingId} not found.");
                }
            }
            else if (BuildingId - 506000000 < 0)
            {
                // Decorations
                Device.Disconnect("Decorations are not supported for this command yet.");
            }
            else
            {
                // VillageObjects
                Device.Disconnect("VillageObjects are not supported for this command yet.");
            }
        }
    }
}