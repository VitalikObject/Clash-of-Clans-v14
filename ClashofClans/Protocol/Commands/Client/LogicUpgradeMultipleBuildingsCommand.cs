using System.Collections.Generic;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicUpgradeMultipleBuildingsCommand : LogicCommand
    {
        public List<int> BuildingIds = new List<int>();

        public LogicUpgradeMultipleBuildingsCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public bool UseAltResource { get; set; }

        public override void Decode()
        {
            UseAltResource = Reader.ReadBoolean();

            var count = Reader.ReadInt();

            for (var i = 0; i < count; i++) BuildingIds.Add(Reader.ReadInt());

            base.Decode();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var buildings = home.GameObjectManager.GetBuildings();

            //if (home.GameObjectManager.IsWorkerAvailable())
            foreach (var id in BuildingIds)
            {
                var index = buildings.FindIndex(b => b.Id == id);
                if (index > -1)
                {
                    var building = buildings[index];

                    var paid = home.UseResourceByName(
                        UseAltResource
                            ? building.BuildingData.AltBuildResource[building.GetUpgradeLevel()]
                            : building.BuildingData.BuildResource,
                        building.BuildingData.BuildCost[building.GetUpgradeLevel() + 1]);

                    if (paid)
                        building.StartUpgrade();
                    else
                        Device.Disconnect("Payment failed.");
                }
                else
                {
                    Device.Disconnect("Building not found.");
                }
            }

            /*else
                Device.Disconnect("No worker available!");*/
        }
    }
}