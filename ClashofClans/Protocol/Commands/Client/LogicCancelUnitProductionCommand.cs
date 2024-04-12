using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicCancelUnitProductionCommand : LogicCommand
    {
        public LogicCancelUnitProductionCommand(Device device, ByteBuffer buffer) : base(device, buffer)
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
            Device.Player.Home.Units.Remove(UnitType, UnitId, Count);
        }
    }
}
