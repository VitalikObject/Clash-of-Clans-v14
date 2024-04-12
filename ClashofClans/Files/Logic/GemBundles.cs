using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class GemBundles : Data
    {
        public GemBundles(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int LinkedPackageID { get; set; }

        public string BillingPackage { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string AnimatedTID { get; set; }

        public bool Disabled { get; set; }

        public bool ExistsApple { get; set; }

        public bool ExistsAndroid { get; set; }

        public bool ExistsKunlun { get; set; }

        public bool ExistsBazaar { get; set; }

        public bool ExistsTencent { get; set; }

        public bool ExistsAmazon { get; set; }

        public bool ExistsSCID { get; set; }

        public int DurationDays { get; set; }

        public string ShopItemExportName { get; set; }

        public string ShopInfoItemExportName { get; set; }

        public string ShopItemBG { get; set; }

        public string ShopItemBGColor { get; set; }

        public int TownhallLimitMin { get; set; }

        public int TownhallLimitMax { get; set; }

        public int VillageType { get; set; }

        public string Buildings { get; set; }

        public string BuildingType { get; set; }

        public int BuildingNumber { get; set; }

        public int BuildingLevel { get; set; }

        public string UnlocksTroop { get; set; }

        public string TroopType { get; set; }

        public int GiftGems { get; set; }

        public int GiftUsers { get; set; }

        public string Resources { get; set; }

        public int ResourceAmounts { get; set; }

        public bool ResourceAmountFromThCSV { get; set; }

        public int THResourceMultiplier { get; set; }

        public string MagicItems { get; set; }

        public int MagicItemAmounts { get; set; }

        public bool RED { get; set; }

        public int Priority { get; set; }

        public bool FrontPageItem { get; set; }

        public bool TreasureItem { get; set; }

        public string ReplacesBillingPackage { get; set; }

        public int ValueForUI { get; set; }

        public int ValueStarsForUI { get; set; }

        public int TimesCanBePurchased { get; set; }

        public bool PremiumPass { get; set; }
    }
}
