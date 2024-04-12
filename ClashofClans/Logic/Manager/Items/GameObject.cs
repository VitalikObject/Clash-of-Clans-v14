using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json.Linq;

namespace ClashofClans.Logic.Manager.Items
{
    public class GameObject
    {
        public List<Component> Components;

        public Home.Home Home;
        public Vector2 Position;

        public GameObject(Home.Home home)
        {
            Home = home;
            Position = Vector2.Zero;
            Components = new List<Component>();
        }

        public virtual JObject Save()
        {
            var jObject = new JObject
            {
                {"x", (int) Position.X},
                {"y", (int) Position.Y}
            };

            foreach (var component in Components)
                component.Save(jObject);

            return jObject;
        }

        public void AddComponent(Component component)
        {
            if (!Components.Contains(component))
                Components.Add(component);

            Home.ComponentManager.AddComponent(component);
        }

        public bool TryGetComponent(int type, out Component component)
        {
            component = Components.Find(t => t.Type == type);
            return component != null;
        }

        public virtual void Load(JObject jObject)
        {
            var x = jObject["x"].ToObject<int>();
            var y = jObject["y"].ToObject<int>();
            Position = new Vector2(x, y);

            foreach (var component in Components)
                component.Load(jObject);
        }

        public virtual void FastForward(int seconds)
        {
            foreach (var component in Components) component.FastForward(seconds);
        }

        public virtual void Tick()
        {
            foreach (var component in Components) component.Tick();
        }
    }
}