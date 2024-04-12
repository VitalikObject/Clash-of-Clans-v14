using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class CalendarEventFunctions : Data
    {
        public CalendarEventFunctions(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string ParameterType { get; set; }

        public string ParameterName { get; set; }

        public string Description { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public bool TargetingSupported { get; set; }

        public string Category { get; set; }

        public bool Deprecated { get; set; }
    }
}
