using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.Components;
using _3DEngine.GameObjects;

namespace _3DEngine.Scripts
{
    public class TrackingPointDrawer : Component
    {
        private readonly GameObject[] _pencils;
        private readonly Plane _plane;
        public TrackingPointDrawer(GameObject g) : base(g)
        {
            _pencils = GameObject.FindGameObjectsWithTag("Pencils");
            _plane = (Plane)GameObject.FindGameObjectWithName("Plane");
        }


        public override void Update()
        {
            base.Update();
            foreach (GameObject g in _pencils)
            {
                foreach (TrackingPoint tp in g.GetComponents<TrackingPoint>())
                {
                    _plane.UpdateTexture(tp.Color, tp.Point);
                }
            }
        }
    }
}
