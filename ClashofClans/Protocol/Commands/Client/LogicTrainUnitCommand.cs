using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicTrainUnitCommand : LogicCommand
    {
        public LogicTrainUnitCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int UnitType { get; set; }
        private int UnitId { get; set; }
        private int Count { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();

            UnitType = Reader.ReadInt();
            UnitId = Reader.ReadInt();
            Count = Reader.ReadInt();

            Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            Device.Player.Home.Units.Train(UnitType, UnitId, Count);
        }
    }
}