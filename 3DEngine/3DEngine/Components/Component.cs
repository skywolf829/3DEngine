using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine;
using _3DEngine.GameObjects;

namespace _3DEngine.Components
{
    public abstract class Component
    {
        public GameObject gameObject { get; protected set; }

        protected Component(GameObject g)
        {
            gameObject = g;
        }

        public virtual void Initialize()
        {
            
        }
        public virtual void Update()
        {
            
        }

    }
}
