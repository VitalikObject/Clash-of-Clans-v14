using System.Linq;
using System.Numerics;
using ClashofClans.Logic;
using ClashofClans.Logic.Manager.Items.GameObjects;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicBuyBuildingCommand : LogicCommand
    {
        public LogicBuyBuildingCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingData { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override void Decode()
        {
            X = Reader.ReadInt();
            Y = Reader.ReadInt();
            BuildingData = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var objects = home.GameObjectManager;
            var buildings = objects.GetBuildings();

            /*if (objects.IsWorkerAvailable())
            {*/
            var building = new Building(home)
            {
                Position = new Vector2(X, Y),
                Data = BuildingData,
                Id = 500000000 + buildings.Count
            };

            var cost = building.BuildingData.BuildCost[0];

            // Worker Building
            if (BuildingData == 1000015)
            {
                var count = buildings.Count(x => x.Data == BuildingData) - 1;
                cost += cost / 4;

                for (var i = 0; i < count; i++)
                    cost *= 2;
            }
            else if (BuildingData == 1000042) // Troophousing 2
            {
                Device.Disconnect("Troophousing2 can't be bought yet.");
                return;
            }

            if (home.UseResourceByName(building.BuildingData.BuildResource, cost))
            {
                building.SetUpgradeLevel(-1);
                building.StartUpgrade();

                building.LoadComponents();
                buildings.Add(building);
            }
            else
            {
                Device.Disconnect("Failed to buy building.");
            }

            /*}
            else
            {
                Device.Disconnect("No worker available!");
            }*/
        }
    }
}