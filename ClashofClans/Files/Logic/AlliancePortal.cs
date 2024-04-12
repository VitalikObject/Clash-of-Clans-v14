using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class AlliancePortal : Data
    {
        public AlliancePortal(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int VillageType { get; set; }
    }
}
