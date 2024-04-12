using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Decos : Data
    {
        public Decos(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public string ExportNameConstruction { get; set; }

        public string BuildResource { get; set; }

        public int BuildCost { get; set; }

        public int RequiredExpLevel { get; set; }

        public int MaxCount { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int PassableSubtilesAtEdge { get; set; }

        public string Icon { get; set; }

        public int BaseGfx { get; set; }

        public string ExportNameBase { get; set; }

        public bool IsRed { get; set; }

        public bool NotInShop { get; set; }

        public bool BPReward { get; set; }

        public int VillageType { get; set; }

        public int RedMul { get; set; }

        public int GreenMul { get; set; }

        public int BlueMul { get; set; }

        public int RedAdd { get; set; }

        public int GreenAdd { get; set; }

        public int BlueAdd { get; set; }

        public bool LightsOn { get; set; }

        public bool DecoPath { get; set; }

        public string ActiveEffect { get; set; }

        public int ActiveEffectDelay { get; set; }
    }
}
