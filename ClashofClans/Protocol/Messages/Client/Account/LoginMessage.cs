using System;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using System.Globalization;
using ClashofClans.Logic.Sessions;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Protocol.Messages.Server.Account;

namespace ClashofClans.Protocol.Messages.Client.Account
{
    public class LoginMessage : PiranhaMessage
    {
        public LoginMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            device.CurrentState = Device.State.Login;
            RequiredState = Device.State.Login;
        }

        public long UserId { get; set; }
        public string UserToken { get; set; }
        public int ClientMajorVersion { get; set; }
        public int ClientBuild { get; set; }
        public int ClientMinorVersion { get; set; }
        public string FingerprintSha { get; set; }
        public string PreferredDeviceLanguage { get; set; }
        public uint Seed { get; set; }

        public override void Decode()
        {
            UserId = Reader.ReadLong();
            UserToken = Reader.ReadString();

            ClientMajorVersion = Reader.ReadInt();
            ClientMinorVersion = Reader.ReadInt();
            ClientBuild = Reader.ReadInt();

            FingerprintSha = Reader.ReadString();

            Reader.ReadString(); // empty
            Reader.ReadString();
            Reader.ReadString(); // empty
            Reader.ReadString(); // Device

            Reader.ReadInt();

            PreferredDeviceLanguage = Reader.ReadString().Substring(3, 2); // Language
            Reader.ReadString();
            Reader.ReadString(); // 10

            Reader.ReadByte();

            Reader.ReadString();
            Reader.ReadString();
            Reader.ReadString();

            Reader.ReadByte();
            Reader.ReadString();

            Seed = Reader.ReadUnsignedInt();
        }

        public override async void ProcessAsync()
        {
            var player = await Resources.Players.Login(UserId, UserToken);

            if (player != null)
            {
                Device.Player = player;
                player.Device = Device;

                player.Home.Status = 1;

                await new LoginOkMessage(Device).SendAsync();

                var ip = Device.GetIp();

                if (UserId <= 0) player.Home.CreatedIpAddress = ip;

                Device.Player.Home.PreferredDeviceLanguage = PreferredDeviceLanguage;

                var session = Device.Session;
                session.Ip = ip;
                session.GameVersion = $"{ClientMajorVersion}.{ClientMinorVersion}";
                session.Location = await Location.GetByIpAsync(ip);
                session.SessionId = Guid.NewGuid().ToString();
                session.StartDate = session.SessionStart.ToString(CultureInfo.InvariantCulture);

                player.Home.TotalSessions++;

                // TESTING:
                player.Home.FastForward((int) DateTime.UtcNow.Subtract(player.Home.LastSaveTime).TotalSeconds);
                
                if (player.Home.League != 0)
                    Resources.Leaderboard.UpdateLeagueMemberList(Device.Player.Home.League);

                await new OwnHomeDataMessage(Device).SendAsync();
                await new AvatarStreamMessage(Device)
                {
                    Entries = player.Home.Stream
                }.SendAsync();

                await Database.PlayerDb.SaveAsync(player);

                if (!player.Home.AllianceInfo.HasAlliance) return;

                var alliance = await Resources.Alliances.GetAllianceAsync(player.Home.AllianceInfo.Id);
                if (alliance == null) return;

                Resources.Alliances.Add(alliance);

                await new AllianceStreamMessage(Device)
                {
                    Entries = alliance.Stream
                }.SendAsync();
            }
            else
            {
                await new LoginFailedMessage(Device)
                {
                    ErrorCode = 1,
                    Reason = "Account not found. Please clear app data."
                }.SendAsync();
            }
        }
    }
}