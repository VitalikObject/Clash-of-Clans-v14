using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server
{
    public class AvailableServerCommandMessage : PiranhaMessage
    {
        public AvailableServerCommandMessage(Device device) : base(device)
        {
            Id = 22740;
        }

        public LogicCommand Command { get; set; }

        public override void EncodeAsync()
        {
            Writer.WriteInt(Command.Type);
            Writer.WriteBytes(Command.Data);
        }
    }
}