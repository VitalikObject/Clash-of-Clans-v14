using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicPlaceHeroCommand : LogicCommand
    {
        public LogicPlaceHeroCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public override void Decode()
        {
            Reader.ReadInt();
            Reader.ReadInt(); // HeroId

            Reader.ReadVInt();
            Reader.ReadVInt();
        }

        public override void Execute()
        {
            if (!Device.Player.Home.Battle.GetBattleStatus() && Device.CurrentBattleType == Device.BattleType.Multiplayer)
            {
                Device.Player.Home.Battle.StartBattle(Device);
            }
        }
    }
}