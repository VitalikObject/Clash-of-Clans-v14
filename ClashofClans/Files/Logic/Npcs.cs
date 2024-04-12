using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Npcs : Data
    {
        public Npcs(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string MapInstanceName { get; set; }

        public string MapDependencies { get; set; }

        public string TID { get; set; }

        public int ExpLevel { get; set; }

        public string Type { get; set; }

        public int TutorialUnlockTHLevel { get; set; }

        public int TutorialTHLevel { get; set; }

        public int minRecommendedTHLevel { get; set; }

        public string UnitType { get; set; }

        public int UnitCount { get; set; }

        public string LevelFile { get; set; }

        public int Gold { get; set; }

        public int Elixir { get; set; }

        public int DarkElixir { get; set; }

        public bool AlwaysUnlocked { get; set; }

        public string PlayerName { get; set; }

        public string AllianceName { get; set; }

        public int AllianceBadge { get; set; }

        public bool SinglePlayer { get; set; }

        public string AllianceUnitType { get; set; }

        public int AllianceUnitLevel { get; set; }

        public int AllianceUnitCount { get; set; }

        public string FixedArmyUnitType { get; set; }

        public int FixedArmyUnitLevel { get; set; }

        public int FixedArmyUnitCount { get; set; }

        public bool FixedArmyUnitAlliance { get; set; }

        public string FixedArmyUnitPet { get; set; }

        public int FixedArmyUnitPetLevel { get; set; }

        public int FixedArmySkin { get; set; }

        public string DeploySteps { get; set; }

        public bool UseFullMapSize { get; set; }

        public string DefendingHero { get; set; }

        public int DefendingHeroLevel { get; set; }

        public int DefendingHeroSkin { get; set; }

        public int VillageBackground { get; set; }

        public int AttackTimeSeconds { get; set; }
    }
}
