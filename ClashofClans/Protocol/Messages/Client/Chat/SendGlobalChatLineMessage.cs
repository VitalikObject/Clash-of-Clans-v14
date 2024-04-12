using System;
using System.Linq;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Files;
using ClashofClans.Database;
using ClashofClans.Utilities;
using ClashofClans.Logic.Manager.Items;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Protocol.Commands.Server;
using ClashofClans.Protocol.Messages.Server.Chat;
using ClashofClans.Protocol.Messages.Server.Account;

namespace ClashofClans.Protocol.Messages.Client.Chat
{
    public class SendGlobalChatLineMessage : PiranhaMessage
    {
        public SendGlobalChatLineMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        private string Message { get; set; }
        public override void Decode()
        {
            Message = Reader.ReadString();
        }
        public override async void ProcessAsync()
        {
            if (Message.StartsWith('/'))
            {
                var cmd = Message.Split(' ');
                var cmdType = cmd[0];
                var cmdValue = 0;

                if (cmd.Length > 1)
                    if (Message.Split(' ')[1].Any(char.IsDigit))
                        int.TryParse(Message.Split(' ')[1], out cmdValue);

                switch (cmdType)
                {
                    case "/skip":
                        {
                            Device.Player.Home.FastForward(cmdValue);

                            await new OwnHomeDataMessage(Device).SendAsync();

                            break;
                        }

                    case "/visit":
                        {
                            await new VisitedHomeDataMessage(Device)
                            {
                                Player = Device.Player
                            }.SendAsync();

                            break;
                        }

                    case "/co":
                        {
                            var manager = Device.Player.Home.GameObjectManager;
                            manager.Obstacles.Clear();
                            manager.Obstacles2.Clear();

                            await new OwnHomeDataMessage(Device).SendAsync();

                            break;
                        }

                    case "/reset":
                        {
                            Device.Player.Home.Reset();

                            await new OwnHomeDataMessage(Device).SendAsync();

                            break;
                        }

                    case "/max":
                        {
                            Device.Player.Home.ExpLevel = 300;
                            Device.Player.Home.ExpPoints = 0;
                            Device.Player.Home.GameObjectManager.LoadJson(Levels.MaxHome);

                            for (int i = 0; i < 4; i++)
                                Device.Player.Home.Characters.IsHeroExist(28000000 + i);

                            await new OwnHomeDataMessage(Device).SendAsync();

                            break;
                        }

                    case "/gems":
                        {
                            Device.Player.Home.Diamonds += 14000;

                            await new AvailableServerCommandMessage(Device)
                            {
                                Command = new LogicDiamondsAddedCommand(Device)
                                {
                                    Diamonds = 14000
                                }.Handle()
                            }.SendAsync();

                            break;
                        }

                    case "/low":
                        {
                            var home = Device.Player.Home;

                            home.Resources.InitializeDefault();
                            home.Diamonds = 100;

                            await new OwnHomeDataMessage(Device).SendAsync();

                            break;
                        }

                    case "/high":
                        {
                            var home = Device.Player.Home;

                            home.Resources.Initialize();

                            await new OwnHomeDataMessage(Device).SendAsync();

                            break;
                        }

                    case "/status":
                        {
                            await new GlobalChatLineMessage(Device)
                            {
                                Message =
                                    $"OnlinePlayers: {Resources.Players.Count}\nCached Players: {Resources.ObjectCache.CachedPlayers()}\nTotal Players: {await PlayerDb.CountAsync()}\nUptime: {DateTime.UtcNow.Subtract(Resources.StartTime).ToReadableString()}",
                                Name = "ServerBot",
                                ExpLevel = 500,
                                League = 22,
                                AccountId = Device.Player.Home.Id
                            }.SendAsync();

                            break;
                        }

                    case "/help":
                        {
                            await new GlobalChatLineMessage(Device)
                            {
                                Message = "/status - See the current server status\n/low - Get minimum of resources\n/high - Get max resources\n/gems - Adds 14k gems\n/reset - Reset your village\n/visit - Visit your own village\n/max - Get a max village\n/co - Clear all obstacles\n/skip [seconds] - Skip time",
                                Name = "ServerBot",
                                ExpLevel = 500,
                                League = 22,
                                AccountId = Device.Player.Home.Id
                            }.SendAsync();

                            break;
                        }
                }
            }
            else if ((DateTime.UtcNow - Device.LastChatMessage).TotalSeconds >= 1.0)
                if (!string.IsNullOrEmpty(Message))
                {
                    Resources.ChatManager.Process(new GlobalChatEntry 
                    {
                        Message = Message,
                        SenderName = Device.Player.Home.Name,
                        SenderId = Device.Player.Home.Id,
                        SenderExpLevel = Device.Player.Home.ExpLevel,
                        SenderLeague = Device.Player.Home.League
                    });

                    Device.LastChatMessage = DateTime.UtcNow;
                }
        }
    }
}
