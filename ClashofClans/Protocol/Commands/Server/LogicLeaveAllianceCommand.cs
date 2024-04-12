using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Server
{
    public class LogicLeaveAllianceCommand : LogicCommand
    {
        public LogicLeaveAllianceCommand(Device device) : base(device)
        {
            Type = 2;
        }
        public long AllianceId { get; set; }
        public override void Encode()
        {
            Data.WriteLong(AllianceId);
        }
    }
}
