using System.Numerics;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicMoveMultipleBuildingsCommand : LogicCommand
    {
        public LogicMoveMultipleBuildingsCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int Count { get; set; }

        public override void Decode()
        {
            Count = Reader.ReadInt();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var buildings = home.GameObjectManager.GetBuildings();

            for (var i = 0; i < Count; i++)
            {
                var x = Reader.ReadInt();
                var y = Reader.ReadInt();
                var id = Reader.ReadInt();

                var index = buildings.FindIndex(b => b.Id == id);
                if (index > -1)
                {
                    var building = buildings[index];
                    building.Position = new Vector2(x, y);
                }
                else
                {
                    Device.Disconnect($"Building {id} not found.");
                }
            }

            base.Decode();
        }
    }
}