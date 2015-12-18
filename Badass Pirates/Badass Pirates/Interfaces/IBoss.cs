namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Enums;
    using Badass_Pirates.Objects;

    using Microsoft.Xna.Framework;

    public interface IBoss : ICreature
    {
        Vector2 Speed { get; set; }

        void Sink();
    }
}
