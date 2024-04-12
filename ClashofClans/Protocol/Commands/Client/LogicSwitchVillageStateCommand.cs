using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Commands.Client
{
    public class LogicSwitchVillageStateCommand : LogicCommand
    {
        public LogicSwitchVillageStateCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }

        public int State { get; set; }

        public override void Decode()
        {
            State = Reader.ReadInt();

            base.Decode();
        }

        public override void Execute()
        {
            Device.Player.Home.State = State;
        }
    }
}