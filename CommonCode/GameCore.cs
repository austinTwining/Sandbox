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

        //test 3D Code
        private Model model;

        private Matrix world;
        private Matrix view;
        private Matrix projection;

        Vector3 position;

        public GameCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            gameObjects = new ArrayList();
            screenSize = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);

            //test 3D Code
            world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenSize.X / screenSize.Y, 0.1f, 100f);

            position = new Vector3(0, 0, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //test 3D Code
            model = Content.Load<Model>("toilet");

            gameObjects.Add(new Player(Content.Load<Texture2D>("emote_faceAngry"), new Vector2(300, 300)));
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (GameObject g in gameObjects) g.Update(gameTime);

            //test 3D Code
            position += new Vector3(0, 0.01f, 0);
            world = Matrix.CreateTranslation(position);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach(GameObject g in gameObjects) g.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            //test 3D Code
            DrawModel(model, world, view, projection);

            base.Draw(gameTime);
        }

        //test 3D Code
        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}
