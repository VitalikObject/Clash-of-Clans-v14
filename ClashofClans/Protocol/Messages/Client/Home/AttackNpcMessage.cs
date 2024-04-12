using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server.Battle;

namespace ClashofClans.Protocol.Messages.Client.Home
{
    public class AttackNpcMessage : PiranhaMessage
    {
        public AttackNpcMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.Home;
        }
        public int LevelId { get; set; }
        public override void Decode()
        {
            LevelId = Reader.ReadInt();
        }
        public override async void ProcessAsync()
        {
            Device.CurrentBattleType = Device.BattleType.Goblins;

            await new NpcDataMessage(Device)
            {
                NpcId = LevelId
            }.SendAsync();
        }
    }
}