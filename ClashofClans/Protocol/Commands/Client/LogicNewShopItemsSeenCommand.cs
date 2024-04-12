using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicNewShopItemsSeenCommand : LogicCommand
    {
        public LogicNewShopItemsSeenCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt();
            Reader.ReadInt();

            base.Decode();
        }
    }
}