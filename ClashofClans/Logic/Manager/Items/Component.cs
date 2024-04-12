using Newtonsoft.Json.Linq;

namespace ClashofClans.Logic.Manager.Items
{
    public class Component
    {
        public Component(GameObject gameObject)
        {
            Parent = gameObject;
        }

        public GameObject Parent { get; }
        public int Type { get; set; }

        public virtual void Load(JObject jObject)
        {
        }

        public virtual JObject Save(JObject jObject)
        {
            return jObject;
        }

        public virtual void FastForward(int seconds)
        {
        }

        public virtual void Tick()
        {
        }
    }
}