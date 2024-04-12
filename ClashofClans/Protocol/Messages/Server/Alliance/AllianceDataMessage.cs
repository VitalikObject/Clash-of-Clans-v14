using System.Linq;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Messages.Server.Alliance
{
    public class AllianceDataMessage : PiranhaMessage
    {
        public AllianceDataMessage(Device device) : base(device)
        {
            Id = 25413;
        }
        public Logic.Clan.Alliance Alliance { get; set; }
        public override void EncodeAsync()
        {
            Alliance.AllianceFullEntry(Writer);

            Writer.WriteInt(Alliance.Members.Count);

            foreach (var member in Alliance.Members.OrderByDescending(p => p.Score)) member.AllianceMemberEntry(Writer);

            Writer.WriteHex("010000000000e4d13900000006000000000100000020009c396400000000000000002300000000");
            /*Writer.WriteInt(0);
            Writer.WriteInt(0);
            Writer.WriteInt(0);*/
        }
    }
}
