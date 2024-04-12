namespace ClashofClans.Logic.Manager.Items.Components
{
    public class UnitUpgradeComponent : Component
    {
        public UnitUpgradeComponent(GameObject gameObject) : base(gameObject)
        {
            Type = 9;
        }

        public Timer Timer;

        public override void Tick()
        {
            /*if (Timer.GetRemainingSeconds(Parent.Home.Time) <= 0)
            {
                // FINISH
            }*/
        }

        public override void FastForward(int seconds)
        {
            //Timer.FastForward(seconds);
        }
    }
}
