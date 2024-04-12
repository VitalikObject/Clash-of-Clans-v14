using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class SuperLicences : Data
    {
        public SuperLicences(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Original { get; set; }

        public int MinOriginalLevel { get; set; }

        public string Replacement { get; set; }

        public int DurationH { get; set; }

        public int CooldownH { get; set; }

        public string Resource { get; set; }

        public int ResourceCost { get; set; }

        public string TrialNPC { get; set; }

        public bool EnabledByCalendar { get; set; }
    }
}
