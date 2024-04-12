using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Regions : Data
    {
        public Regions(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string DisplayName { get; set; }

        public bool IsCountry { get; set; }

        public bool HS { get; set; }

        public string ChinaDisplayName { get; set; }

        public string ChinaCountryCode { get; set; }
    }
}
