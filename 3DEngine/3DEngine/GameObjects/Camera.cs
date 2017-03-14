using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3DEngine.Physics;

namespace _3DEngine.GameObjects
{
    public class Camera : GameObject
    {
        public float nearClipping;
        public float farClipping;

        public Vector3 focusLocation { get; set; }

        public Camera()
        {
            transform = new Transform(this);
        }
        public Matrix ViewMatrix
        {
            get
            {
                return Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f),
                    Scene.Instance.GraphicsDevice.Viewport.AspectRatio,
                    nearClipping, farClipping);
            }
        }

        public Matrix ProjectionMatrix
        {
            get { return Matrix.CreateLookAt(transform.position, focusLocation, transform.up); }
        }

        public override void Update(float elapsed)
        {

        }
    }
}