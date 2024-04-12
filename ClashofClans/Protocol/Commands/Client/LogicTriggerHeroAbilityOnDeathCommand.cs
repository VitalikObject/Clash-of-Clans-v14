using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;

namespace ClashofClans.Protocol.Commands.Client
{
    class LogicTriggerHeroAbilityOnDeathCommand : LogicCommand
    {
        public LogicTriggerHeroAbilityOnDeathCommand(Device device, ByteBuffer buffer) : base(device, buffer)
        {
        }
        private int State { get; set; }
        public override void Decode()
        {
            Reader.ReadInt();
            State = Reader.ReadByte();
        }

        public override void Execute()
        {
            Device.Player.Home.Settings.SetTriggerHeroAbilityOnDeath(State);
        }
    }
}