using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DEngine.GameObjects
{
    public abstract class GameObject
    {
        public Transform transform { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public Model model { get; private set; }

        public String name, tag;

        protected string modelName;

        public virtual void Initialize()
        {
            
        }
        public virtual void Load(ContentManager content)
        {
            if(modelName != "")
                model = content.Load<Model>(modelName);
        }
        public abstract void Update(float elapsed);
        public void Draw(Vector3 cameraPosition, Matrix view, Matrix projection)
        {
            if (model != null)
            {
                // Copy any parenttransforms.
                Matrix[] transforms = new Matrix[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(transforms);
                // Draw the model. A model can have multiple meshes, so loop.
                foreach (ModelMesh mesh in model.Meshes)
                {
                    // This is where the mesh orientation is set, as well 
                    // as our camera and projection.
                    foreach (BasicEffect effect in mesh.Effects)
                    {

                        effect.EnableDefaultLighting();
                        effect.World = Matrix.CreateScale(transform.scale) *
                                       Matrix.CreateFromYawPitchRoll(transform.CurrentEulerRot.X,
                                           transform.CurrentEulerRot.Y,
                                           transform.CurrentEulerRot.Z) *
                                       Matrix.CreateTranslation(transform.CurrentPosition);
                        effect.View = view;
                        effect.Projection = projection;
                    }
                    // Draw the mesh, using the effects set above.
                    mesh.Draw();
                }
            }
        }
    }
}
