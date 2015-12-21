namespace Badass_Pirates.Interfaces
{
    using System.Diagnostics;

    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;

    public interface IProjectile : IXnaDependencies
    {
        Image Image { get; set; }

        Vector2 Position { get; set; }

        Point FrameSize { get; set; }

        Vector2 BallFiredPos { get; set; }

        bool BallControler { get; set; }

        Image Fire { get; }

        bool BallFired { get; set; }

        int FireFlashCounter { get; set; }

        bool BallInitialised { get; set; }

        Stopwatch BallTimer { get; set; }

        Vector2 BallRangeX { get; set; }

        void SetPositionRangeX(float value);


    }
}
