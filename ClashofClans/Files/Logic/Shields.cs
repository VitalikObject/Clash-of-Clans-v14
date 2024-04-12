using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Shields : Data
    {
        public Shields(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public int TimeH { get; set; }

        public int GuardTimeH { get; set; }

        public int Diamonds { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public int CooldownS { get; set; }

        public int LockedAboveScore { get; set; }
    }
}
