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
        public MainCamera()
        {
            AddComponent<Transform>();
            AddComponent<Camera>();
        }

    }
}
