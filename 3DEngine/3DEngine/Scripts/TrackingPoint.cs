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

        private Vector3 direction;
        public Vector3 Direction
        {
            get
            {
                direction.Normalize();
                return direction;
            }
            set { direction = value; }
        }

        public float Distance;

        public Color Color;

        public Vector3 Point
        {
            get
            {
                Direction.Normalize();
                return Origin + (Direction * Distance);
            }
        }

        public TrackingPoint(GameObject g) : base(g)
        {
        }
    }
}
