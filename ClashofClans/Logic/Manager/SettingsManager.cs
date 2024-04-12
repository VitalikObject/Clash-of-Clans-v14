using Newtonsoft.Json;
using System.Collections.Generic;
using ClashofClans.Logic.Manager.Items;

namespace ClashofClans.Logic.Manager
{
    public class SettingsManager
    {
        [JsonProperty("triggerHeroAbilityOnDeath")] public int TriggerHeroAbilityOnDeath { get; set; }

        public void SetTriggerHeroAbilityOnDeath(int state)
        {
            TriggerHeroAbilityOnDeath = state;
        }
    }
}
