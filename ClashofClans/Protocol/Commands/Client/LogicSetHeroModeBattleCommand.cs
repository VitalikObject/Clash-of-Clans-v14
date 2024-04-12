using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicSetHeroModeBattleCommand : LogicCommand
    {
        public LogicSetHeroModeBattleCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int HeroId { get; set; }
        private int Mode { get; set; }
        public override void Decode()
        {
            HeroId = Reader.ReadInt();
            Mode = Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            Device.Player.Home.Characters.SetModeToHero(HeroId, Mode);
        }
    }
}