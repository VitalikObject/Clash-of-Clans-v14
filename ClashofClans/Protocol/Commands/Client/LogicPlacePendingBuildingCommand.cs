using System.Numerics;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic.Manager.Items.GameObjects;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicPlacePendingBuildingCommand : LogicCommand
    {
        public LogicPlacePendingBuildingCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int X { get; set; }
        private int Y { get; set; }
        public int BuildingData { get; set; }
        public override void Decode()
        {
            X = Reader.ReadInt();
            Y = Reader.ReadInt();
            BuildingData = Reader.ReadInt();
            Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            var home = Device.Player.Home;
            var objects = home.GameObjectManager;
            var decos = objects.GetDecos();

            var deco = new Deco(home)
            {
                Position = new Vector2(X, Y),
                Data = BuildingData,
                Id = 180000000 + decos.Count
            };

            decos.Add(deco);
        }
    }
}
