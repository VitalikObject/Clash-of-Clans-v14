using System.Numerics;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using System;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicMoveBuildingCommand : LogicCommand
    {
        public LogicMoveBuildingCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override void Decode()
        {
            Reader.ReadInt();
            BuildingId = Reader.ReadVInt();
            X = Reader.ReadVInt();
            Y = Reader.ReadVInt();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;

            if (BuildingId - 504000000 < 0)
            {
                var buildings = home.GameObjectManager.GetBuildings();

                var index = buildings.FindIndex(b => b.Id == BuildingId);
                if (index > -1)
                {
                    var building = buildings[index];
                    building.Position = new Vector2(X, Y);
                }
                else
                {
                    Device.Disconnect($"Building {BuildingId} not found.");
                }
            }
            else if (BuildingId - 505000000 < 0)
            {
                var traps = home.GameObjectManager.GetTraps();

                var index = traps.FindIndex(b => b.Id == BuildingId);
                if (index > -1)
                {
                    var trap = traps[index];
                    trap.Position = new Vector2(X, Y);
                }
                else
                {
                    Device.Disconnect($"Trap {BuildingId} not found.");
                }
            }
            else if (BuildingId - 507000000 < 0)
            {
                var decos = home.GameObjectManager.GetDecos();

                var index = decos.FindIndex(b => b.Id == BuildingId);
                if (index > -1)
                {
                    var deco = decos[index];
                    deco.Position = new Vector2(X, Y);
                }
                else
                {
                    Device.Disconnect($"Deco {BuildingId} not found.");
                }
            }
            else
            {
                Device.Disconnect("Unhandled object.");
            }
        }
    }
}