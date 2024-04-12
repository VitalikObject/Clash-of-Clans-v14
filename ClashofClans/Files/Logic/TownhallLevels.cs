using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class TownhallLevels : Data
    {
        public TownhallLevels(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int AttackCost { get; set; }

        public int ResourceStorageLootPercentage { get; set; }

        public int DarkElixirStorageLootPercentage { get; set; }

        public int ResourceStorageLootCap { get; set; }

        public int DarkElixirStorageLootCap { get; set; }

        public int WarPrizeResourceCap { get; set; }

        public int WarPrizeDarkElixirCap { get; set; }

        public int LegendPrizeGoldCap { get; set; }

        public int LegendPrizeElixirCap { get; set; }

        public int LegendPrizeDarkElixirCap { get; set; }

        public int WarPrizeAllianceExpCap { get; set; }

        public int CartLootCapResource { get; set; }

        public int CartLootReengagementResource { get; set; }

        public int CartLootCapDarkElixir { get; set; }

        public int CartLootReengagementDarkElixir { get; set; }

        public int ReengagementBuildingBudget { get; set; }

        public int ReengagementHeroBudget { get; set; }

        public int ReengagementWallBudget { get; set; }

        public int ReengagementLabBudget { get; set; }

        public int HeroBoostHours { get; set; }

        public int PowerBoostHours { get; set; }

        public int ResourceProductionBoostHours { get; set; }

        public int StarBonusBoostHours { get; set; }

        public int TroopHousing { get; set; }

        public int ElixirStorage { get; set; }

        public int GoldStorage { get; set; }

        public int ElixirPump { get; set; }

        public int GoldMine { get; set; }

        public int Barrack { get; set; }

        public int Cannon { get; set; }

        public int Cannon_gearup { get; set; }

        public int Wall { get; set; }

        public int ArcherTower { get; set; }

        public int ArcherTower_gearup { get; set; }

        public int WizardTower { get; set; }

        public int AirDefense { get; set; }

        public int Mortar { get; set; }

        public int Mortar_gearup { get; set; }

        public int AllianceCastle { get; set; }

        public int Ejector { get; set; }

        public int Superbomb { get; set; }

        public int Mine { get; set; }

        public int WorkerBuilding { get; set; }

        public int Laboratory { get; set; }

        public int Communicationsmast { get; set; }

        public int TeslaTower { get; set; }

        public int SpellForge { get; set; }

        public int MiniSpellFactory { get; set; }

        public int Bow { get; set; }

        public int Halloweenbomb { get; set; }

        public int Slowbomb { get; set; }

        public int HeroAltarBarbarianKing { get; set; }

        public int DarkElixirPump { get; set; }

        public int DarkElixirStorage { get; set; }

        public int HeroAltarArcherQueen { get; set; }

        public int AirTrap { get; set; }

        public int MegaAirTrap { get; set; }

        public int DarkElixirBarrack { get; set; }

        public int DarkTower { get; set; }

        public int SantaTrap { get; set; }

        public int StrengthMaxTroopTypes { get; set; }

        public int StrengthMaxSpellTypes { get; set; }

        public int StrengthMaxSiegeTypes { get; set; }

        public int Totem { get; set; }

        public int Halloweenskels { get; set; }

        public int AirBlaster { get; set; }

        public int HeroAltarGrandWarden { get; set; }

        public int MegaCannon { get; set; }

        public int AncientArtillery { get; set; }

        public int BombTower { get; set; }

        public int TreasuryGold { get; set; }

        public int TreasuryElixir { get; set; }

        public int TreasuryDarkElixir { get; set; }

        public int TreasuryWarGold { get; set; }

        public int TreasuryWarElixir { get; set; }

        public int TreasuryWarDarkElixir { get; set; }

        public int FriendlyCost { get; set; }

        public int PackElixir { get; set; }

        public int PackGold { get; set; }

        public int PackDarkElixir { get; set; }

        public int PackGold2 { get; set; }

        public int PackElixir2 { get; set; }

        public int FreezeBomb { get; set; }

        public int DuelPrizeResourceCap { get; set; }

        public int ElixirPump2 { get; set; }

        public int ElixirStorage2 { get; set; }

        public int GoldMine2 { get; set; }

        public int GoldStorage2 { get; set; }

        public int WallStraight { get; set; }

        public int Cannon2 { get; set; }

        public int ArcherTower2 { get; set; }

        public int TroopHousing2 { get; set; }

        public int TeslaTower2 { get; set; }

        public int DoubleCannon { get; set; }

        public int ClockTower { get; set; }

        public int Laboratory2 { get; set; }

        public int MultiMortar { get; set; }

        public int Barrack2 { get; set; }

        public int MegaTesla { get; set; }

        public int GuardPost { get; set; }

        public int Pusher { get; set; }

        public int HeroAltarWarmachine { get; set; }

        public int AirDefenseMini { get; set; }

        public int Crusher { get; set; }

        public int AirGroundTrap { get; set; }

        public int AirDefense2 { get; set; }

        public int MegaAirGroundTrap { get; set; }

        public int AttackCostVillage2 { get; set; }

        public int ChangeTroopCost { get; set; }

        public int Flamer { get; set; }

        public int GemMine { get; set; }

        public int Ejector2 { get; set; }

        public int GiantCannon { get; set; }

        public int ShrinkTrap { get; set; }

        public int SiegeWorkshop { get; set; }

        public int TornadoTrap { get; set; }

        public int LavaLauncher { get; set; }

        public int MasterBuilderBuilding { get; set; }

        public int ArtoBuilding { get; set; }

        public int HeroAltarRoyalChampion { get; set; }

        public int Scattershot { get; set; }

        public int PetShop { get; set; }
    }
}
