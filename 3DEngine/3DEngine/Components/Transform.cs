using System;
using Microsoft.Xna.Framework;
using _3DEngine.GameObjects;

namespace _3DEngine.Components
{
    public class Transform : Component
    {
        public GameObject gameObject;
        public Vector3 eulerAngles;
        public Vector3 position;
        private bool EulerMatrixUpToDate = false;
        private Matrix lastEulerMatrix;
        public float scale = 1f;

        public Vector3 up
        {
            get
            {
                Vector3 result = new Vector3(0, 0, 1);

                return result;
            }
        }
        public Vector3 down
        {
            get;
        }
        public Vector3 left
        {
            get;
        }
        public Vector3 right
        {
            get;
        }
        public Vector3 forward
        {
            get;
        }
        public Vector3 back
        {
            get;
        }
        private Matrix eulerMatrix {
            get
            {
                if (!this.EulerMatrixUpToDate)
                {

                 
                    lastEulerMatrix = eulerRotationMatrix(eulerAngles);
                    EulerMatrixUpToDate = true;
                }
                return lastEulerMatrix;
            }
        }
       
        public Transform (GameObject g) : base(g)
        {

        }
        public override void Initialize()
        {

        }
        public override void Update()
        {

        }
      
        public Matrix eulerRotationMatrix(Vector3 eulerAngles)
        {
            //euler.X = alpha, euler.Y = beta, euler.Z = gamme
            float sinAlpha = (float)Math.Sin(eulerAngles.X);
            float cosAlpha = (float)Math.Cos(eulerAngles.X);

            float sinBeta = (float)Math.Sin(eulerAngles.Y);
            float cosBeta = (float)Math.Cos(eulerAngles.Y);

            float sinGamma = (float)Math.Sin(eulerAngles.Z);
            float cosGamma = (float)Math.Cos(eulerAngles.Z);


            Vector4 row1 = new Vector4(cosBeta*cosGamma, cosGamma * sinAlpha * sinBeta - cosAlpha * sinGamma,cosAlpha * cosGamma * sinBeta + sinAlpha * sinGamma, 0);
            Vector4 row2 = new Vector4(cosBeta * sinGamma, cosAlpha * cosGamma + sinAlpha * sinBeta * sinGamma, (-1f) * cosGamma * sinAlpha +cosAlpha * sinBeta * sinGamma, 0);
            Vector4 row3 = new Vector4((-1f) * sinBeta, cosBeta * sinAlpha, cosAlpha * cosBeta, 0);
            Vector4 row4 = new Vector4(0,0,0,1);
            Matrix result = new Matrix(row1,row2,row3,row4);
            return (result);
        }
    }
}
