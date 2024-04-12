using ClashofClans.Logic;

namespace ClashofClans.Protocol.Messages.Server
{
    public class ShutdownStartedMessage : PiranhaMessage
    {
        public ShutdownStartedMessage(Device device) : base(device)
        {
            Id = 20161;
        }

        public override void EncodeAsync()
        {
            Writer.WriteInt(0);
        }
    }
}