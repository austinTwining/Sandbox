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

        Camera cam;

        //BasicEffect for rendering
        BasicEffect basicEffect;

        public GameCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            gameObjects = new ArrayList();
            screenSize = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            Mouse.SetPosition((int)screenSize.X / 2, (int)screenSize.Y / 2);

            cam = new Camera(this, new Vector3(0f, 0f, 0f), Vector3.Zero, 10f);
            Components.Add(cam);

            //BasicEffect
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;

            // Want to see the colors of the vertices, this needs to be on
            basicEffect.VertexColorEnabled = true;

            //Lighting requires normal information which VertexPositionColor does not have
            //If you want to use lighting and VPC you need to create a custom def
            basicEffect.LightingEnabled = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameObjects.Add(new GameObject3D(Content.Load<Model>("MonoCube"), new Vector3(0, 0, 5)));
            gameObjects.Add(new GameObject3D(Content.Load<Model>("MonoCube"), new Vector3(5, 0, 5)));
            gameObjects.Add(new GameObject3D(Content.Load<Model>("MonoCube"), new Vector3(-5, 5, 5)));
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (GameObject3D g in gameObjects) g.Update(gameTime);

            cam.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //2D rendering
            spriteBatch.End();

            //3D game object rendering
            foreach (GameObject3D g in gameObjects) g.Draw(cam.View, cam.Projection);

            base.Draw(gameTime);
        }
    }
}
