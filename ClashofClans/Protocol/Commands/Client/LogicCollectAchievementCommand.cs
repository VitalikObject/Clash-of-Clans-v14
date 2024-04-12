using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicCollectAchievementCommand : LogicCommand
    {
        public LogicCollectAchievementCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int AchievementId { get; set; }

        public override void Decode()
        {
            AchievementId = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            Device.Disconnect("Not implemented.");
        }
    }
}