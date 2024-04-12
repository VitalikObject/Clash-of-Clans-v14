using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Tasks : Data
    {
        public Tasks(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TaskType { get; set; }

        public string ProgressType { get; set; }

        public string Set { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public int Score { get; set; }

        public int DurationMinutes { get; set; }

        public int Quantity { get; set; }

        public int Quantity2 { get; set; }

        public string Data1 { get; set; }

        public string Data2 { get; set; }

        public int SelectionWeight { get; set; }

        public int ReviveCost { get; set; }

        public bool Disabled { get; set; }
    }
}
