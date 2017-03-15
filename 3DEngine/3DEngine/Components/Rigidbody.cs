using Microsoft.Xna.Framework;
using _3DEngine.GameObjects;

namespace _3DEngine.Components
{
    public class Rigidbody : Component
    {
        public Vector3 velocity;
        public Vector3 angularVelocity;
        public Vector3 inertialTensor;
        public float angularDrag;
        public float mass;
        public float gravity = 9.8f;

        public Rigidbody(GameObject obj) : base(obj)
        {

        }

        public override void Initialize()
        {
            
        }
        public override void Update()
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
