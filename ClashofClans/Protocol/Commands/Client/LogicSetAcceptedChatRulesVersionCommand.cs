using ClashofClans.Logic;
using DotNetty.Buffers;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicSetAcceptedChatRulesVersionCommand : LogicCommand
    {
        public LogicSetAcceptedChatRulesVersionCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadByte();

            base.Decode();
        }
    }
}