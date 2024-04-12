using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server;

namespace ClashofClans.Protocol.Messages.Client
{
    public class GoHomeMessage : PiranhaMessage
    {
        public GoHomeMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override void Decode()
        {
            Reader.ReadByte(); // 4
            Reader.ReadInt(); // 2
            Reader.ReadInt(); // 0
        }

        public override async void ProcessAsync()
        {
            if (Device.Player.Home.GameMatchmakingManager.searchTimer != null)
            {
                Device.Player.Home.GameMatchmakingManager.searchTimer.Stop();
            }

            if (Device.Player.Home.Battle.GetBattleStatus())
            {
                Device.Player.Home.Battle.EndBattle(Device.Player, Device);
            }

            if (Device.CurrentState != Device.State.Home && Device.CurrentBattleType != Device.BattleType.NotInBattle || Device.CurrentState == Device.State.Visit)
            {
                Device.CurrentBattleType = Device.BattleType.NotInBattle;
                await new OwnHomeDataMessage(Device).SendAsync();
            }
            else
                Device.Disconnect("Invalid state!");
        }
    }
}