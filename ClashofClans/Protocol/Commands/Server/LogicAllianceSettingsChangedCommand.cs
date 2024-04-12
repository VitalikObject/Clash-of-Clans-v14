using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Server
{
    public class LogicAllianceSettingsChangedCommand : LogicCommand
    {
        public LogicAllianceSettingsChangedCommand(Device device) : base(device)
        {
            Type = 6;
        }
        public long AllianceId { get; set; }
        public int AllianceBadge { get; set; }
        public override void Encode()
        {
            Data.WriteLong(AllianceId);
            Data.WriteInt(AllianceBadge);

            Data.WriteInt(0);
        }
    }
}
