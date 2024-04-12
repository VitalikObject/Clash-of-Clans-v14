using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicSetAllianceUnitDeployMethodCommand : LogicCommand
    {
        public LogicSetAllianceUnitDeployMethodCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt();
        }
    }
}
