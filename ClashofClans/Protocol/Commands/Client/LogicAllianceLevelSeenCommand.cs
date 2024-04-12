using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicAllianceLevelSeenCommand : LogicCommand
    {
        public LogicAllianceLevelSeenCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt();
        }
    }
}