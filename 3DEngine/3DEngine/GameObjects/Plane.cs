﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Components;

namespace _3DEngine.GameObjects
{
    class Plane : GameObject
    {
        public Plane()
        {
            modelName = "Plane";
            AddComponent<Transform>();
            AddComponent<Rigidbody>();
        }
    }
}
