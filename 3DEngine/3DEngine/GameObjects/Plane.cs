using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Physics;

namespace _3DEngine.GameObjects
{
    class Plane : GameObject
    {
        public Plane()
        {
            modelName = "Plane";
            transform = new Transform(this);
            rigidbody = new Rigidbody(this);
        }
        public override void Update(float elapsed)
        {

        }
    }
}
