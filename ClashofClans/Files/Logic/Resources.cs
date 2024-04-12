using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Resources : Data
    {
        public Resources(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string AltTID { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string CollectEffect { get; set; }

        public string ResourceIconExportName { get; set; }

        public string StealEffect { get; set; }

        public int StealLimitMid { get; set; }

        public string StealEffectMid { get; set; }

        public int StealLimitBig { get; set; }

        public string StealEffectBig { get; set; }

        public bool PremiumCurrency { get; set; }

        public string HudInstanceName { get; set; }

        public string CapFullTID { get; set; }

        public int TextRed { get; set; }

        public int TextGreen { get; set; }

        public int TextBlue { get; set; }

        public string BankedRefResource { get; set; }

        public string WarRefResource { get; set; }

        public string BundleIconExportName { get; set; }

        public int VillageType { get; set; }
    }
}
