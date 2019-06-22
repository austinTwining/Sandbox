#region Using Statements
using System;
using System.Collections;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Sandbox
{

    public class GameCore : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ArrayList gameObjects;
        Vector2 screenSize;

        Random rand = new Random();

        public GameCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";	
        }

        protected override void Initialize()
        {
            gameObjects = new ArrayList();
            screenSize = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < 10; i++)
                gameObjects.Add(new BouncingBall(Content.Load<Texture2D>("emote_faceAngry"), new Vector2(rand.Next(1, (int)screenSize.X), rand.Next(1, (int)screenSize.Y)), screenSize));
            gameObjects.Add(new Player(Content.Load<Texture2D>("emote_faceAngry"), new Vector2(300, 300)));
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (GameObject g in gameObjects) g.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach(GameObject g in gameObjects) g.Draw(spriteBatch, gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
