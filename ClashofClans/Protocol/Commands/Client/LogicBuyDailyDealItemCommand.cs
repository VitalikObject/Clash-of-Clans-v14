using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server.Account;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicBuyDailyDealItemCommand : LogicCommand
    {
        public LogicBuyDailyDealItemCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int ItemId { get; set; }

        public override void Decode()
        {
            base.Decode();

            ItemId = Reader.ReadInt();
        }

        public override async void Execute()
        {
            await new LoginFailedMessage(Device)
            {
                Reason = "DailyDeals haven't been implemented yet."
            }.SendAsync();
        }
    }
}