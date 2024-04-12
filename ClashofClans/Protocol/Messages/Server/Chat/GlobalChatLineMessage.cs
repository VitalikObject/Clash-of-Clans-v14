using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server.Chat
{
    public class GlobalChatLineMessage : PiranhaMessage
    {
        public GlobalChatLineMessage(Device device) : base(device)
        {
            Id = 24654;
        }
        public string Message { get; set; }
        public string Name { get; set; }

        public int ExpLevel { get; set; }
        public int League { get; set; }

        public long AccountId { get; set; }
        public override void EncodeAsync()
        {
            Writer.WriteString(Message);
            Writer.WriteString(Name);

            Writer.WriteInt(ExpLevel);
            Writer.WriteInt(League);

            Writer.WriteLong(AccountId);
            Writer.WriteLong(AccountId);

            Writer.WriteBoolean(false);
        }
    }
}
