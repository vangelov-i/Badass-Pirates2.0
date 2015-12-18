namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;

    public interface IBall
    {
        Image Image { get; set; }

        Vector2 Position { get; set; }

        Point FrameSize { get; set; }

        Vector2 BallFiredPos { get; set; }
    }
}
