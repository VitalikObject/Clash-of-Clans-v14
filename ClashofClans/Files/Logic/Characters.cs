using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Characters : Data
    {
        public Characters(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int TroopLevel { get; set; }

        public bool Deprecated { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public int HousingSpace { get; set; }

        public int BarrackLevel { get; set; }

        public int LaboratoryLevel { get; set; }

        public int Speed { get; set; }

        public int Hitpoints { get; set; }

        public int TrainingTime { get; set; }

        public string TrainingResource { get; set; }

        public int TrainingCost { get; set; }

        public int UpgradeTimeH { get; set; }

        public int UpgradeTimeM { get; set; }

        public string UpgradeResource { get; set; }

        public int UpgradeCost { get; set; }

        public int DonateCost { get; set; }

        public int DonateXP { get; set; }

        public int DonateCount { get; set; }

        public int AttackRange { get; set; }

        public int AttackSpeed { get; set; }

        public int CoolDownOverride { get; set; }

        public int DPS { get; set; }

        public int PreferedTargetDamageMod { get; set; }

        public int DamageRadius { get; set; }

        public bool AreaDamageIgnoresWalls { get; set; }

        public bool SelfAsAoeCenter { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string BigPicture { get; set; }

        public string BigPictureSWF { get; set; }

        public string Projectile { get; set; }

        public string AltProjectile { get; set; }

        public string PreferedTargetBuilding { get; set; }

        public string PreferedTargetBuildingClass { get; set; }

        public bool PreferredTargetNoTargeting { get; set; }

        public string DeployEffect { get; set; }

        public string AttackEffect { get; set; }

        public string AttackEffect2 { get; set; }

        public string HitEffect { get; set; }

        public string HitEffect2 { get; set; }

        public bool IsFlying { get; set; }

        public bool AirTargets { get; set; }

        public bool GroundTargets { get; set; }

        public int AttackCount { get; set; }

        public string DieEffect { get; set; }

        public string DieEffect2 { get; set; }

        public string Animation { get; set; }

        public string ProductionBuilding { get; set; }

        public bool IsJumper { get; set; }

        public int MovementOffsetAmount { get; set; }

        public int MovementOffsetSpeed { get; set; }

        public string TombStone { get; set; }

        public int DieDamage { get; set; }

        public int DieDamageRadius { get; set; }

        public string DieDamageEffect { get; set; }

        public int DieDamageDelay { get; set; }

        public bool DisableProduction { get; set; }

        public string SecondaryTroop { get; set; }

        public bool IsSecondaryTroop { get; set; }

        public int SecondaryTroopCnt { get; set; }

        public int SecondarySpawnDist { get; set; }

        public bool RandomizeSecSpawnDist { get; set; }

        public bool PickNewTargetAfterPushback { get; set; }

        public int PushbackSpeed { get; set; }

        public string SummonTroop { get; set; }

        public int SummonTroopCount { get; set; }

        public int SummonCooldown { get; set; }

        public string SummonEffect { get; set; }

        public int SummonLimit { get; set; }

        public int SpawnIdle { get; set; }

        public bool SpawnOnAttack { get; set; }

        public int StrengthWeight { get; set; }

        public string ChildTroop { get; set; }

        public int ChildTroopCount { get; set; }

        public int SpeedDecreasePerChildTroopLost { get; set; }

        public int ChildTroop0_X { get; set; }

        public int ChildTroop0_Y { get; set; }

        public int ChildTroop1_X { get; set; }

        public int WallMovementCost { get; set; }

        public int BurstCount { get; set; }

        public int BurstDelay { get; set; }

        public bool AttackMultipleBuildings { get; set; }

        public bool IncreasingDamage { get; set; }

        public int DPSLv2 { get; set; }

        public int DPSLv3 { get; set; }

        public int Lv2SwitchTime { get; set; }

        public int Lv3SwitchTime { get; set; }

        public string AttackEffectLv2 { get; set; }

        public string AttackEffectLv3 { get; set; }

        public string AttackEffectLv4 { get; set; }

        public string TransitionEffectLv2 { get; set; }

        public string TransitionEffectLv3 { get; set; }

        public string TransitionEffectLv4 { get; set; }

        public int TargetedEffectOffset { get; set; }

        public int SecondarySpawnOffset { get; set; }

        public string CustomDefenderIcon { get; set; }

        public int SpecialMovementMod { get; set; }

        public int InvisibilityRadius { get; set; }

        public int HealthReductionPerSecond { get; set; }

        public int AutoMergeDistance { get; set; }

        public int AutoMergeGroupSize { get; set; }

        public bool IsUnderground { get; set; }

        public int ProjectileBounces { get; set; }

        public int FriendlyGroupWeight { get; set; }

        public int EnemyGroupWeight { get; set; }

        public int NewTargetAttackDelay { get; set; }

        public bool TriggersTraps { get; set; }

        public int ChainShootingDistance { get; set; }

        public int ChainAttackDistance { get; set; }

        public int ChainAttackMaxTargets { get; set; }

        public int ChainAttackDelay { get; set; }

        public int ChainAttackDamageReductionPercent { get; set; }

        public string ChainAttackEffect { get; set; }

        public string PreAttackEffect { get; set; }

        public string MoveStartsEffect { get; set; }

        public string MoveTrailEffect { get; set; }

        public string BecomesTargetableEffect { get; set; }

        public bool BoostedIfAlone { get; set; }

        public int BoostRadius { get; set; }

        public int BoostDmgPerfect { get; set; }

        public int BoostAttackSpeed { get; set; }

        public string HideEffect { get; set; }

        public int VillageType { get; set; }

        public int UnitsInCamp { get; set; }

        public int SpecialAbilityLevel { get; set; }

        public string SpecialAbilityName { get; set; }

        public string SpecialAbilityInfo { get; set; }

        public string SpecialAbilityType { get; set; }

        public int SpecialAbilityAttribute { get; set; }

        public int SpecialAbilityAttribute2 { get; set; }

        public int SpecialAbilityAttribute3 { get; set; }

        public string SpecialAbilitySpell { get; set; }

        public string SpecialAbilityEffect { get; set; }

        public string SpecialAbilityIcon { get; set; }

        public bool DisableDonate { get; set; }

        public bool ScaleByTH { get; set; }

        public bool EnabledByCalendar { get; set; }

        public bool EnabledBySuperLicence { get; set; }

        public int LoseHpPerTick { get; set; }

        public int LoseHpInterval { get; set; }

        public int UpgradeLevelByTH { get; set; }

        public string EvolveToCharacter { get; set; }

        public string EvolveEffect { get; set; }

        public int EvolveOnDamageDealt { get; set; }

        public int EvolveTime { get; set; }

        public bool CanAttackWhileMoving { get; set; }

        public string PreferredMovementTarget { get; set; }

        public bool RetargetAfterHit { get; set; }

        public int Damage2 { get; set; }

        public int Damage2Radius { get; set; }

        public int Damage2Delay { get; set; }

        public int Damage2Min { get; set; }

        public int Damage2FalloffStart { get; set; }

        public int Damage2FalloffEnd { get; set; }

        public string DamageMultiplierTarget { get; set; }

        public int DamageMultiplierPercent { get; set; }

        public int FrostOnHitTime { get; set; }

        public int FrostOnHitPercent { get; set; }

        public bool DoesNotOpenCC { get; set; }

        public string DefensiveTroop { get; set; }

        public int DamageReductionToStorages { get; set; }

        public string BunkerTroops { get; set; }

        public int BunkerTroopCount1 { get; set; }

        public int BunkerTroopCount2 { get; set; }

        public int BunkerDegenerationTime { get; set; }

        public int BunkerSpawnDist { get; set; }

        public int HeroDamageMultiplier { get; set; }

        public bool PenetratingProjectile { get; set; }

        public int PenetratingRadius { get; set; }

        public int PenetratingExtraRange { get; set; }

        public bool ImmuneToHealing { get; set; }

        public bool PreferHeroes { get; set; }
    }
}
