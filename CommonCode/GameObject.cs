using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sandbox
{
    public class GameObject
    {
        public Texture2D texture;
        public Vector2 position;

        public GameObject(Texture2D t, Vector2 p)
        {
            texture = t;
            position = p;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            sb.Draw(texture, position, Color.White);
        }
    }
}
