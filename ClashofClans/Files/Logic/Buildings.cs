using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Buildings : Data
    {
        public Buildings(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int BuildingLevel { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string BuildingClass { get; set; }

        public string SecondaryTargetingClass { get; set; }

        public string ShopBuildingClass { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public string ExportNameNpc { get; set; }

        public string ExportNameConstruction { get; set; }

        public string ExportNameLocked { get; set; }

        public int[] BuildTimeD { get; set; }

        public int[] BuildTimeH { get; set; }

        public int[] BuildTimeM { get; set; }

        public int[] BuildTimeS { get; set; }

        public string BuildResource { get; set; }

        public int[] BuildCost { get; set; }

        public int TownHallLevel { get; set; }

        public int TownHallLevel2 { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Icon { get; set; }

        public string ExportNameBuildAnim { get; set; }

        public string ExportNameUpgradeAnim { get; set; }

        public int[] MaxStoredGold { get; set; }

        public int[] MaxStoredElixir { get; set; }

        public int[] MaxStoredDarkElixir { get; set; }

        public int[] MaxStoredWarGold { get; set; }

        public int[] MaxStoredWarElixir { get; set; }

        public int[] MaxStoredWarDarkElixir { get; set; }

        public int[] MaxStoredGold2 { get; set; }

        public int[] MaxStoredElixir2 { get; set; }

        public int PercentageStoredGold { get; set; }

        public int PercentageStoredElixir { get; set; }

        public int PercentageStoredDarkElixir { get; set; }

        public bool LootOnDestruction { get; set; }

        public bool Bunker { get; set; }

        public int Village2Housing { get; set; }

        public int[] HousingSpace { get; set; }

        public int HousingSpaceAlt { get; set; }

        public int HousingSpaceSiege { get; set; }

        public string ProducesResource { get; set; }

        public int[] ResourcePer100Hours { get; set; }

        public int[] ResourceMax { get; set; }

        public int ResourceIconLimit { get; set; }

        public int[] UnitProduction { get; set; }

        public string UpgradesUnitType { get; set; }

        public int ProducesUnitsOfType { get; set; }

        public string LevelRequirementTID { get; set; }

        public int BoostCost { get; set; }

        public bool FreeBoost { get; set; }

        public int Hitpoints { get; set; }

        public int RegenTime { get; set; }

        public int AttackRange { get; set; }

        public bool AltAttackMode { get; set; }

        public int AltAttackRange { get; set; }

        public int PrepareSpeed { get; set; }

        public int AttackSpeed { get; set; }

        public int AltAttackSpeed { get; set; }

        public int CoolDownOverride { get; set; }

        public int DPS { get; set; }

        public int AltDPS { get; set; }

        public int Damage { get; set; }

        public string PreferredTarget { get; set; }

        public int PreferredTargetDamageMod { get; set; }

        public bool RandomHitPosition { get; set; }

        public string DestroyEffect { get; set; }

        public string DestroyDamageEffect { get; set; }

        public string AttackEffect { get; set; }

        public string AttackEffect2 { get; set; }

        public int ChainAttackDistance { get; set; }

        public int ChainAttackMaxTargets { get; set; }

        public int ChainAttackDelay { get; set; }

        public int ChainAttackDamageReductionPercent { get; set; }

        public string AttackEffectAlt { get; set; }

        public string HitEffect { get; set; }

        public string Projectile { get; set; }

        public string AltProjectile { get; set; }

        public string ExportNameDamaged { get; set; }

        public int BuildingW { get; set; }

        public int BuildingH { get; set; }

        public int BaseGfx { get; set; }

        public string ExportNameBase { get; set; }

        public bool AirTargets { get; set; }

        public bool GroundTargets { get; set; }

        public bool MultiTargets { get; set; }

        public int NumMultiTargets { get; set; }

        public bool AltAirTargets { get; set; }

        public bool AltGroundTargets { get; set; }

        public bool AltMultiTargets { get; set; }

        public int AmmoCount { get; set; }

        public string AmmoResource { get; set; }

        public int AmmoCost { get; set; }

        public int MinAttackRange { get; set; }

        public int DamageRadius { get; set; }

        public int PushBack { get; set; }

        public bool WallCornerPieces { get; set; }

        public string LoadAmmoEffect { get; set; }

        public string NoAmmoEffect { get; set; }

        public string ToggleAttackModeEffect { get; set; }

        public string PickUpEffect { get; set; }

        public string PlacingEffect { get; set; }

        public bool AnimateTurret { get; set; }

        public string DefenderCharacter { get; set; }

        public int DefenderCount { get; set; }

        public int DefenderZ { get; set; }

        public int AltDefenderZ { get; set; }

        public int DestructionXP { get; set; }

        public bool Locked { get; set; }

        public int StartingHomeCount { get; set; }

        public bool Hidden { get; set; }

        public string AOESpell { get; set; }

        public string AOESpellAlternate { get; set; }

        public int TriggerRadius { get; set; }

        public string ExportNameTriggered { get; set; }

        public string AppearEffect { get; set; }

        public bool ForgesSpells { get; set; }

        public bool ForgesMiniSpells { get; set; }

        public bool IsHeroBarrack { get; set; }

        public string HeroType { get; set; }

        public bool IncreasingDamage { get; set; }

        public int DPSLv2 { get; set; }

        public int DPSLv3 { get; set; }

        public int DPSMulti { get; set; }

        public int Lv2SwitchTime { get; set; }

        public int Lv3SwitchTime { get; set; }

        public string AttackEffectLv2 { get; set; }

        public string AttackEffectLv3 { get; set; }

        public string TransitionEffectLv2 { get; set; }

        public string TransitionEffectLv3 { get; set; }

        public int AltNumMultiTargets { get; set; }

        public bool PreventsHealing { get; set; }

        public int StrengthWeight { get; set; }

        public int AlternatePickNewTargetDelay { get; set; }

        public string[] AltBuildResource { get; set; }

        public int SpeedMod { get; set; }

        public int StatusEffectTime { get; set; }

        public int ShockwavePushStrength { get; set; }

        public int ShockwaveArcLength { get; set; }

        public int ShockwaveExpandRadius { get; set; }

        public int TargetingConeAngle { get; set; }

        public int AimRotateStep { get; set; }

        public bool PenetratingProjectile { get; set; }

        public int PenetratingRadius { get; set; }

        public int PenetratingExtraRange { get; set; }

        public int TurnSpeed { get; set; }

        public bool NeedsAim { get; set; }

        public bool TargetGroups { get; set; }

        public int TargetGroupsRadius { get; set; }

        public string HitSpell { get; set; }

        public int HitSpellLevel { get; set; }

        public string ExportNameBeamStart { get; set; }

        public string ExportNameBeamEnd { get; set; }

        public int Damage2 { get; set; }

        public int Damage2Radius { get; set; }

        public int Damage2Delay { get; set; }

        public int Damage2Min { get; set; }

        public int Damage2FalloffStart { get; set; }

        public int Damage2FalloffEnd { get; set; }

        public string HitEffect2 { get; set; }

        public int WakeUpSpeed { get; set; }

        public int WakeUpSpace { get; set; }

        public string PreAttackEffect { get; set; }

        public bool ShareHeroCombatData { get; set; }

        public int BurstCount { get; set; }

        public int BurstDelay { get; set; }

        public int AltBurstCount { get; set; }

        public int AltBurstDelay { get; set; }

        public int DummyProjectileCount { get; set; }

        public int DieDamage { get; set; }

        public int DieDamageRadius { get; set; }

        public string DieDamageEffect { get; set; }

        public int DieDamageDelay { get; set; }

        public bool IsRed { get; set; }

        public int VillageType { get; set; }

        public string WallBlockX { get; set; }

        public string WallBlockY { get; set; }

        public int RedMul { get; set; }

        public int GreenMul { get; set; }

        public int BlueMul { get; set; }

        public int RedAdd { get; set; }

        public int GreenAdd { get; set; }

        public int BlueAdd { get; set; }

        public int DefenceTroopCount { get; set; }

        public string DefenceTroopCharacter { get; set; }

        public string DefenceTroopCharacter2 { get; set; }

        public int DefenceTroopLevel { get; set; }

        public int AmountCanBeUpgraded { get; set; }

        public bool SelfAsAoeCenter { get; set; }

        public int NewTargetAttackDelay { get; set; }

        public string GearUpBuilding { get; set; }

        public int GearUpLevelRequirement { get; set; }

        public string GearUpResource { get; set; }

        public int GearUpCost { get; set; }

        public int GearUpTime { get; set; }

        public string GearUpTID { get; set; }

        public int StartUpgradeBoosterCost { get; set; }

        public int ActivateCombatOnDamageTaken { get; set; }

        public string ActivatedCombatAddBuildingClass { get; set; }

        public int CombatActivationDelay { get; set; }

        public string CombatActivationEffect { get; set; }

        public string Weapon { get; set; }

        public int HintPriority { get; set; }

        public string UpgradeTasks { get; set; }

        public int UpgradeTasksRequired { get; set; }

        public int AnimationActionFrame { get; set; }

        public int MaxLevel => BuildCost.Length - 1;

        public bool IsTownHall => BuildingClass == "Town Hall";

        public bool IsTownHall2 => BuildingClass == "Town Hall2";

        public bool IsWorker => BuildingClass == "Worker";

        public bool IsLaboratory => UpgradesUnitType == "UNIT";

        public bool IsBarrack => UnitProduction[0] > 0 && ProducesUnitsOfType == 1 && !ForgesSpells;

        public bool IsDarkBarrack => UnitProduction[0] > 0 && ProducesUnitsOfType == 2 && !ForgesSpells;

        public bool CanStoreResources =>
            MaxStoredGold[0] > 0
            || MaxStoredElixir[0] > 0
            || MaxStoredDarkElixir[0] > 0
            || MaxStoredWarGold[0] > 0
            || MaxStoredWarElixir[0] > 0
            || MaxStoredWarDarkElixir[0] > 0
            || MaxStoredGold2[0] > 0
            || MaxStoredElixir2[0] > 0;

        public bool IsTrainingHousing => HousingSpace[0] > 0 && !Bunker;

        public int GetBuildTime(int level)
        {
            return BuildTimeD[level] * 86400 + BuildTimeH[level] * 3600 + BuildTimeM[level] * 60 + BuildTimeS[level];
        }
    }
}
