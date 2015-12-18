namespace Badass_Pirates.Interfaces
{
    using Badass_Pirates.Managers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    //TODO Make an XNA's METHODS CLASS
    public interface ISpecialty
    {
        Image Image { get; }

        Point FrameSize { get; }

        Vector2 Position { get; set; }
        
        int Damage { get; }

        void ActivateSpecialty(IPlayer instance);

        void Draw(SpriteBatch spriteBatch, Vector2 position);

        void Update(GameTime gameTime, IPlayer current);

        void UnloadContent();

        void LoadContent();

        void Initialise(Vector2 position);
    }
}
