namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;

    public interface ISpecialty
    {
        Image Image { get; }

        Point FrameSize { get; }

        Vector2 Position { get; set; }
        
        int Damage { get; }
        
    }
}
