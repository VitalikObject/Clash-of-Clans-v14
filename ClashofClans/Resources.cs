using System;
using ClashofClans.Core;
using ClashofClans.Files;
using ClashofClans.Database;
using System.Threading.Tasks;
using ClashofClans.Core.Network;
using ClashofClans.Logic.Manager;
using ClashofClans.Database.Cache;
using ClashofClans.Utilities.Utils;
using ClashofClans.Core.Leaderboard;

namespace ClashofClans
{
    public static class Resources
    {
        public static Logger Logger { get; set; }
        public static Configuration Configuration { get; set; }

        public static PlayerDb PlayerDb { get; set; }

        public static AllianceDb AllianceDb { get; set; }
        public static ObjectCache ObjectCache { get; set; }
        public static Leaderboard Leaderboard { get; set; }

        public static NettyService Netty { get; set; }

        public static Fingerprint Fingerprint { get; set; }
        public static Csv Csv { get; set; }
        public static Levels Levels { get; set; }

        public static LogicGlobalChatManager ChatManager { get; set; }

        public static Players Players { get; set; }
        public static Alliances Alliances { get; set; }

        public static DateTime StartTime { get; set; }

        public static async void Initialize()
        {
            Logger = new Logger();
            Logger.Log(
                $"Starting [{DateTime.Now.ToLongTimeString()} - {ServerUtils.GetOsName()}]...",
                null);

            Configuration = new Configuration();
            Configuration.Initialize();

            Logger.Log($"Environment: {Resources.Configuration.ServerEnvironment}", null);

            Fingerprint = new Fingerprint();
            Csv = new Csv();
            Levels = new Levels();

            PlayerDb = new PlayerDb();
            AllianceDb = new AllianceDb();

            Logger.Log(
                $"Successfully loaded MySql with {await PlayerDb.CountAsync()} player(s)",
                null);

            ObjectCache = new ObjectCache();

            Players = new Players();
            Alliances = new Alliances();

            Leaderboard = new Leaderboard();

            StartTime = DateTime.UtcNow;

            ChatManager = new LogicGlobalChatManager();

            Netty = new NettyService();

            await Task.Run(Netty.RunServerAsync);
        }
    }
}