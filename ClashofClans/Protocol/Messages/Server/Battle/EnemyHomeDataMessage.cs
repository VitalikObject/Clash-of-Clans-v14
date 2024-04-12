using System;
using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server.Battle
{
    public class EnemyHomeDataMessage : PiranhaMessage
    {
        public EnemyHomeDataMessage(Device device) : base(device)
        {
            Id = 21940;
            Device.LastVisitHome = DateTime.UtcNow;
        }

        public Player Enemy { get; set; }

        public override void EncodeAsync()
        {
            Enemy.Home.Tick();

            Writer.WriteInt(10);
            Writer.WriteInt(0);
            Writer.WriteInt(TimeUtils.CurrentUnixTimestamp);

            Enemy.LogicClientHome(Writer);
            Enemy.LogicClientAvatar(Writer);

            Device.Player.LogicClientAvatar(Writer);

            Writer.WriteInt(3);
            Writer.WriteInt(0);
            Writer.WriteByte(0);
        }
    }
}