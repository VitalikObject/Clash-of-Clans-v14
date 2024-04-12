using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicMissionProgressCommand : LogicCommand
    {
        public LogicMissionProgressCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int MissionId { get; set; }

        public override void Decode()
        {
            MissionId = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            //Device.Disconnect($"Mission {MissionId % 21000000} completed.");

            // TODO
        }
    }
}