using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicDailyDealsSeenCommand : LogicCommand
    {
        public LogicDailyDealsSeenCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
    }
}