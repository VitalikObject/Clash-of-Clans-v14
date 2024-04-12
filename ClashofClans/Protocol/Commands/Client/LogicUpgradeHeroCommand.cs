using System;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicUpgradeHeroCommand : LogicCommand
    {
        public LogicUpgradeHeroCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingId { get; set; }
        private int HeroId { get; set; }

        public override void Decode()
        {
            BuildingId = Reader.ReadInt();

            Reader.ReadInt();
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

            if (hero != -1)
            {
                Device.Player.Home.Characters.UpdradeHero(hero);
            }
            else
            {
                Logger.Log("Unknown hero ID: " + HeroId, null, Logger.ErrorLevel.Error);
            }
        }
    }
}
