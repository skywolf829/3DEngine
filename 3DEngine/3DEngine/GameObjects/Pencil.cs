using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _3DEngine.Components;
using _3DEngine.Scripts;

namespace _3DEngine.GameObjects
{
    class Pencil : GameObject
    {
        public Pencil() : base()
        {
            modelName = "Pencil";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
            AddComponent<TrackingPoint>();
        }
        public Pencil(String n) : base(n)
        {
            modelName = "Pencil";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
            AddComponent<TrackingPoint>();
        }
        public Pencil(String n, String t) : base(n, t)
        {
            modelName = "Pencil";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
            AddComponent<TrackingPoint>();
        }

        public override void Update()
        {
            base.Update();
           

        }
    }
}
