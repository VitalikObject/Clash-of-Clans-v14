namespace ClashofClans.Logic.Home.Slots
{
    public class ResourceSlots : DataSlots
    {
        /// <summary>
        ///     Sets the default resources to this dataslots
        /// </summary>
        public void InitializeDefault()
        {
            Set(3000001, 1000); // Gold
            Set(3000002, 1000); // Elixir
            Set(3000003, 0); // DarkElixir

            Set(3000007, 1000); // Gold2
            Set(3000008, 1000); // Elixir2

            Set(3000009, 1000); // Elixir2
        }

        /// <summary>
        ///     Sets the max resources to this dataslots
        /// </summary>
        public void Initialize()
        {
            Set(3000001, 1000000000); // Gold
            Set(3000002, 1000000000); // Elixir
            Set(3000003, 1000000000); // DarkElixir

            Set(3000007, 1000000000); // Gold2
            Set(3000008, 1000000000); // Elixir2

            Set(3000009, 1000000000); // Elixir2
        }
    }
}