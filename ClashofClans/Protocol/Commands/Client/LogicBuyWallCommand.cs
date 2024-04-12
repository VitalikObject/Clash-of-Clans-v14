using System.Collections.Generic;
using System.Numerics;
using ClashofClans.Files;
using ClashofClans.Files.Logic;
using ClashofClans.Logic;
using ClashofClans.Logic.Manager.Items.GameObjects;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicBuyWallCommand : LogicCommand
    {
        public LogicBuyWallCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingData { get; set; }
        public List<Vector2> Positions { get; set; }

        public override void Decode()
        {
            var count = Reader.ReadInt();

            Positions = new List<Vector2>(count);

            for (var i = 0; i < count; i++)
            {
                var x = Reader.ReadInt();
                var y = Reader.ReadInt();

                Positions.Add(new Vector2(x, y));
            }

            BuildingData = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var buildings = home.GameObjectManager.GetBuildings();

            //if (home.GameObjectManager.IsWorkerAvailable())
            //{
                var data = Csv.Tables.Get(Csv.Files.Buildings).GetDataWithId<Buildings>(BuildingData);
                var cost = data.BuildCost[0];

                if (home.UseResourceByName(data.BuildResource, cost))
                {
                    var wallId = buildings.Count;
                    var count = 0;

                    foreach (var pos in Positions)
                    {
                        var building = new Building(home)
                        {
                            Position = pos,
                            Data = BuildingData,
                            Id = 500000000 + buildings.Count,
                            WallIndex = wallId
                        };

                        if (count == 0)
                            building.WallPosition = 1;

                        building.WallX = count++;

                        buildings.Add(building);
                    }
                }
                else
                {
                    Device.Disconnect("Failed to buy wall.");
                }
            /*}
            else
            {
                Device.Disconnect("No worker available!");
            }*/
        }
    }
}