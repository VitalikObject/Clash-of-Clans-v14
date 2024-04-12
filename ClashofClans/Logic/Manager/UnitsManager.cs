using Newtonsoft.Json;
using System.Collections.Generic;
using ClashofClans.Logic.Manager.Items;
using ClashofClans.Files.Logic;

namespace ClashofClans.Logic.Manager
{
    public class UnitsManager
    {
        [JsonProperty("spells")] internal List<Unit> Spells = new List<Unit>();

        [JsonProperty("troops")] internal List<Unit> Troops = new List<Unit>();

        [JsonProperty("troopsv2")] internal List<Unit> TroopsV2 = new List<Unit>();

        [JsonProperty("siege_machines")] internal List<Unit> SiegeMachines = new List<Unit>();

        [JsonProperty("pets")] internal List<Unit> Pets = new List<Unit>();

        public void Upgrade(int id, int type)
        {
            switch(type)
            {
                case 0:
                    UpgradeTroop(id);
                    break;
                case 1:
                    UpgradeSpell(id);
                    break;
                case 3:
                    UpgradeSiegeMachine(id);
                    break;
                case 4:
                    UpgradePet(id);
                    break;
            }
        }
        private void UpgradeTroop(int id)
        {
            var index = Troops.FindIndex(troop => troop.Id == id);

            if (index > -1)
                Troops[index].Level++;
            else
                Troops.Add(new Unit
                {
                    Id = id,
                    Level = 1
                });
        }
        private void UpgradeSpell(int id)
        {
            var index = Spells.FindIndex(spell => spell.Id == id);

            if (index > -1)
                Spells[index].Level++;
            else
                Spells.Add(new Unit
                {
                    Id = id,
                    Level = 1
                });
        }
        private void UpgradeSiegeMachine(int id)
        {
            var index = SiegeMachines.FindIndex(machine => machine.Id == id);

            if (index > -1)
                SiegeMachines[index].Level++;
            else
                SiegeMachines.Add(new Unit
                {
                    Id = id,
                    Level = 1
                });
        }
        private void UpgradePet(int id, int lvl = 1)
        {
            var index = Pets.FindIndex(pet => pet.Id == id);

            if (index > -1)
                Pets[index].Level++;
            else
                Pets.Add(new Unit
                {
                    Id = id,
                    Level = lvl
                });
        }
        public int AddPet(int id)
        {
            Pets.Add(new Unit
            {
                Id = id,
                Level = 0
            });

            var index = Pets.FindIndex(pet => pet.Id == id);

            return index;
        }
        public void SetHeroToPet(int petId, int heroId)
        {
            var index = Pets.FindIndex(pet => pet.Id == petId);

            if (index > -1)
                Pets[index].HeroId = heroId;
            else
                Pets[AddPet(petId)].HeroId = heroId;
        }
        public int GetHeroFromPet(int petId, int heroId)
        {
            var index = Pets.FindIndex(pet => pet.Id == petId);
            int hero = 0;

            if (index > -1)
                hero = Pets[index].HeroId;
            else
                AddPet(petId);

            return hero;
        }
        public void RemoveHeroFromPet(int petId)
        {
            var index = Pets.FindIndex(pet => pet.Id == petId);

            if (index > -1)
                Pets[index].HeroId = 0;
            else
                Logger.Log("Pet with Id: " + petId + " doesn't exist", null, Logger.ErrorLevel.Error);
        }
        public void Train(int type, int id, int count)
        {
            switch (type)
            {
                case 0:
                    TrainTroop(id, count);
                    break;
                case 1:
                    BrewSpell(id, count);
                    break;
                case 3:
                    TrainSiegeMachine(id, count);
                    break;
            }
        }
        private void TrainTroop(int id, int count)
        {
            var index = Troops.FindIndex(troop => troop.Id == id);

            if (index > -1)
            {
                Troops[index].Count += count;
            }
            else
            {
                Troops.Add(new Unit
                {
                    Id = id,
                    Level = 0,
                    Count = count
                });
            }
        }
        private void BrewSpell(int id, int count)
        {
            var index = Spells.FindIndex(spell => spell.Id == id);

            if (index > -1)
            {
                Spells[index].Count += count;
            }
            else
            {
                Spells.Add(new Unit
                {
                    Id = id,
                    Level = 0,
                    Count = count
                });
            }
        }
        private void TrainSiegeMachine(int id, int count)
        {
            var index = SiegeMachines.FindIndex(spell => spell.Id == id);

            if (index > -1)
            {
                SiegeMachines[index].Count += count;
            }
            else
            {
                SiegeMachines.Add(new Unit
                {
                    Id = id,
                    Level = 0,
                    Count = count
                });
            }
        }

        public void TrainTroopV2(int id)
        {
            var index = TroopsV2.FindIndex(troop => troop.Id == id);

            if (index > -1)
            {
                TroopsV2.Add(new Unit
                {
                    Id = id
                });
            }
            else
            {
                TroopsV2.Add(new Unit
                {
                    Id = id
                });
            }
        }
        public void Remove(int type, int id, int count)
        {
            switch(type)
            {
                case 0:
                    RemoveTroop(id, count);
                    break;
                case 1:
                    RemoveSpell(id, count);
                    break;
                case 3:
                    RemoveTroop(id, count);
                    break;
            }
        }
        public void RemoveTroop(int id, int cnt = 1)
        {
            var troopIndex = Troops.FindIndex(troop => troop.Id == id);
            var machineIndex = SiegeMachines.FindIndex(troop => troop.Id == id);

            if (troopIndex > -1)
            {
                if(Troops[troopIndex].Count > 0)
                    Troops[troopIndex].Count -= cnt;
            }
            else if(machineIndex > -1)
            {
                if(SiegeMachines[machineIndex].Count > 0)
                    SiegeMachines[machineIndex].Count -= cnt;
            }
            else
            {
                Logger.Log("Unit with Id: " + id + " doesn't exist", null, Logger.ErrorLevel.Error);
            }
        }
        public void RemoveSpell(int id, int cnt = 1)
        {
            var index = Spells.FindIndex(troop => troop.Id == id);

            if (index > -1)
            {
                if (Spells[index].Count > 0)
                    Spells[index].Count -= cnt;
            }
            else
            {
                Logger.Log("Spell with Id: " + id + " doesn't exist", null, Logger.ErrorLevel.Error);
            }
        }
    }
}