#region Using Statements
using System;

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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tex;
        Vector2 position;
        Vector2 velocity;

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
            position = new Vector2(100, 100);
            velocity = new Vector2(100, 100);
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
            tex = Content.Load<Texture2D>("manOld_stand");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

           if(position.Y > graphics.GraphicsDevice.Viewport.Height - tex.Height || position.Y < 0) velocity.Y = -velocity.Y;
           if(position.X > graphics.GraphicsDevice.Viewport.Width - tex.Width || position.X < 0) velocity.X = -velocity.X;

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

            spriteBatch.Draw(tex, position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
