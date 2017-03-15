using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Components;

namespace _3DEngine.GameObjects
{
    public class MainCamera : GameObject
    {
        public MainCamera() : base()
        {
            AddComponent<Transform>();
            AddComponent<Camera>();
        }
        public MainCamera(String n) : base(n)
        {
            AddComponent<Transform>();
            AddComponent<Camera>();
        }
        public MainCamera(String n, String t) : base(n, t)
        {
            AddComponent<Transform>();
            AddComponent<Camera>();
        }
    }
}
