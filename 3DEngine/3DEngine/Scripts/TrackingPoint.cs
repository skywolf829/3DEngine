using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _3DEngine.Components;
using _3DEngine.GameObjects;

namespace _3DEngine.Scripts
{
    public class TrackingPoint : Component
    {
        public Vector3 Origin
        {
            get { return gameObject.GetComponent<Transform>().position; }
        }

        private Vector3 _initialDirection;
        public Vector3 InitialDirection
        {
            get { return _initialDirection; }
            set { _direction = _initialDirection = value; }
        }

        private Vector3 _direction { get; set; }
        public Vector3 Direction
        {
            get
            {
                Matrix dir = Matrix.Multiply(gameObject.GetComponent<Transform>().EulerRotationMatrix(gameObject.GetComponent<Transform>().eulerAngles), 
                    new Matrix(_initialDirection.X, 0, 0, 0, _initialDirection.Y, 0, 0, 0, _initialDirection.Z, 0, 0, 0, 0, 0, 0, 0));
                _direction = new Vector3(dir.M11, dir.M21, dir.M31);
                _direction.Normalize();
                return _direction;
            }
            set { _direction = value; }
        }

        public float Distance;

        public Color Color;

        public Vector3 Point
        {
            get
            {
                return Origin + (Direction * Distance);
            }
        }

        public TrackingPoint(GameObject g) : base(g)
        {
        }
    }
}
