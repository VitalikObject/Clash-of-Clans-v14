using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class AllianceBadges : Data
    {
        public AllianceBadges(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string IconLayer0 { get; set; }

        public string IconLayer1 { get; set; }

        public string IconLayer2 { get; set; }
    }
}
