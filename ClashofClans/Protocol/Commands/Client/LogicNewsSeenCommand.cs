using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicNewsSeenCommand : LogicCommand
    {
        public LogicNewsSeenCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int NewsId { get; set; }

        public override void Decode()
        {
            NewsId = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            Device.Player.Home.GameObjectManager.LastNewsSeen = NewsId;
        }
    }
}