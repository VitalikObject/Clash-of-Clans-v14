using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicMatchmakingCommand : LogicCommand
    {
        public LogicMatchmakingCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Execute()
        {
            Device.CurrentState = Device.State.Battle;
            Device.CurrentBattleType = Device.BattleType.Multiplayer;

            Device.Player.Home.GameMatchmakingManager.Init(Device);
        }
    }
}