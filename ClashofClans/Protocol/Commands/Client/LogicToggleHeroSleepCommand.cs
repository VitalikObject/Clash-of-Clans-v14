using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using System;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicToggleHeroSleepCommand : LogicCommand
    {
        public LogicToggleHeroSleepCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int BuildingId { get; set; }
        private int HeroId { get; set; }
        public override void Decode()
        {
            BuildingId = Reader.ReadInt();
            Reader.ReadInt();
            Reader.ReadByte();
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

            home.Characters.SetStateToHero(hero, home.Characters.GetStateFromHero(hero) == 3 ? 2 : 3);
        }
    }
}