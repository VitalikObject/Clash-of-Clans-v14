using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class AllianceBadgeLayers : Data
    {
        public AllianceBadgeLayers(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public int RequiredClanLevel { get; set; }
    }
}
