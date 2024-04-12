using System;
using System.Collections.Generic;
using ClashofClans.Files;
using ClashofClans.Files.Logic;
using ClashofClans.Logic.Clan;
using ClashofClans.Logic.Home.Slots;
using ClashofClans.Logic.Home.StreamEntry;
using ClashofClans.Logic.Manager;
using ClashofClans.Logic.Sessions;
using Newtonsoft.Json;

namespace ClashofClans.Logic.Home
{
    public class Home
    {
        [JsonProperty("clanInfo")] public AllianceInfo AllianceInfo = new AllianceInfo();
        [JsonIgnore] public ComponentManager ComponentManager = new ComponentManager();
        [JsonIgnore] public GameObjectManager GameObjectManager = new GameObjectManager();
        [JsonIgnore] public VariableSlots VariableSlots = new VariableSlots();
        [JsonProperty("resources")] public ResourceSlots Resources = new ResourceSlots();
        [JsonProperty("characters")] public HeroesManager Characters = new HeroesManager();
        [JsonProperty("units")] public UnitsManager Units = new UnitsManager();
        [JsonProperty("settings")] public SettingsManager Settings = new SettingsManager();
        [JsonIgnore] public List<Session> Sessions = new List<Session>(50);
        [JsonProperty("stream")] public List<AvatarStreamEntry> Stream = new List<AvatarStreamEntry>(40);
        [JsonIgnore] public Time Time = new Time();
        [JsonIgnore] public Battle Battle = new Battle();
        [JsonIgnore] public GameMatchmakingManager GameMatchmakingManager = new GameMatchmakingManager();

        public Home()
        {
            GameObjectManager.Home = this;
            ComponentManager.Home = this;
        }

        public Home(long id, string token)
        {
            Id = id;
            UserToken = token;

            PreferredDeviceLanguage = "EN";

            Name = "Deed";
            ExpLevel = 1;
            Status = 0;

            Diamonds = 10000000;
            Resources.Initialize();

            GameObjectManager.Home = this;
            ComponentManager.Home = this;
            GameObjectManager.LoadJson(Levels.StartingHome);
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("token")] public string UserToken { get; set; }
        [JsonProperty("nameSet")] public int NameSet { get; set; }
        [JsonProperty("createdIp")] public string CreatedIpAddress { get; set; }
        [JsonProperty("highId")] public int HighId { get; set; }
        [JsonProperty("lowId")] public int LowId { get; set; }
        [JsonProperty("diamonds")] public int Diamonds { get; set; }
        [JsonProperty("language")] public string PreferredDeviceLanguage { get; set; }
        [JsonProperty("fcbId")] public string FacebookId { get; set; }
        [JsonProperty("totalSessions")] public int TotalSessions { get; set; }
        [JsonProperty("totalPlayTimeSeconds")] public int TotalPlayTimeSeconds { get; set; }

        [JsonProperty("lastSave")] public DateTime LastSaveTime { get; set; }

        /// <summary>
        ///     1 = Online, 0 = Offline
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        ///     1 = Builderbase, 0 = Home Village
        /// </summary>
        [JsonProperty("state")]
        public int State { get; set; }

        // Player Stats
        [JsonProperty("expLevel")] public int ExpLevel { get; set; }
        [JsonProperty("expPoints")] public int ExpPoints { get; set; }
        [JsonProperty("attacksWon")] public int AttacksWon { get; set; }
        [JsonProperty("defensesWon")] public int DefensesWon { get; set; }
        [JsonProperty("league")] public int League { get; set; }
        [JsonProperty("trophies")] public int Trophies { get; set; }
        [JsonProperty("duelTrophies")] public int DuelTrophies { get; set; }
        [JsonProperty("currentSeasonMonth")] public int CurrentSeasonMonth { get; set; }
        [JsonProperty("previousSeasonMonth")] public int PreviousSeasonMonth { get; set; }
        [JsonProperty("previousSeasonTrophies")] public int PreviousSeasonTrophies { get; set; }
        [JsonProperty("playerLabels")] public List<int> PlayerLabels = new List<int>();

        [JsonIgnore]
        public long Id
        {
            get => ((long) HighId << 32) | (LowId & 0xFFFFFFFFL);
            set
            {
                HighId = Convert.ToInt32(value >> 32);
                LowId = (int) value;
            }
        }

        /// <summary>
        ///     Add's experience Points to the players account and increments the players level if available
        /// </summary>
        /// <param name="expPoints"></param>
        public void AddExpPoints(int expPoints)
        {
            ExpPoints += expPoints;

            while (true)
            {
                var data = Csv.Tables.Get(Csv.Files.ExperienceLevels).GetDataWithId<ExperienceLevels>(ExpLevel - 1);
                if (data == null) return;

                if (ExpPoints < data.ExpPoints) return;

                ExpLevel++;
                ExpPoints -= data.ExpPoints;

                if (ExpPoints >= data.ExpPoints)
                    continue;

                break;
            }
        }

        public void Tick()
        {
            GameObjectManager.Tick();
        }

        public void FastForward(int seconds)
        {
            GameObjectManager.FastForward(seconds);
        }

