using System.Threading.Tasks;
using ClashofClans.Protocol;
using ClashofClans.Utilities.Netty;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace ClashofClans.Core.Network.Handlers
{
    public class PacketEncoder : ChannelHandlerAdapter
    {
        public override Task WriteAsync(IChannelHandlerContext context, object msg)
        {
            var message = (PiranhaMessage) msg;

            message.EncodeAsync();

            if (message.Id != 20100)
                message.Encrypt();

            var header = PooledByteBufferAllocator.Default.Buffer(7);
            header.WriteUnsignedShort(message.Id);
            header.WriteMedium(message.Writer.ReadableBytes);
            header.WriteUnsignedShort(message.Version);

            base.WriteAsync(context, header);
            return base.WriteAsync(context, message.Writer.Buffer);
        }
    }
}