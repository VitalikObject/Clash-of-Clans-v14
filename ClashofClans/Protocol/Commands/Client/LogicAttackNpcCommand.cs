using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;
using ClashofClans.Protocol.Messages.Server.Battle;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicAttackNpcCommand : LogicCommand
    {
        public LogicAttackNpcCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        public int LevelId { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();
            LevelId = Reader.ReadInt();
        }

        public override async void Execute()
        {
            if (LevelId <= 17000075)
                Device.CurrentBattleType = Device.BattleType.Goblins;
            else
                Device.CurrentBattleType = Device.BattleType.Practice;

            await new NpcDataMessage(Device)
            {
                NpcId = LevelId
            }.SendAsync();
        }
    }
}
