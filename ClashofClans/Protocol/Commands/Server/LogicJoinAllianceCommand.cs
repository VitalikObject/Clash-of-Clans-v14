using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Server
{
    public class LogicJoinAllianceCommand : LogicCommand
    {
        public LogicJoinAllianceCommand(Device device) : base(device)
        {
            Type = 1;
        }
        public long AllianceId { get; set; }
        public string AllianceName { get; set; }
        public int AllianceBadge { get; set; }
        public int AllianceExpLevel { get; set; }
        public override void Encode()
        {
            Data.WriteLong(AllianceId);
            Data.WriteString(AllianceName);

            Data.WriteInt(AllianceBadge);

            Data.WriteBoolean(false);
            Data.WriteInt(AllianceExpLevel);
            Data.WriteBoolean(false);

            Data.WriteInt(0);
            Data.WriteInt(0);
            //Data.WriteInt(AllianceBadge);
        }
    }
}
