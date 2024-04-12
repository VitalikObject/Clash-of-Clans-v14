using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class VillageBackgrounds : Data
    {
        public VillageBackgrounds(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string HomeType { get; set; }

        public bool EnabledByCalendar { get; set; }

        public bool DefaultBackground { get; set; }

        public bool FreeBackground { get; set; }

        public int RequiredTHLevel { get; set; }

        public int PurchasePrice { get; set; }

        public string TID { get; set; }

        public string SWF { get; set; }

        public string Foreground { get; set; }

        public string Background { get; set; }

        public string BaseSWF { get; set; }

        public string BuildingBasesSWF { get; set; }

        public string Icon { get; set; }

        public string Thumbnail { get; set; }

        public string MakeCreator { get; set; }

        public bool CustomShip { get; set; }

        public string ParallaxLayer { get; set; }

        public int ParallaxStrength { get; set; }

        public bool NightMode { get; set; }
    }
}
