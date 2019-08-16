using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sandbox
{
    public class Camera : GameComponent
    {

        //attributes
        private Vector3 _position;
        private Vector3 _rotation;
        private float _speed;
        private Vector3 _camLookAt;

        //mouse attributes
        private Vector3 mouseRotationBuffer;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        //properties
        public Vector3 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                UpdateLookAt();
            }
        }

        public Vector3 Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                UpdateLookAt();
            }
        }

        public Matrix Projection
        {
            get;
            protected set;
        }

        public Matrix View
        {
            get
            {
                return Matrix.CreateLookAt(_position, _camLookAt, Vector3.Up);
            }
        }

        public Camera(Game game, Vector3 position, Vector3 rotation, float speed) : base(game)
        {
            _speed = speed;

            //setup projection matrix
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                Game.GraphicsDevice.Viewport.AspectRatio, 0.05f, 1000.0f);

            //set camera position and rotation
            MoveTo(position, rotation);

            previousMouseState = Mouse.GetState();
        }

        private void MoveTo(Vector3 position, Vector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        private void UpdateLookAt()
        {
            //build rotation matrix
            Matrix rotationMatrix = Matrix.CreateRotationX(_rotation.X) * Matrix.CreateRotationY(_rotation.Y);

            //build look at offset vector
            Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);

            //update camera's look at vector
            _camLookAt = _position + lookAtOffset;
        }

        private void Move(Vector3 amount)
        {
            //create rotation matrix
            Matrix rotate = Matrix.CreateRotationY(_rotation.Y);

            //create movement vector
            Vector3 movement = new Vector3(amount.X, amount.Y, amount.Z);
            movement = Vector3.Transform(movement, rotate);

            MoveTo(_position + movement, Rotation);
        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentMouseState = Mouse.GetState();

            KeyboardState ks = Keyboard.GetState();

            Vector3 moveVector = Vector3.Zero;

            //handle keyboard movement
            if (ks.IsKeyDown(Keys.W)) moveVector.Z = 1;
            if (ks.IsKeyDown(Keys.S)) moveVector.Z = -1;
            if (ks.IsKeyDown(Keys.A)) moveVector.X = 1;
            if (ks.IsKeyDown(Keys.D)) moveVector.X = -1;

            if(moveVector != Vector3.Zero)
            {
                //normalize vector, so that cam doesnt move faster diagonally
                moveVector.Normalize();

                //add in smooth vector and speed
                moveVector *= dt * _speed;

                Move(moveVector);
            }

            //handle mouse movement
            float deltaX;
            float deltaY;

            if(currentMouseState != previousMouseState)
            {
                //cache mouse location
                deltaX = currentMouseState.X - (Game.GraphicsDevice.Viewport.Width / 2);
                deltaY = currentMouseState.Y - (Game.GraphicsDevice.Viewport.Height / 2);

                //smooth mouse movement
                mouseRotationBuffer.X -= 0.5f * deltaX * dt;
                mouseRotationBuffer.Y -= 0.5f * deltaY * dt;

                Rotation = new Vector3(-MathHelper.Clamp(mouseRotationBuffer.Y, MathHelper.ToRadians(-75.0f), MathHelper.ToRadians(75.0f)),
                    MathHelper.WrapAngle(mouseRotationBuffer.X), 0);

                deltaX = 0;
                deltaY = 0;
            }

            Mouse.SetPosition(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);

            previousMouseState = currentMouseState;

            base.Update(gameTime);
        }
    }
}
