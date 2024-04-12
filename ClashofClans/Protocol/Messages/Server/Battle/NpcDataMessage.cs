using System;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server.Battle
{
    public class NpcDataMessage : PiranhaMessage
    {
        public NpcDataMessage(Device device) : base(device)
        {
            Id = 24346;
            device.CurrentState = Device.State.Battle;
            Device.LastVisitHome = DateTime.UtcNow;
        }
        public int NpcId { get; set; }

        public override void EncodeAsync()
        {
            Writer.WriteInt(0);
            Writer.WriteInt(TimeUtils.CurrentUnixTimestamp);

            LogicNpcAvatar(Writer);
            Device.Player.LogicClientAvatar(Writer);

            Writer.WriteInt(NpcId);

            Writer.WriteBoolean(false);
        }

        private void LogicNpcAvatar(ByteBuffer packet)
        {
            packet.WriteLong(0);

            packet.WriteInt(0);
            packet.WriteInt(0);

            packet.WriteInt(0);

            packet.WriteCompressedString(Resources.Levels.NpcLevels[NpcId - 17000000]);

            packet.WriteCompressedString("{\"event\":[]}");
            packet.WriteCompressedString("{\"Village2\":{\"TownHallMaxLevel\":9}}");
        }
    }
}
