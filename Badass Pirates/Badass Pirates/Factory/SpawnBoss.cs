namespace Badass_Pirates.Factory
{
    using Badass_Pirates.GameObjects.Mobs.Boss;

    public static class SpawnBoss
    {

        // TODO 
        public static void Spawn()
        {
            Boss.Initialise();
            Boss.LoadContent();
            Boss.Update();
        }
    }
}
