using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Components;

namespace _3DEngine.GameObjects
{
    class Pencil : GameObject
    {
        public Pencil() : base()
        {
            modelName = "Pencil";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }
        public Pencil(String n) : base(n)
        {
            modelName = "Pencil";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }
        public Pencil(String n, String t) : base(n, t)
        {
            modelName = "Pencil";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }
    }
}
