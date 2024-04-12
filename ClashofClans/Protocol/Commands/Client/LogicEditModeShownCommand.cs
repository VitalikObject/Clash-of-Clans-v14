using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicEditModeShownCommand : LogicCommand
    {
        public LogicEditModeShownCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
    }
}