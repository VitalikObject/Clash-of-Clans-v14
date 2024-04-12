using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicToggleHeroModeCommand : LogicCommand
    {
        public LogicToggleHeroModeCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int BuildingId { get; set; }
        private int Mode { get; set; }
        private int HeroId { get; set; }
        public override void Decode()
        {
            BuildingId = Reader.ReadInt();
            Mode = Reader.ReadInt();
            Reader.ReadInt();
        }
        public override void Execute()
        {
            var home = Device.Player.Home;
            var objects = home.GameObjectManager;

            var buildings = objects.GetBuildings();

            var index = buildings.FindIndex(b => b.Id == BuildingId);

            if (index > -1)
            {
                var building = buildings[index];

                HeroId = building.GetBuildingData();
            }

            var hero = Device.Player.Home.Characters.GetID(HeroId);

            Device.Player.Home.Characters.SetModeToHero(hero, Mode);
        }
    }
}
