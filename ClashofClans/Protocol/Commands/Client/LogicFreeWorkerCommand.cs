using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicFreeWorkerCommand : LogicCommand
    {
        public LogicFreeWorkerCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int SecondLeft { get; set; }
        public bool CommandEmbed { get; set; }

        public override void Decode()
        {
            SecondLeft = Reader.ReadInt();
            CommandEmbed = Reader.ReadBoolean();
            base.Decode();
        }

        public override void Execute()
        {
            Device.Disconnect($"Not implemented.\n\nIs command embed: {CommandEmbed}, Seconds left: {SecondLeft}");
        }
    }
}