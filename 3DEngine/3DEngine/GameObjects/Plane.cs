using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Components;

namespace _3DEngine.GameObjects
{
    class Plane : GameObject
    {
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
    }
}
