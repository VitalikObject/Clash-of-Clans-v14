using System;
using ClashofClans.Extensions;
using ClashofClans.Files;
using ClashofClans.Files.Logic;
using Newtonsoft.Json.Linq;

namespace ClashofClans.Logic.Manager.Items.GameObjects
{
    public class VillageObject : GameObject
    {
        private int _upgradeLevel;
        public int Data;
        public int Id;

        public VillageObject(Home.Home home) : base(home)
        {
        }

        public Timer ConstructionTimer { get; set; }

        public VillageObjects VillageObjectsData =>
            Csv.Tables.Get(Csv.Files.VillageObjects).GetDataWithId<VillageObjects>(Data);

        public void StartUpgrade()
        {
            if (ConstructionTimer != null) return;
            var buildTime = VillageObjectsData.GetBuildTime(_upgradeLevel + 1);

            // TODO: WORKER

            if (buildTime <= 0)
            {
                FinishConstruction();
            }
            else
            {
                ConstructionTimer = new Timer();
                ConstructionTimer.StartTimer(Home.Time, buildTime);
            }
        }

        public void SetUpgradeLevel(int upgradeLevel)
        {
            _upgradeLevel = upgradeLevel;
        }

        public int GetUpgradeLevel()
        {
            return _upgradeLevel;
        }

        public void SpeedUpConstruction()
        {
            if (ConstructionTimer == null) return;
            var cost = GamePlayUtil.GetSpeedUpCost(ConstructionTimer.GetRemainingSeconds(Home.Time));

            if (Home.UseDiamonds(cost))
                FinishConstruction();
            else
                Logger.Log("Payment failed.", GetType(), Logger.ErrorLevel.Warning);
        }

        public void FinishConstruction()
        {
            SetUpgradeLevel(_upgradeLevel + 1);

            // TODO: WORKER
            Home.AddExpPoints((int) Math.Sqrt(VillageObjectsData.GetBuildTime(_upgradeLevel)));
            ConstructionTimer = null;
        }

        public override void FastForward(int seconds)
        {
            ConstructionTimer?.FastForward(seconds);

            base.FastForward(seconds);
        }

        public override void Tick()
        {
            if (ConstructionTimer != null)
                if (ConstructionTimer.GetRemainingSeconds(Home.Time) <= 0)
                    FinishConstruction();

            base.Tick();
        }

        public override void Load(JObject jObject)
        {
            base.Load(jObject);

            Data = jObject["data"].ToObject<int>();
            SetUpgradeLevel(jObject["lvl"].ToObject<int>());

            if (jObject.ContainsKey("const_t"))
            {
                var constructionTime = jObject["const_t"].ToObject<int>();
                if (constructionTime > -1)
                {
                    constructionTime = Math.Min(constructionTime, VillageObjectsData.GetBuildTime(_upgradeLevel + 1));

                    ConstructionTimer = new Timer();
                    ConstructionTimer.StartTimer(Home.Time, constructionTime);
                    // TODO: WORKER
                }
            }
        }

        public override JObject Save()
        {
            var jObject = base.Save();

            jObject.Add("data", Data);
            jObject.Add("id", Id);
            jObject.Add("lvl", _upgradeLevel);

            if (ConstructionTimer != null)
                jObject.Add("const_t", ConstructionTimer.GetRemainingSeconds(Home.Time));

            return jObject;
        }
    }
}