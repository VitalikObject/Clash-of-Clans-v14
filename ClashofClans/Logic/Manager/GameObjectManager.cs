using System;
using System.Collections.Generic;
using System.Linq;
using ClashofClans.Files.Logic;
using ClashofClans.Logic.Manager.Items.GameObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClashofClans.Logic.Manager
{
    public class GameObjectManager
    {
        private int _expVersion = 1;

        public SuperLicencesManager SuperLicencesManager = new SuperLicencesManager();

        public List<Building> Buildings = new List<Building>();
        public List<Building> Buildings2 = new List<Building>();

        public List<Deco> Decos = new List<Deco>();
        public List<Deco> Decos2 = new List<Deco>();

        public Home.Home Home;

        public List<Obstacle> Obstacles = new List<Obstacle>();
        public List<Obstacle> Obstacles2 = new List<Obstacle>();

        public int[] Skins =
        {
            52000001, 52000004, 52000005, 52000006, 52000007, 52000008, 52000009, 52000010, 52000011, 52000012,
            52000013, 52000014, 52000015, 52000016, 52000017, 52000018, 52000019, 52000020, 52000021, 52000022,
            52000023, 52000024, 52000025, 52000026, 52000027, 52000029, 52000030, 52000031, 52000032, 52000033,
            52000034, 52000035, 52000036, 52000037, 52000038, 52000039, 52000040, 52000041, 52000042, 52000043,
            52000044, 52000045, 52000046, 52000047, 52000048, 52000049, 52000050, 52000051, 52000052, 52000053,
            52000054, 52000055, 52000056, 52000057, 52000058, 52000059, 52000060, 52000061, 52000062, 52000063,
            52000064, 52000065, 52000066, 52000067, 52000068, 52000069, 52000070, 52000071, 52000072, 52000073,
            52000074, 52000075, 52000076, 52000077, 52000078, 52000079, 52000080, 52000081, 52000082, 52000083,
            52000084, 52000085, 52000086, 52000087, 52000088, 52000089, 52000090, 52000091, 52000092, 52000093,
            52000094, 52000095, 52000096, 52000097, 52000098, 52000099, 52000100, 52000101, 52000102, 52000103
        };

        public int[] vbgs =
        {
            60000004, 60000005, 60000006, 60000007, 60000008, 60000009, 60000010, 60000011, 60000012, 60000013,
            60000014, 60000015, 60000016, 60000017, 60000018, 60000019, 60000020, 60000021, 60000022, 60000023,
            60000024, 60000025, 60000026, 60000027, 60000028, 60000029, 60000030, 60000031, 60000032, 60000033
        };

        public List<Trap> Traps = new List<Trap>();
        public List<Trap> Traps2 = new List<Trap>();

        public List<VillageObject> VillageObjects = new List<VillageObject>();
        public List<VillageObject> VillageObjects2 = new List<VillageObject>();

        public List<int> SelectedBackgrounds = new List<int>();
        public int LastNewsSeen { get; set; }
        public int LastLeagueRank { get; set; }

        /// <summary>
        ///     Returns the Townhall level from this Village
        /// </summary>
        /// <returns></returns>
        public int GetTownhallLevel()
        {
            var i = Buildings.FindIndex(building => building.BuildingData.GetGlobalId() == 1000001);
            return i <= -1 ? 0 : Buildings[i].GetUpgradeLevel();
        }

        /// <summary>
        ///     Returns the Builderhall level from this Builderbase
        /// </summary>
        /// <returns></returns>
        public int GetBuilderhallLevel()
        {
            var i = Buildings2.FindIndex(building => building.BuildingData.GetGlobalId() == 1000034);
            return i <= -1 ? 0 : Buildings2[i].GetUpgradeLevel();
        }

        /// <summary>
        ///     Returns the list of buildings for the current village
        /// </summary>
        /// <returns></returns>
        public List<Building> GetBuildings()
        {
            return Home.State == 0 ? Buildings : Buildings2;
        }

        /// <summary>
        ///     Returns the list of obstacles for the current village
        /// </summary>
        /// <returns></returns>
        public List<Obstacle> GetObstacles()
        {
            return Home.State == 0 ? Obstacles : Obstacles2;
        }

        /// <summary>
        ///     Returns the list of decos for the current village
        /// </summary>
        /// <returns></returns>
        public List<Deco> GetDecos()
        {
            return Home.State == 0 ? Decos : Decos2;
        }

        /// <summary>
        ///     Returns the list of traps for the current village
        /// </summary>
        /// <returns></returns>
        public List<Trap> GetTraps()
        {
            return Home.State == 0 ? Traps : Traps2;
        }

        /// <summary>
        ///     Returns the list of village objects for the current village
        /// </summary>
        /// <returns></returns>
        public List<VillageObject> GetVillageObjects()
        {
            return Home.State == 0 ? VillageObjects : VillageObjects2;
        }

        /// <summary>
        ///     Returns the list of super licenses for the current village
        /// </summary>
        /// <returns></returns>
        public List<int> GetSuperLicences()
        {
            return SuperLicencesManager.Licenses;
        }

        /// <summary>
        ///     Returns the list of super licenses for the current village
        /// </summary>
        /// <returns></returns>
        public void SetSuperLicences(List<int> Licenses)
        {
            SuperLicencesManager.Licenses = Licenses;
        }

        /// <summary>
        ///     Returns the list of buildings for the current village with a given type
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Building> GetBuildings(int data)
        {
            return Home.State == 0
                ? Buildings.Where(x => x.BuildingData.GetGlobalId() == data)
                : Buildings2.Where(x => x.BuildingData.GetGlobalId() == data);
        }

        /// <summary>
        ///     Forward the time of gameobjects in seconds
        /// </summary>
        /// <param name="seconds"></param>
        public void FastForward(int seconds)
        {
            foreach (var building in Buildings) building.FastForward(seconds);
            foreach (var building in Buildings2) building.FastForward(seconds);
            foreach (var obstacle in Obstacles) obstacle.FastForward(seconds);
            foreach (var obstacle in Obstacles2) obstacle.FastForward(seconds);
            foreach (var trap in Traps) trap.FastForward(seconds);
            foreach (var trap in Traps2) trap.FastForward(seconds);
            foreach (var villageObject in VillageObjects) villageObject.FastForward(seconds);
            foreach (var villageObject in VillageObjects2) villageObject.FastForward(seconds);
        }

        #region Tick

        /// <summary>
        ///     Checks if an event for a gameobject happened
        /// </summary>
        public void Tick()
        {
            foreach (var building in Buildings) building.Tick();
            foreach (var building in Buildings2) building.Tick();

            foreach (var obstacle in Obstacles.ToArray())
            {
                obstacle.Tick();

                if (obstacle.Cleared)
                    Obstacles.Remove(obstacle);
            }

            foreach (var obstacle in Obstacles2.ToArray())
            {
                obstacle.Tick();

                if (obstacle.Cleared)
                    Obstacles.Remove(obstacle);
            }

            foreach (var trap in Traps) trap.Tick();
            foreach (var trap in Traps2) trap.Tick();

            foreach (var villageObject in VillageObjects) villageObject.Tick();
            foreach (var villageObject in VillageObjects2) villageObject.Tick();
        }

        #endregion

        #region Json

        /// <summary>
        ///     Returns a valid JSON for gameobjects
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var json = new JObject
            {
                {"exp_ver", _expVersion},
                {"last_news_seen", LastNewsSeen},
                {"last_league_rank", LastLeagueRank},
                {"last_season_seen", DateTime.Now.Month},
                {"legendary", 0},
                {"unlocked_gem_layouts", 3},
                {"active_layout", 0},
                {"creator_tag", "Mr Vitalik"},
                {"creator_expiration", 2147483647}
            };

            // Home Village
            var buildings = new JArray();
            foreach (var building in Buildings) buildings.Add(building.Save());
            json.Add("buildings", buildings);

            var obstacles = new JArray();
            foreach (var obstacle in Obstacles) obstacles.Add(obstacle.Save());
            json.Add("obstacles", obstacles);

            var decos = new JArray();
            foreach (var deco in Decos) decos.Add(deco.Save());
            json.Add("decos", decos);

            var traps = new JArray();
            foreach (var trap in Traps) traps.Add(trap.Save());
            json.Add("traps", traps);

            var villageObjects = new JArray();
            foreach (var villageObject in VillageObjects) villageObjects.Add(villageObject.Save());
            json.Add("vobjs", villageObjects);

            // Builderbase
            var buildings2 = new JArray();
            foreach (var building in Buildings2) buildings2.Add(building.Save());
            json.Add("buildings2", buildings2);

            var obstacles2 = new JArray();
            foreach (var obstacle in Obstacles2) obstacles2.Add(obstacle.Save());
            json.Add("obstacles2", obstacles2);

            var decos2 = new JArray();
            foreach (var deco in Decos2) decos2.Add(deco.Save());
            json.Add("decos2", decos2);

            var traps2 = new JArray();
            foreach (var trap in Traps2) traps2.Add(trap.Save());
            json.Add("traps2", traps2);

            var villageObjects2 = new JArray();
            foreach (var villageObject in VillageObjects2) villageObjects2.Add(villageObject.Save());
            json.Add("vobjs2", villageObjects2);

            var selectedBackground = new JArray();
            foreach (var bg in SelectedBackgrounds) selectedBackground.Add(bg);
            json.Add("bg", selectedBackground);

            json.Add("superlicences", JObject.FromObject(SuperLicencesManager.Save()));

            json.Add("skins", JArray.FromObject(Skins));

            json.Add("vbgs", JArray.FromObject(vbgs));

            return JsonConvert.SerializeObject(json);
        }

        /// <summary>
        ///     Clears all gameobjects and loads the objects from the JSON given
        /// </summary>
        /// <param name="json"></param>
        public void LoadJson(string json)
        {
            Home.ComponentManager.Clear();

            var j = JObject.Parse(json);

            if (j.ContainsKey("exp_ver"))
                _expVersion = j["exp_ver"].ToObject<int>();

            if (j.ContainsKey("last_news_seen"))
                LastNewsSeen = j["last_news_seen"].ToObject<int>();

            if (j.ContainsKey("last_league_rank"))
                LastLeagueRank = j["last_league_rank"].ToObject<int>();

            if (j.ContainsKey("buildings"))
            {
                Buildings.Clear();
                foreach (var jToken in j["buildings"])
                {
                    var obj = (JObject) jToken;

                    var building = new Building(Home)
                    {
                        Id = 500000000 + Buildings.Count
                    };

                    building.Load(obj);
                    Buildings.Add(building);
                }
            }

            if (j.ContainsKey("obstacles"))
            {
                Obstacles.Clear();
                foreach (var jToken in j["obstacles"])
                {
                    var obj = (JObject) jToken;
                    var obstacle = new Obstacle(Home)
                    {
                        Id = 503000000 + Obstacles.Count
                    };

                    obstacle.Load(obj);
                    Obstacles.Add(obstacle);
                }
            }

            if (j.ContainsKey("decos"))
            {
                Decos.Clear();
                foreach (var jToken in j["decos"])
                {
                    var obj = (JObject) jToken;
                    var deco = new Deco(Home)
                    {
                        Id = 506000000 + Decos.Count
                    };

                    deco.Load(obj);
                    Decos.Add(deco);
                }
            }

            if (j.ContainsKey("traps"))
            {
                Traps.Clear();
                foreach (var jToken in j["traps"])
                {
                    var obj = (JObject) jToken;
                    var trap = new Trap(Home)
                    {
                        Id = 504000000 + Traps.Count
                    };

                    trap.Load(obj);
                    Traps.Add(trap);
                }
            }

            if (j.ContainsKey("vobjs"))
            {
                VillageObjects.Clear();
                foreach (var jToken in j["vobjs"])
                {
                    var obj = (JObject) jToken;
                    var villageObject = new VillageObject(Home)
                    {
                        Id = 508000000 + VillageObjects.Count
                    };

                    villageObject.Load(obj);
                    VillageObjects.Add(villageObject);
                }
            }

            if (j.ContainsKey("buildings2"))
            {
                Buildings2.Clear();
                foreach (var jToken in j["buildings2"])
                {
                    var obj = (JObject) jToken;
                    var building2 = new Building(Home)
                    {
                        Id = 500000000 + Buildings2.Count
                    };

                    building2.Load(obj);
                    Buildings2.Add(building2);
                }
            }

            if (j.ContainsKey("obstacles2"))
            {
                Obstacles2.Clear();
                foreach (var jToken in j["obstacles2"])
                {
                    var obj = (JObject) jToken;
                    var obstacle = new Obstacle(Home)
                    {
                        Id = 503000000 + Obstacles2.Count
                    };

                    obstacle.Load(obj);
                    Obstacles2.Add(obstacle);
                }
            }

            if (j.ContainsKey("decos2"))
            {
                Decos2.Clear();
                foreach (var jToken in j["decos2"])
                {
                    var obj = (JObject) jToken;
                    var deco = new Deco(Home)
                    {
                        Id = 506000000 + Decos2.Count
                    };

                    deco.Load(obj);
                    Decos2.Add(deco);
                }
            }

            if (j.ContainsKey("traps2"))
            {
                Traps2.Clear();
                foreach (var jToken in j["traps2"])
                {
                    var obj = (JObject) jToken;
                    var trap = new Trap(Home)
                    {
                        Id = 504000000 + Traps2.Count
                    };

                    trap.Load(obj);
                    Traps2.Add(trap);
                }
            }

            if (j.ContainsKey("vobjs2"))
            {
                VillageObjects2.Clear();
                foreach (var jToken in j["vobjs2"])
                {
                    var obj = (JObject) jToken;
                    var villageObject = new VillageObject(Home)
                    {
                        Id = 508000000 + VillageObjects2.Count
                    };

                    villageObject.Load(obj);
                    VillageObjects2.Add(villageObject);
                }
            }

            if (j.ContainsKey("bg"))
            {
                SelectedBackgrounds.Clear();
                foreach (var jToken in j["bg"])
                {
                    SelectedBackgrounds.Add((int)jToken);
                }
            }

            if (j.ContainsKey("superlicences"))
                SuperLicencesManager.Load(j["superlicences"].ToString());
        }

        #endregion
    }
}