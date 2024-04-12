using System;
using ClashofClans.Utilities.Netty;
using ClashofClans.Logic;
using ClashofClans.Protocol.Messages.Server;
using ClashofClans.Protocol.Messages.Server.Account;

namespace ClashofClans.Protocol.Messages.Client.Home
{
    public class EndClientTurnMessage : PiranhaMessage
    {
        public EndClientTurnMessage(Device device, ByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public int SubTick { get; set; }
        public int Checksum { get; set; }
        public int Count { get; set; }
        public int BattleStars { get; set; }
        public int BattlePercantage { get; set; }

        public override void Decode()
        {
            SubTick = Reader.ReadInt();
            Checksum = Reader.ReadInt();
            Count = Reader.ReadInt();
        }

        public override async void ProcessAsync()
        {
            if (SubTick < 0)
            {
                Logger.Log($"Client Tick ({SubTick}) is corrupted. Disconnecting.", GetType(),
                    Logger.ErrorLevel.Warning);
                Device.Disconnect($"Client Tick ({SubTick}) is corrupted.");
                return;
            }

            if (Device.Player.Home.Battle.GetBattleStatus())
            {
                BattleStars = Checksum & 0x03;
                BattlePercantage = Checksum >> 2;

                if (BattleStars >= 4)
                {
                    await new OutOfSyncMessage(Device).SendAsync();
                }
                if (BattlePercantage > 100)
                {
                    await new OutOfSyncMessage(Device).SendAsync();
                }
                if (BattlePercantage == 100 && BattleStars != 3)
                {
                    await new OutOfSyncMessage(Device).SendAsync();
                }
                Device.Player.Home.Battle.SetBattleStars(BattleStars);
                Device.Player.Home.Battle.SetBattlePercenatage(BattlePercantage);
            }

            if (Count <= 0 || Count > 128) return;

            var home = Device.Player.Home;
            home.Tick();

            for (var i = 0; i < Count; i++)
            {
                var type = Reader.ReadInt();

                if (type < 500 || type > 1000) return;

                if (LogicCommandManager.Commands.ContainsKey(type))
                {
                    try
                    {
                        if (Activator.CreateInstance(LogicCommandManager.Commands[type], Device,
                                Reader) is
                            LogicCommand
                            command)
                        {
                            command.Type = type;
                            command.Decode();
                            command.Execute();

                            Logger.Log(
                                $"Command {command.Type} ({command.GetType().Name}) - Tick: {command.Tick}",
                                GetType(), Logger.ErrorLevel.Debug);
                        }
                    }
                    catch (Exception)
                    {
                        Logger.Log($"Failed to decode command {type}", GetType(), Logger.ErrorLevel.Error);
                    }
                }
                else
                {
                    await new LoginFailedMessage(Device)
                    {
                        Reason = $"Command {type} is unhandled."
                    }.SendAsync();

                    /*Logger.Log(
                        $"Command {type} is unhandled. Content: {ToString()}",
                        GetType(), Logger.ErrorLevel.Warning);*/

                    Logger.Log(
                        $"Command {type} is unhandled.",
                        GetType(), Logger.ErrorLevel.Warning);
                    return;
                }
            }

            Save = true;
            home.Time.SubTick = SubTick;
        }
    }
}