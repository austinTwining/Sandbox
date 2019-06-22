using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sandbox
{
    public class Player : GameObject
    {
        public Player(Texture2D t, Vector2 p) : base(t, p) {}

        private KeyboardState keyState { get => Keyboard.GetState(); }
        private int speed = 3;

        public override void Update(GameTime gameTime)
        {
            if (keyState.IsKeyDown(Keys.W)) position.Y -= speed;
            if (keyState.IsKeyDown(Keys.A)) position.X -= speed;
            if (keyState.IsKeyDown(Keys.S)) position.Y += speed;
            if (keyState.IsKeyDown(Keys.D)) position.X += speed;
        }
    }
}
