using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicCollectResourcesCommand : LogicCommand
    {
        public LogicCollectResourcesCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int BuildingId { get; set; }

        public override void Decode()
        {
            BuildingId = Reader.ReadInt();

            base.Decode();
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

                Logger.Log($"Collected: {building.ResourceProductionComponent.AvailableToCollect}", GetType(), Logger.ErrorLevel.Debug);

                home.ComponentManager.CollectResources(building.Data);
            }
            else
            {
                Device.Disconnect($"Building {BuildingId} not found.");
            }
        }
    }
}