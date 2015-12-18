namespace Badass_Pirates.Factory
{
    using Badass_Pirates.Models.Mobs.Boss;

    public static class SpawnBoss
    {

        // TODO 
        public static void Spawn()
        {
            Boss.Instance.Initialise();
            Boss.Instance.LoadContent();
            Boss.Instance.Update();
        }
    }
}
