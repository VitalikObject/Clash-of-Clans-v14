using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicChangeCharacterSkinCommand : LogicCommand
    {
        public LogicChangeCharacterSkinCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int HeroId { get; set; }
        private int SkinId { get; set; }
        public override void Decode()
        {
            HeroId = Reader.ReadInt();
            SkinId = Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            Device.Player.Home.Characters.SetSkinToHero(HeroId, SkinId);
        }
    }
}
