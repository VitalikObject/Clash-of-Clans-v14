using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Client
{
    public class AnalyticEventMessage : PiranhaMessage
    {
        public AnalyticEventMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public string EventName { get; set; }
        public string Event { get; set; }

        public override void Decode()
        {
            EventName = Reader.ReadString();
            Event = Reader.ReadString();
        }

        public override void ProcessAsync()
        {
        }
    }
}