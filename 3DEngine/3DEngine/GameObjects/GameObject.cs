using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DEngine.Components;

namespace _3DEngine.GameObjects
{
    public class GameObject
    {
        protected List<Component> components;
        public Model model { get; protected set; }

        public String name, tag;

        protected string modelName;

        public GameObject()
        {
            components = new List<Component>();
        }
        public virtual void Initialize()
        {
            foreach (Component c in components)
            {
                c.Initialize();
            }
        }
        public virtual void Load(ContentManager content)
        {
            if (modelName != null)
            {
                model = content.Load<Model>(modelName);
                Console.WriteLine("Loaded model for " + name);
            }
        }

        public virtual void Update()
        {
            foreach(Component c in components) { c.Update(); }   
        }
        public void Draw(Matrix view, Matrix projection)
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
                        effect.PreferPerPixelLighting = true;
                        
                        effect.World = Matrix.CreateScale(GetComponent<Transform>().scale) *
                                       Matrix.CreateFromYawPitchRoll(GetComponent<Transform>().eulerAngles.X,
                                           GetComponent<Transform>().eulerAngles.Y,
                                           GetComponent<Transform>().eulerAngles.Z) *
                                       Matrix.CreateTranslation(GetComponent<Transform>().position);
                                       
                        effect.View = view;
                        effect.Projection = projection;
                        
                    }
                    // Draw the mesh, using the effects set above.
                    mesh.Draw();
                }
            }
        }

        public T GetComponent<T>() where T : Component
        {
            Component component = null;
            foreach (Component c in components)
            {
                if (c.GetType().Equals(typeof(T)))
                {
                    component = c;
                    break;
                }
            }
            return (T)component;
        }

        public T AddComponent<T>() where T : Component
        {
            Component c = (T)Activator.CreateInstance(typeof(T), new object[] {this});
            components.Add(c);
            c.Initialize();
            return (T)c;
        }

        public static GameObject FindObjectWithName(String s)
        {
            GameObject g = null;
            foreach (GameObject obj in Program.Game.gameObjects)
            {
                if (obj.name.Equals(s))
                {
                    g = obj;
                    break;
                }
            }
            return g;
        }
    }
}
