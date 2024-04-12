using System;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicUpgradeWeaponCommand : LogicCommand
    {
        public LogicUpgradeWeaponCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int BuildingId { get; set; }
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

            if (BuildingId - 504000000 < 0)
            {
                var buildings = objects.GetBuildings();

                var index = buildings.FindIndex(b => b.Id == BuildingId);

                if (index > -1)
                {
                    var building = buildings[index];

                    building.UpgradeTownHallWeapon();
                }
            }
        }
    }
}