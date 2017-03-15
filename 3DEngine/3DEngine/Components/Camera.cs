using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3DEngine.Components;

namespace _3DEngine.GameObjects
{
    public class Camera : Component
    {
        public float nearClipping;
        public float farClipping;

        public Vector3 focusLocation { get; set; }

        public Camera(GameObject g) : base(g)
        {
            nearClipping = 1f;
            farClipping = 10000;
        }
        public Matrix ViewMatrix
        {
            get
            {
                return Matrix.CreateLookAt(gameObject.GetComponent<Transform>().position,
                focusLocation, gameObject.GetComponent<Transform>().up);
            }
        }

        public Matrix ProjectionMatrix
        {
            get {
                return Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f),
                        Program.Game.GraphicsDevice.Viewport.AspectRatio,
                        nearClipping, farClipping);
            }
        }

        public override void Update()
        {
            base.Update();
        }
    }
}