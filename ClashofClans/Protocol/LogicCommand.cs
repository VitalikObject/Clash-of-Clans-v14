using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using DotNetty.Buffers;

namespace ClashofClans.Protocol
{
    public class LogicCommand
    {
        public LogicCommand(Device device)
        {
            Device = device;
            Data = new ByteBuffer();
        }

        public LogicCommand(Device device, ByteBuffer buffer)
        {
            Device = device;
            Reader = buffer;
            Data = new ByteBuffer();
        }

        public ByteBuffer Data { get; set; }
        public Device Device { get; set; }

        public int Type { get; set; }
        public int Tick { get; set; }
        public ByteBuffer Reader { get; set; }

        public virtual void Decode()
        {
            Tick = Reader.ReadInt();
        }

        public virtual void Encode()
        {
        }

        public virtual void Execute()
        {
        }

        public LogicCommand Handle()
        {
            Encode();
            return this;
        }
    }
}