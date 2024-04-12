using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicSwapBuildingsCommand : LogicCommand
    {
        public LogicSwapBuildingsCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int ObjectOne { get; set; }
        public int ObjectTwo { get; set; }

        public override void Decode()
        {
            ObjectOne = Reader.ReadInt();
            ObjectTwo = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            /*var home = Device.Player.Home;

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
                Device.Disconnect("Traps are not supported for this command yet.");
            }
            else if (BuildingId - 507000000 < 0)
            {
                Device.Disconnect("Decos are not supported for this command yet.");
            }
            else
            {
                Device.Disconnect("Unhandled object.");
            }*/
        }
    }
}