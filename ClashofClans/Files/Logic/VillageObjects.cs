using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class VillageObjects : Data
    {
        public VillageObjects(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public bool Disabled { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public int TileX100 { get; set; }

        public int TileY100 { get; set; }

        public int RequiredTH { get; set; }

        public bool AutomaticUpgrades { get; set; }

        public int[] BuildTimeD { get; set; }

        public int[] BuildTimeH { get; set; }

        public int[] BuildTimeM { get; set; }

        public int[] BuildTimeS { get; set; }

        public bool RequiresBuilder { get; set; }

        public string BuildResource { get; set; }

        public int BuildCost { get; set; }

        public int TownHallLevel { get; set; }

        public string PickUpEffect { get; set; }

        public string Animations { get; set; }

        public int AnimX { get; set; }

        public int AnimY { get; set; }

        public int AnimID { get; set; }

        public int AnimDir { get; set; }

        public int AnimVisibilityOdds { get; set; }

        public bool HasInfoScreen { get; set; }

        public int VillageType { get; set; }

        public int UnitHousing { get; set; }

        public bool HousesUnits { get; set; }

        public bool AllianceBuilding { get; set; }

        public bool LightsOn { get; set; }

        public int GetBuildTime(int level)
        {
            return BuildTimeD[level] * 86400 + BuildTimeH[level] * 3600 + BuildTimeM[level] * 60 + BuildTimeS[level];
        }
    }
}
