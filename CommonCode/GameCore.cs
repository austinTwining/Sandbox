#region Using Statements
using System;
using System.Collections;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Sandbox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    ///

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

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameObjects = new ArrayList();
            screenSize = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //TODO: use this.Content to load your game content here
            for(int i = 0; i < 10; i++)
            {
                gameObjects.Add(new BouncingBall(Content.Load<Texture2D>("manOld_stand"), new Vector2(rand.Next(1, (int)screenSize.X), rand.Next(1, (int)screenSize.Y)), screenSize));
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (BouncingBall g in gameObjects)
            {
                g.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach(GameObject g in gameObjects)
            {
                g.Draw(spriteBatch, gameTime);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
