using ClashofClans.Files.CsvHelpers;
using ClashofClans.Files.CsvReader;

namespace ClashofClans.Files.Logic
{
    public class Weapons : Data
    {
        public Weapons(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string SWF { get; set; }

        public string ExportName { get; set; }

        public int BuildTimeD { get; set; }

        public int BuildTimeH { get; set; }

        public int BuildTimeM { get; set; }

        public int BuildTimeS { get; set; }

        public string BuildResource { get; set; }

        public int BuildCost { get; set; }

        public int AttackRange { get; set; }

        public int AttackSpeed { get; set; }

        public int DPS { get; set; }

        public string AttackEffect { get; set; }

        public string AttackEffect2 { get; set; }

        public string HitEffect { get; set; }

        public string Projectile { get; set; }

        public bool AirTargets { get; set; }

        public bool GroundTargets { get; set; }

        public bool MultiTargets { get; set; }

        public int NumMultiTargets { get; set; }

        public int PushBack { get; set; }

        public int DieDamage { get; set; }

        public int DieDamageRadius { get; set; }

        public string DieDamageEffect { get; set; }

        public int DieDamageDelay { get; set; }

        public string DieDamageSpell { get; set; }

        public int StrengthWeight { get; set; }

        public string ActivationEffect { get; set; }
    }
}
