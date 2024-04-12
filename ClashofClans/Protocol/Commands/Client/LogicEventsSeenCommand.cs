using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicEventsSeenCommand : LogicCommand
    {
        public LogicEventsSeenCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt(); // Count?

            base.Decode();
        }
    }
}