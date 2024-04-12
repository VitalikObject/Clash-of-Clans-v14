using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Variables : Data
    {
        public Variables(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int DefaultValue { get; set; }

        public bool AllowSnapshotUpdate { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }
    }
}
