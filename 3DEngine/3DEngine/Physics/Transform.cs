using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DEngine.GameObjects;
using Microsoft.Xna.Framework;

namespace _3DEngine.Physics
{
    public class Transform
    {
        public GameObject gameObject;
        public Vector3 eulerAngles;
        private Matrix eulertMatrix;
        private bool EulerMatrixUpToDate = false;

        public Transform (GameObject g)
        {
            gameObject = g;
        }


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
        public void updateEulerMatrix()
        {
            eulertMatrix = eulerRotationMatrix(eulerAngles);
            EulerMatrixUpToDate = true;
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
