using System;
using ClashofClans.Logic;
using ClashofClans.Utilities.Utils;

namespace ClashofClans.Protocol.Messages.Server
{
    public class OwnHomeDataMessage : PiranhaMessage
    {
        public OwnHomeDataMessage(Device device) : base(device)
        {
            Id = 25195;
            device.CurrentState = Device.State.Home;
            Device.LastVisitHome = DateTime.UtcNow;
        }

        public override void EncodeAsync()
        {
            var player = Device.Player;

            player.Home.Tick();

            Writer.WriteInt(0);
            Writer.WriteInt(0);
            Writer.WriteInt(TimeUtils.CurrentUnixTimestamp);

            player.LogicClientHome(Writer);
            player.LogicClientAvatar(Writer);

            Writer.WriteInt(0);
            Writer.WriteInt(0);

            Writer.WriteLong(0);
            Writer.WriteLong(0);
            Writer.WriteLong(0);

            Writer.WriteInt(0);
        }
    }
}