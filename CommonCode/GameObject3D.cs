using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sandbox
{
    public class GameObject3D
    {
        public Model model;
        public Vector3 position;

        private Matrix world;

        public GameObject3D(Model m, Vector3 p)
        {
            model = m;
            position = p;

            world = Matrix.CreateTranslation(position);
        }

        public virtual void Update(GameTime gameTime)
        {
            world = Matrix.CreateTranslation(position);
        }

        public virtual void Draw(Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.AmbientLightColor = new Vector3(1f, 0, 0);
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}
