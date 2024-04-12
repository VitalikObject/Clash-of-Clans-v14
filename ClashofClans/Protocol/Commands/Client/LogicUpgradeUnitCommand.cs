using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using System;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicUpgradeUnitCommand : LogicCommand
    {
        public LogicUpgradeUnitCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        private int UnitId { get; set; }
        private int UnitType { get; set; }

        public override void Decode()
        {
            Reader.ReadInt();

            UnitType = Reader.ReadInt();
            Reader.ReadInt();
            UnitId = Reader.ReadInt();

            Reader.ReadInt();
        }
        public override void Execute()
        {
            Device.Player.Home.Units.Upgrade(UnitId, UnitType);
        }
    }
}
