using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sandbox
{
    public class BouncingBall : GameObject
    {
        Vector2 velocity;
        Vector2 screenSize;

        Random rand;

        public BouncingBall(Texture2D t, Vector2 p, Vector2 s) : base(t, p)
        {
            rand = new Random();

            velocity = new Vector2(rand.Next(-101,101), rand.Next(-101,101));
            screenSize = s;
        }


        public override void Update(GameTime gameTime)
        {

            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.Y > screenSize.Y - texture.Height || position.Y < 0) velocity.Y = -velocity.Y;
            if (position.X > screenSize.X - texture.Width || position.X < 0) velocity.X = -velocity.X;

            base.Update(gameTime);
        }
    }
}
