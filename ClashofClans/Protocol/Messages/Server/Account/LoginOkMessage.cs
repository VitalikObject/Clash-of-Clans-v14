using ClashofClans.Logic;
using ClashofClans.Utilities.Netty;

namespace ClashofClans.Protocol.Messages.Server.Account
{
    public class LoginOkMessage : PiranhaMessage
    {
        public LoginOkMessage(Device device) : base(device)
        {
            Id = 23654;
            Version = 1;
        }

        public override void EncodeAsync()
        {
            var home = Device.Player.Home;

            Writer.WriteLong(home.Id);
            Writer.WriteLong(home.Id);

            Writer.WriteString(Device.Player.Home.UserToken);

            Writer.WriteString(string.Empty); // FB Id
            Writer.WriteString("G:1"); // GP Id

            Writer.WriteInt(Resources.Fingerprint.GetMajorVersion);
            Writer.WriteInt(Resources.Fingerprint.GetBuildVersion);
            Writer.WriteInt(Resources.Fingerprint.GetContentVersion);

            Writer.WriteString(Resources.Configuration.ServerEnvironment);

            Writer.WriteInt(1); // SessionCount
            Writer.WriteInt(0); // PlayTime
            Writer.WriteInt(0); // DaysSinceStartedPlaying

            Writer.WriteString(string.Empty);
            Writer.WriteString("0"); // Server Time
            Writer.WriteString("0"); // Account Creation Date

            Writer.WriteInt(0); // StartupCooldownSeconds

            Writer.WriteString(null); // Google Service Id
            Writer.WriteString("DE");
            Writer.WriteString(null);

            Writer.WriteInt(1);
            Writer.WriteString(null);
            Writer.WriteString(null);
            Writer.WriteString(null);

            Writer.WriteInt(1);
            Writer.WriteString("https://game-assets.clashofclans.com/");

            Writer.WriteInt(1);
            Writer.WriteString("https://event-assets.clashofclans.com");

            Writer.WriteHex("FFFFFFFF0100FFFFFFFF");
        }
    }
}