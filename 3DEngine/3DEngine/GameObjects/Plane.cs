using System;
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
    class Plane : GameObject
    {

        private Texture2D texture;
        private Color[] colors;
        private int resolution;

        public int Resolution
        {
            get { return resolution; }
            set
            {
                resolution = value;
                colors = new Color[resolution * resolution];
                for (int i = 0; i < resolution * resolution; i++)
                {
                    colors[i] = Color.Yellow;
                }
            }
        }

        public Plane() : base()
        {
            modelName = "Plane";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }
        public Plane(String n) : base(n)
        {
            modelName = "Plane";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }
        public Plane(String n, String t) : base(n, t)
        {
            modelName = "Plane";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Initialize()
        {
            base.Initialize();
            Resolution = 1000;
        }

        public override void Load(ContentManager content)
        {
            base.Load(content);
            texture = new Texture2D(Program.Game.GraphicsDevice, resolution, resolution);
            texture.SetData(colors);
        }

        public override void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.TextureEnabled = true;
                    effect.Texture = texture;

                    effect.World = Matrix.CreateScale(GetComponent<Transform>().scale) *
                        Matrix.CreateFromYawPitchRoll(GetComponent<Transform>().eulerAngles.X, 
                        GetComponent<Transform>().eulerAngles.Y, GetComponent<Transform>().eulerAngles.Z) *
                         Matrix.CreateTranslation(GetComponent<Transform>().position);
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }
        public void UpdateTexture(Color c, Vector3 point)
        {
            int row = (int)(((point.Y + 100) / 200.0f) * resolution);
            int column = (int)(((point.X + 100) / 200.0f) * resolution);
            if (resolution * row + column < resolution * resolution)
                colors[resolution * row + column] = c;
            texture.SetData(colors);
        }
    }
}
