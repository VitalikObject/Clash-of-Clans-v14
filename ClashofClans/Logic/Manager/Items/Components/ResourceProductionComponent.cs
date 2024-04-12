using System;
using ClashofClans.Files;
using ClashofClans.Logic.Manager.Items.GameObjects;
using Newtonsoft.Json.Linq;

namespace ClashofClans.Logic.Manager.Items.Components
{
    public class ResourceProductionComponent : Component
    {
        public string ProducesResource;
        public int ResourceMax;
        public int ResourcePer100Hours;

        public Timer Timer;

        public ResourceProductionComponent(GameObject gameObject) : base(gameObject)
        {
            Type = 5;
            Timer = new Timer();
            SetProduction();
        }

        public int MaxTime => ResourcePer100Hours > 0 ? (int) (360000L * ResourceMax / ResourcePer100Hours) : 0;

        public Files.Logic.Resources ResourceData =>
            Csv.Tables.Get(Csv.Files.Resources).GetData<Files.Logic.Resources>(ProducesResource);

        public int AvailableToCollect
        {
            get
            {
                if (ResourcePer100Hours <= 0) return 0;
                var remainingSeconds = Timer.GetRemainingSeconds(Parent.Home.Time);
                if (remainingSeconds <= 0) return ResourceMax;

                var timeGone = MaxTime - remainingSeconds;
                var perSecondProduced = (double) ResourcePer100Hours / 360000;
                var available = Math.Round(perSecondProduced * timeGone, MidpointRounding.ToZero);
                return (int) available;
            }
        }

        public void CollectResources()
        {
            var availableToCollect = AvailableToCollect;
            if (availableToCollect <= 0) return;

            var collectedResources = Parent.Home.AddResourceByName(ProducesResource, availableToCollect);

            RemoveResources(collectedResources, availableToCollect == collectedResources);
        }

        public void RemoveResources(int amount, bool all = false)
        {
            if (all)
            {
                Timer.StartTimer(Parent.Home.Time, MaxTime);
                return;
            }

            var time = 360000L * amount / ResourcePer100Hours;
            Timer.IncreaseTimer((int) time);
        }

        public void SetProduction()
        {
            var building = (Building) Parent;
            var buildingData = building.BuildingData;

            var lvl = building.GetUpgradeLevel();
            if (lvl >= 0 && !building.Locked)
            {
                ProducesResource = buildingData.ProducesResource;
                ResourcePer100Hours = buildingData.ResourcePer100Hours[lvl];
                ResourceMax = buildingData.ResourceMax[lvl];

                Timer.StartTimer(building.Home.Time, MaxTime);
            }
            else
            {
                ProducesResource = null;
                ResourcePer100Hours = 0;
                ResourceMax = 0;
            }
        }

        public override void FastForward(int seconds)
        {
            Timer.FastForward(seconds);
        }

        public override JObject Save(JObject jObject)
        {
            jObject.Add("res_time", Timer.GetRemainingSeconds(Parent.Home.Time));

            return jObject;
        }

        public override void Load(JObject jObject)
        {
            if (!jObject.ContainsKey("res_time"))
            {
                Timer.StartTimer(Parent.Home.Time, MaxTime);
                return;
            }

            var resTime = jObject["res_time"].ToObject<int>();
            if (resTime <= MaxTime && resTime > -1)
            {
                Timer.StartTimer(Parent.Home.Time, resTime);
            }
        }
    }
}