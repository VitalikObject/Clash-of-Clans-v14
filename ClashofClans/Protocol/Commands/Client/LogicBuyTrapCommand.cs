using System.Numerics;
using ClashofClans.Files;
using ClashofClans.Files.Logic;
using ClashofClans.Logic;
using ClashofClans.Logic.Manager.Items.GameObjects;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicBuyTrapCommand : LogicCommand
    {
        public LogicBuyTrapCommand(Device device, ByteBuffer buffer) : base(device, buffer)
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
            var traps = home.GameObjectManager.GetTraps();

            var data = Csv.Tables.Get(Csv.Files.Traps).GetDataWithId<Traps>(BuildingData);
            var cost = data.BuildCost[0];

            var trap = new Trap(home)
            {
                Position = new Vector2(X, Y),
                Data = BuildingData,
                Id = 500000000 + traps.Count
            };

            if (home.UseResourceByName(trap.TrapData.BuildResource, cost))
            {
                trap.SetUpgradeLevel(-1);
                trap.StartUpgrade();

                traps.Add(trap);
            }
            else
            {
                Device.Disconnect("Failed to buy building.");
            }
        }
    }
}