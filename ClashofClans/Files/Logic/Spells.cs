using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Spells : Data
    {
        public Spells(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public bool DisableProduction { get; set; }

        public int SpellForgeLevel { get; set; }

        public int LaboratoryLevel { get; set; }

        public string TrainingResource { get; set; }

        public int TrainingCost { get; set; }

        public int DonateCost { get; set; }

        public int HousingSpace { get; set; }

        public int TrainingTime { get; set; }

        public int DeployTimeMS { get; set; }

        public int ChargingTimeMS { get; set; }

        public int HitTimeMS { get; set; }

        public int UpgradeTimeH { get; set; }

        public string UpgradeResource { get; set; }

        public int UpgradeCost { get; set; }

        public int BoostTimeMS { get; set; }

        public int SpeedBoost { get; set; }

        public int SpeedBoost2 { get; set; }

        public int JumpHousingLimit { get; set; }

        public int JumpBoostMS { get; set; }

        public int DamageBoostPercent { get; set; }

        public int BuildingDamageBoostPercent { get; set; }

        public int Damage { get; set; }

        public int TroopDamagePermil { get; set; }

        public int BuildingDamagePermil { get; set; }

        public int ExecuteHealthPermil { get; set; }

        public int DamagePermilMin { get; set; }

        public int PreferredDamagePermilMin { get; set; }

        public int Radius { get; set; }

        public int NumberOfHits { get; set; }

        public int RandomRadius { get; set; }

        public int TimeBetweenHitsMS { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string BigPicture { get; set; }

        public string PreDeployEffect { get; set; }

        public string DeployEffect { get; set; }

        public int DeployEffect2Delay { get; set; }

        public string DeployEffect2 { get; set; }

        public string ChargingEffect { get; set; }

        public string HitEffect { get; set; }

        public bool RandomRadiusAffectsOnlyGfx { get; set; }

        public int FreezeTimeMS { get; set; }

        public string SpawnObstacle { get; set; }

        public int NumObstacles { get; set; }

        public int StrengthWeight { get; set; }

        public string ProductionBuilding { get; set; }

        public bool TroopsOnly { get; set; }

        public string TargetInfoString { get; set; }

        public string PreferredTarget { get; set; }

        public int PreferredTargetDamageMod { get; set; }

        public bool BoostDefenders { get; set; }

        public int HeroDamageMultiplier { get; set; }

        public int ShieldProjectileSpeed { get; set; }

        public int ShieldProjectileDamageMod { get; set; }

        public int ExtraHealthPermil { get; set; }

        public int ExtraHealthMin { get; set; }

        public int ExtraHealthMax { get; set; }

        public int PoisonDPS { get; set; }

        public bool PoisonIncreaseSlowly { get; set; }

        public int AttackSpeedBoost { get; set; }

        public bool BoostLinkedToPoison { get; set; }

        public bool PoisonAffectAir { get; set; }

        public bool ScaleDeployEffects { get; set; }

        public int ShieldTime { get; set; }

        public int ShieldProtectionPercent { get; set; }

        public int MaxUnitsHit { get; set; }

        public string EnemyDeployEffect { get; set; }

        public bool SnapToGrid { get; set; }

        public int DuplicateHousing { get; set; }

        public int DuplicateLifetime { get; set; }

        public string SummonTroop { get; set; }

        public int UnitsToSpawn { get; set; }

        public int ShrinkReduceSpeedRatio { get; set; }

        public int ShrinkHitpointsRatio { get; set; }

        public int SpawnDuration { get; set; }

        public int SpawnFirstGroupSize { get; set; }

        public int DamageTHPercent { get; set; }

        public bool ScaleByTH { get; set; }

        public bool EnabledByCalendar { get; set; }

        public int VillageType { get; set; }

        public int PauseCombatComponentsMs { get; set; }

        public int UpgradeLevelByTH { get; set; }

        public bool CanDamageStorages { get; set; }

        public int ChangeTeamTime { get; set; }

        public int InvisibilityTime { get; set; }

        public bool AffectsSiegeMachines { get; set; }

        public int FreezeOuterTimeMS { get; set; }

        public int ConeAngle { get; set; }

        public int FreezePercent { get; set; }

        public int MinRadius { get; set; }

        public int MinDamage { get; set; }
    }
}
