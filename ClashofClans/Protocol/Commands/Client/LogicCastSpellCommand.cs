using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using System;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicCastSpellCommand : LogicCommand
    {
        public LogicCastSpellCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int SpellId { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();
            SpellId = Reader.ReadInt();

            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadBoolean();
            Reader.ReadVInt();
        }
        public override void Execute()
        {
            if (!Device.Player.Home.Battle.GetBattleStatus() && Device.CurrentBattleType == Device.BattleType.Multiplayer)
            {
                Device.Player.Home.Battle.StartBattle(Device);
            }

            if (Device.CurrentBattleType == Device.BattleType.Multiplayer || Device.CurrentBattleType == Device.BattleType.Goblins)
                Device.Player.Home.Units.RemoveSpell(SpellId);
        }
    }
}
