using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicSelectPetHeroCommand : LogicCommand
    {
        public LogicSelectPetHeroCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        public int HeroId { get; set; }
        public int PetId { get; set; }
        private int Hero { get; set; }
        private int Pet { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();
            HeroId = Reader.ReadInt();
            PetId = Reader.ReadInt();
        }
        public override async void Execute()
        {
            if (PetId != 0)
            {
                Pet = Device.Player.Home.Characters.GetPetFromHero(HeroId);
                Hero = Device.Player.Home.Units.GetHeroFromPet(PetId, HeroId);
                Device.Player.Home.Characters.SetPetToHero(HeroId, PetId);
                Device.Player.Home.Units.SetHeroToPet(PetId, HeroId);
                if (Pet != 0)
                    Device.Player.Home.Units.RemoveHeroFromPet(Pet);
                if (Hero != 0)
                    Device.Player.Home.Characters.RemovePetFromHero(Hero);
            }
            else
            {
                Pet = Device.Player.Home.Characters.GetPetFromHero(HeroId);
                Device.Player.Home.Characters.SetPetToHero(HeroId, PetId);
                Device.Player.Home.Characters.RemovePetFromHero(HeroId);
                Device.Player.Home.Units.RemoveHeroFromPet(Pet);
            }
        }
    }
}
