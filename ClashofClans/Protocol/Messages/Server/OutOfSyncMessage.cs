using ClashofClans.Logic;

namespace ClashofClans.Protocol.Messages.Server
{
    public class OutOfSyncMessage : PiranhaMessage
    {
        public OutOfSyncMessage(Device device) : base(device)
        {
            Id = 29388;
        }

        public override void EncodeAsync()
        {
            Writer.WriteInt(0);
            Writer.WriteInt(0);
            Writer.WriteInt(0);
        }
    }
}