using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Server
{
    public class LogicChangeAvatarNameCommand : LogicCommand
    {
        public LogicChangeAvatarNameCommand(Device device) : base(device)
        {
            Type = 3;
        }

        public string Name { get; set; }

        public override void Encode()
        {
            Data.WriteString(Name);
        }
    }
}