        public void Reset(bool notResetGameObjects = false)
        {
            Diamonds = 10000000;
            Resources.Initialize();

            Name = "NoName";
            NameSet = 0;
            ExpLevel = 1;
            ExpPoints = 0;
            Trophies = 0;

            State = 0;

            if (!notResetGameObjects)
                GameObjectManager.LoadJson(Levels.StartingHome);
        }

        #region Resources

        /// <summary>
        ///     Returns true if it was able to remove the amount of gold from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseGold(int amount)
        {
            var gold = Resources.GetById(3000001).Count;

            if (gold - amount < 0) return false;

            Resources.Remove(3000001, amount);
            return true;
        }

        /// <summary>
        ///     Returns true if it was able to remove the amount of elixir from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseElixir(int amount)
        {
            var elixir = Resources.GetById(3000002).Count;

            if (elixir - amount < 0) return false;

            Resources.Remove(3000002, amount);
            return true;
        }

        /// <summary>
        ///     Returns true if it was able to remove the amount of gold2 from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseGold2(int amount)
        {
            var gold2 = Resources.GetById(3000007).Count;

            if (gold2 - amount < 0) return false;

            Resources.Remove(3000007, amount);
            return true;
        }

        /// <summary>
        ///     Returns true if it was able to remove the amount of elixir2 from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseElixir2(int amount)
        {
            var elixir2 = Resources.GetById(3000008).Count;

            if (elixir2 - amount < 0) return false;

            Resources.Remove(3000008, amount);
            return true;
        }

        /// <summary>
        ///     Returns true if it was able to remove the amount of dark elixir from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseDarkElixir(int amount)
        {
            var darkElixir = Resources.GetById(3000003).Count;

            if (darkElixir - amount < 0) return false;

            Resources.Remove(3000003, amount);
            return true;
        }

        /// <summary>
        ///     Returns true if it was able to remove the amount of medals from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseMedals(int amount)
        {
            var medals = Resources.GetById(3000009).Count;

            if (medals - amount < 0) return false;

            Resources.Remove(3000009, amount);
            return true;
        }

        /// <summary>
        ///     Returns true if it was able to remove the amount of diamonds from the players account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UseDiamonds(int amount)
        {
            if (Diamonds - amount < 0) return false;

            Diamonds -= amount;
            return true;
        }

        public bool UseResourceByName(string name, int amount)
        {
            switch (name)
            {
                case "Gold":
                {
                    return UseGold(amount);
                }

                case "Elixir":
                {
                    return UseElixir(amount);
                }

                case "DarkElixir":
                {
                    return UseDarkElixir(amount);
                }

                case "Diamonds":
                {
                    return UseDiamonds(amount);
                }

                case "Gold2":
                {
                    return UseGold2(amount);
                }

                case "Elixir2":
                {
                    return UseElixir2(amount);
                }

                case "Medals":
                {
                    return UseMedals(amount);
                }
            }

            return false;
        }

        public int AddResourceByName(string name, int amount)
        {
            switch (name)
            {
                case "Gold":
                {
                    var storageAvailable = ComponentManager.MaxStoredResource(name);
                    var storageUsed = Resources.GetCount(3000001);

                    if (storageUsed > storageAvailable) return -1;
                    if (storageUsed + amount > storageAvailable)
                        amount = storageAvailable - storageUsed;

                    Resources.Add(3000001, amount);
                    return amount;
                }

                case "Elixir":
                {
                    var storageAvailable = ComponentManager.MaxStoredResource(name);
                    var storageUsed = Resources.GetCount(3000002);

                    if (storageUsed > storageAvailable) return -1;
                    if (storageUsed + amount > storageAvailable)
                        amount = storageAvailable - storageUsed;

                    Resources.Add(3000002, amount);
                    return amount;
                }

                case "DarkElixir":
                {
                    var storageAvailable = ComponentManager.MaxStoredResource(name);
                    var storageUsed = Resources.GetCount(3000003);

                    if (storageUsed > storageAvailable) return -1;
                    if (storageUsed + amount > storageAvailable)
                        amount = storageAvailable - storageUsed;

                    Resources.Add(3000003, amount);
                    return amount;
                }

                case "Diamonds":
                {
                    Diamonds += amount;
                    break;
                }

                case "Gold2":
                {
                    var storageAvailable = ComponentManager.MaxStoredResource(name);
                    var storageUsed = Resources.GetCount(3000007);

                    if (storageUsed > storageAvailable) return -1;
                    if (storageUsed + amount > storageAvailable)
                        amount = storageAvailable - storageUsed;

                    Resources.Add(3000007, amount);
                    return amount;
                }

                case "Elixir2":
                {
                    var storageAvailable = ComponentManager.MaxStoredResource(name);
                    var storageUsed = Resources.GetCount(3000008);

                    if (storageUsed > storageAvailable) return -1;
                    if (storageUsed + amount > storageAvailable)
                        amount = storageAvailable - storageUsed;

                    Resources.Add(3000008, amount);
                    return amount;
                }
            }

            return amount;
        }

        #endregion
    }
}