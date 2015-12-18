namespace Badass_Pirates.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IBoss : ICreature
    {
        Vector2 Speed { get; set; }

        void Sink();
    }
}
