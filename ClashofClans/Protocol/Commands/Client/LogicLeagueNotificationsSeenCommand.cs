using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicLeagueNotificationsSeenCommand : LogicCommand
    {
        public LogicLeagueNotificationsSeenCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt();
            Reader.ReadInt();
        }

        public override void Execute()
        {
            Device.Player.Home.GameObjectManager.LastLeagueRank = Device.Player.Home.League;
        }
    }
}
