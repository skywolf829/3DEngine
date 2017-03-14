using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.GameObjects;

namespace _3DEngine.Physics
{
    public class Rigidbody
    {
        public GameObject gameObject;
        public Vector3 velocity;
        public Vector3 angularVelocity;
        public Vector3 inertialTensor;
        public float angularDrag;
        public float mass;
        public float gravity = 9.8f;

        public Rigidbody(GameObject obj)
        {
            gameObject = obj;
        }

        public void Update(float elapsed)
        {
            
        }

        public void AddForce(Vector3 force)
        {
            
        }

        public void AddForceAtPoint(Vector3 force, Vector3 point)
        {
            
        }
    }
}
