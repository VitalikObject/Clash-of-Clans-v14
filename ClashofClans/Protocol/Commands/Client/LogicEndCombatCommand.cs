using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicEndCombatCommand : LogicCommand
    {
        public LogicEndCombatCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
        }
    }
}