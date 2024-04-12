using System;
using System.IO;
using Newtonsoft.Json;

namespace ClashofClans.Core
{
    public class Configuration
    {
        [JsonIgnore] public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Auto,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.None
        };

        [JsonProperty("encryption_key")] public string EncryptionKey = "xpn9kw85qa8shqtka36adqjnrdekg7pq";
        [JsonProperty("encryption_nonce")] public string EncryptionNonce = "86rfwfzxzynsfa5xz5njdxsfkh4cesau";

        [JsonProperty("mysql_database")] public string MySqlDatabase = "magic-database";
        [JsonProperty("mysql_password")] public string MySqlPassword = "";
        [JsonProperty("mysql_server")] public string MySqlServer = "127.0.0.1";
        [JsonProperty("mysql_user")] public string MySqlUserId = "root";

        [JsonProperty("server_port")] public int ServerPort = 9339;
        [JsonProperty("environment")] public string ServerEnvironment = "prod";
        [JsonProperty("update_url")] public string UpdateUrl = "https://github.com/";

        /// <summary>
        ///     Loads the configuration
        /// </summary>
        public void Initialize()
        {
            if (File.Exists("config.json"))
                try
                {
                    var config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));
                    EncryptionKey = config.EncryptionKey;
                    EncryptionNonce = config.EncryptionNonce;

                    MySqlUserId = config.MySqlUserId;
                    MySqlServer = config.MySqlServer;
                    MySqlPassword = config.MySqlPassword;
                    MySqlDatabase = config.MySqlDatabase;

                    ServerPort = config.ServerPort;
                    ServerEnvironment = config.ServerEnvironment;
                    UpdateUrl = config.UpdateUrl;
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't load configuration.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            else
                try
                {
                    Save();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Server configuration has been created.\nNow update the config.json for your needs.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Couldn't create config file.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
        }

        public void Save()
        {
            File.WriteAllText("config.json", JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}