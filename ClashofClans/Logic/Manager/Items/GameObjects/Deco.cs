using ClashofClans.Files;
using ClashofClans.Files.Logic;
using Newtonsoft.Json.Linq;

namespace ClashofClans.Logic.Manager.Items.GameObjects
{
    public class Deco : GameObject
    {
        public int Data;
        public int Id;

        public Deco(Home.Home home) : base(home)
        {
        }

        public Decos DecoData => Csv.Tables.Get(Csv.Files.Decos).GetDataWithId<Decos>(Data);

        public override void Load(JObject jObject)
        {
            base.Load(jObject);

            Data = jObject["data"].ToObject<int>();
        }

        public override JObject Save()
        {
            var jObject = base.Save();

            jObject.Add("data", Data);
            jObject.Add("id", Id);

            return jObject;
        }
    }
}