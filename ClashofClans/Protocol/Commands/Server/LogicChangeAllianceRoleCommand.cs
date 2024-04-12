using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Server
{
    public class LogicChangeAllianceRoleCommand : LogicCommand
    {
        public LogicChangeAllianceRoleCommand(Device device) : base(device)
        {
            Type = 8;
        }
        public long AllianceId { get; set; }
        public int AllianceRole { get; set; }
        public override void Encode()
        {
            Data.WriteLong(AllianceId);
            Data.WriteInt(AllianceRole);

            Data.WriteInt(0);
            Data.WriteInt(0);
        }
    }
}
