using System.Linq;
using ClashofClans.Files;
using ClashofClans.Files.Logic;
using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicClearObstacleCommand : LogicCommand
    {
        public LogicClearObstacleCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int ObstacleId { get; set; }

        public override void Decode()
        {
            ObstacleId = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            var home = Device.Player.Home;
            var objects = home.GameObjectManager;
            var obstacles = objects.GetObstacles();

            var index = obstacles.FindIndex(o => o.Id == ObstacleId);
            if (index > -1)
            {
                var obstacle = obstacles[index];
                var data = obstacle.ObstacleData;

                if (!data.IsTombstone && home.State == 1 && objects.GetBuilderhallLevel() < Csv.Tables
                        .Get(Csv.Files.Globals)
                        .GetData<Globals>("VILLAGE2_DO_NOT_ALLOW_CLEAR_OBSTACLE_TH").NumberValue) return;

                if (home.UseResourceByName(data.ClearResource, data.ClearCost))
                {
                    if (data.IsTombstone)
                        foreach (var o in obstacles.Where(o => o.ObstacleData.IsTombstone))
                            o.StartClearing();
                    else
                        obstacle.StartClearing();

                    // TODO: loot
                }
                else
                {
                    Device.Disconnect("Payment failed.");
                }
            }
            else
            {
                Device.Disconnect($"Obstacle {ObstacleId} not found.");
            }
        }
    }
}