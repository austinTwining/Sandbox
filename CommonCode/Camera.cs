using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sandbox
{
    public class Camera{
        public Vector3 camTarget;
        public Vector3 camPosition;
        public Matrix projection;
        public Matrix view;
        public Matrix world;

        //Orbit
        bool orbit = false;

        public Camera(float aspectRatio){

            camTarget = new Vector3(0f, 0f, 0f);
            camPosition = new Vector3(0f, 0f, -100f);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), aspectRatio, 1f, 1000f);
            view = Matrix.CreateLookAt(camPosition, camTarget, new Vector3(0f, 1f, 0f));// Y up
            world = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);

        }

        public void Update(GameTime gt){
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camPosition.X -= 1f;
                camTarget.X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camPosition.X += 1f;
                camTarget.X += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camPosition.Y -= 1f;
                camTarget.Y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                camPosition.Y += 1f;
                camTarget.Y += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                camPosition.Z += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {
                camPosition.Z -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                orbit = !orbit;
            }

            if (orbit)
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1f));
                camPosition = Vector3.Transform(camPosition, rotationMatrix);
            }

            view = Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);
        }
    }
}
