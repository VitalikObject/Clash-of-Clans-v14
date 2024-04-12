using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Achievements : Data
    {
        public Achievements(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public int LevelCount { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string Action { get; set; }

        public int ActionCount { get; set; }

        public string ActionData { get; set; }

        public int ActionDataLevel { get; set; }

        public int ExpReward { get; set; }

        public int DiamondReward { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string CompletedTID { get; set; }

        public bool ShowValue { get; set; }

        public string AndroidID { get; set; }

        public int UIGroup { get; set; }

        public int UIPriority { get; set; }
    }
}
