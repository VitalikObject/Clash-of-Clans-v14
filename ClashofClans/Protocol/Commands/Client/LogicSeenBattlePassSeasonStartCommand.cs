using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicSeenBattlePassSeasonStartCommand : LogicCommand
    {
        public LogicSeenBattlePassSeasonStartCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        public override void Decode()
        {
            Reader.ReadInt();
        }
    }
}
