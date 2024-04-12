using ClashofClans.Files.Logic;
using ClashofClans.Logic;
using ClashofClans.Logic.Manager.Items.GameObjects;
using ClashofClans.Utilities.Netty;
using System.Numerics;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicBuyDecoCommand : LogicCommand
    {
        public LogicBuyDecoCommand(Device device, ByteBuffer buffer) : base(device, buffer)
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

            var cost = deco.DecoData.BuildCost;

            if (home.UseResourceByName(deco.DecoData.BuildResource, cost))
            {
                decos.Add(deco);
            } else
            {
                Device.Disconnect("Failed to buy deco.");
            }
        }
    }
}
