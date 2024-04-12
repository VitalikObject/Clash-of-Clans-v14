using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicSpeedUpUpgradeUnitCommand : LogicCommand
    {
        public LogicSpeedUpUpgradeUnitCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
        }
    }
}
