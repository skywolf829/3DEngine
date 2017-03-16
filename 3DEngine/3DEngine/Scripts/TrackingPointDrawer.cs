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
        private readonly GameObject[] pencils;
        private readonly Plane plane;
        public TrackingPointDrawer(GameObject g) : base(g)
        {
            pencils = GameObject.FindGameObjectsWithTag("Pencils");
            plane = (Plane)GameObject.FindGameObjectWithName("Plane");
        }


        public override void Update()
        {
            base.Update();
            foreach (GameObject g in pencils)
            {
                foreach (TrackingPoint tp in g.GetComponents<TrackingPoint>())
                {
                    plane.UpdateTexture(tp.Color, tp.Point);
                }
            }
        }
    }
}
