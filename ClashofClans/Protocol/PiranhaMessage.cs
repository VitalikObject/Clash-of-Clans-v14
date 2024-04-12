using System;
using System.Threading.Tasks;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using DotNetty.Buffers;

namespace ClashofClans.Protocol
{
    public class PiranhaMessage
    {
        public Device.State RequiredState = Device.State.Home;

        public PiranhaMessage(Device device)
        {
            Device = device;
            Writer = new ByteBuffer(512);
        }

        public PiranhaMessage(Device device, ByteBuffer buffer)
        {
            Device = device;
            Reader = buffer;
        }

        public ByteBuffer Writer { get; set; }
        public ByteBuffer Reader { get; set; }
        public Device Device { get; set; }
        public ushort Id { get; set; }
        public int Length { get; set; }
        public ushort Version { get; set; }
        public bool Save { get; set; }

        public virtual void Decrypt()
        {
            if (Length <= 0) return;

            var buffer = new ByteBuffer(Reader.ReadBytes(Length));

            Device.Rc4.Decrypt(ref buffer);

            Reader = buffer;
            Length = buffer.ReadableBytes;
        }

        public virtual void Encrypt()
        {
            if (Writer.ReadableBytes <= 0) return;

            var buffer = Writer;

            Device.Rc4.Encrypt(ref buffer);
        }

        public virtual void Decode()
        {
        }

        public virtual void EncodeAsync()
        {
        }

        public virtual void ProcessAsync()
        {
        }

        /// <summary>
        ///     Writes this message to the clients channel
        /// </summary>
        /// <returns></returns>
        public async Task SendAsync()
        {
            try
            {
                await Device.Handler.Channel.WriteAndFlushAsync(this);

                Logger.Log($"[S] Message {Id} ({GetType().Name}) sent.", GetType(), Logger.ErrorLevel.Debug);
            }
            catch (Exception)
            {
                Logger.Log($"Failed to send {Id}.", GetType(), Logger.ErrorLevel.Debug);
            }
        }

        public override string ToString()
        {
            Reader.SetReaderIndex(7);
            return ByteBufferUtil.HexDump(Reader.ReadBytes(Length));
        }
    }
}