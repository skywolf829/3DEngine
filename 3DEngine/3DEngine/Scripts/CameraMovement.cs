using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using _3DEngine.Components;
using _3DEngine.GameObjects;

namespace _3DEngine.Scripts
{
    public class CameraMovement : Component
    {
        private float moveSpeed = 20;
        private bool focusOnCenter = false;
        private bool lastFState = false;

        public CameraMovement(GameObject g) : base(g)
        {

        }

        public override void Update()
        {
            base.Update();

            UpdateMovement();
            UpdateCameraFocus();
        }

        public void UpdateCameraFocus()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F) && !lastFState)
            {
                lastFState = true;
                focusOnCenter = !focusOnCenter;
            }
            if(!Keyboard.GetState().IsKeyDown(Keys.F))
            {
                lastFState = false;
            }
            if (focusOnCenter)
                gameObject.GetComponent<Camera>().focusLocation = Vector3.Zero;
            else gameObject.GetComponent<Camera>().focusLocation = gameObject.GetComponent<Transform>().position + gameObject.GetComponent<Transform>().forward;

        }
        public void UpdateMovement()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                gameObject.GetComponent<Transform>().position += gameObject.GetComponent<Transform>().left * Program.Game.elapsed * moveSpeed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                gameObject.GetComponent<Transform>().position += gameObject.GetComponent<Transform>().right * Program.Game.elapsed * moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                gameObject.GetComponent<Transform>().position += gameObject.GetComponent<Transform>().forward * Program.Game.elapsed * moveSpeed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                gameObject.GetComponent<Transform>().position += gameObject.GetComponent<Transform>().back * Program.Game.elapsed * moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                gameObject.GetComponent<Transform>().position += gameObject.GetComponent<Transform>().up * Program.Game.elapsed * moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                gameObject.GetComponent<Transform>().position += gameObject.GetComponent<Transform>().down * Program.Game.elapsed * moveSpeed;
            }
        }
    }
}
