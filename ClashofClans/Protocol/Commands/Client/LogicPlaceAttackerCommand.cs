using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicPlaceAttackerCommand : LogicCommand
    {
        public LogicPlaceAttackerCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int UnitId { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();
            UnitId = Reader.ReadInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadBoolean();
        }
        public override void Execute()
        {
            if (!Device.Player.Home.Battle.GetBattleStatus() && Device.CurrentBattleType == Device.BattleType.Multiplayer)
            {
                Device.Player.Home.Battle.StartBattle(Device);
            }

            if (Device.CurrentBattleType == Device.BattleType.Multiplayer || Device.CurrentBattleType == Device.BattleType.Goblins)
                Device.Player.Home.Units.RemoveTroop(UnitId);
        }
    }
}