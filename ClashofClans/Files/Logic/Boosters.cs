using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Boosters : Data
    {
        public Boosters(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string OfferInfoTID { get; set; }

        public string AltTID { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public bool Enabled { get; set; }

        public int MaxItems { get; set; }

        public int DiamondValue { get; set; }

        public int DisplayOrder { get; set; }

        public bool Troop { get; set; }

        public bool Building { get; set; }

        public bool Spell { get; set; }

        public bool Hero { get; set; }

        public bool Wall { get; set; }

        public bool SuperTroop { get; set; }

        public bool StartUpgrade { get; set; }

        public bool FinishUpgrade { get; set; }

        public bool MaxLevelArmy { get; set; }

        public bool BoostResource { get; set; }

        public bool BoostProduction { get; set; }

        public string FillStorageResource { get; set; }

        public bool BoostBuilders { get; set; }

        public bool BoostClocktower { get; set; }

        public bool BoostLaboratory { get; set; }
    }
}
