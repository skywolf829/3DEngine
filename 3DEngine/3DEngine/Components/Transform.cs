﻿using System;
using Microsoft.Xna.Framework;
using _3DEngine.GameObjects;

namespace _3DEngine.Components
{
    public class Transform : Component
    {
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
            get
            {
                Vector3 result = new Vector3(0, 0, -1);

                return result;
            }
        }
        public Vector3 left
        {
            get
            {
                Vector3 result = new Vector3(-1, 0, 0);

                return result;
            }
        }
        public Vector3 right
        {
            get
            {
                Vector3 result = new Vector3(1, 0, 0);

                return result;
            }
        }
        public Vector3 forward
        {
            get
            {
                Vector3 result = new Vector3(0, 1, 0);

                return result;
            }
        }
        public Vector3 back
        {
            get
            {
                Vector3 result = new Vector3(0, -1, 0);

                return result;
            }
        }
        private Matrix eulerMatrix {
            get
            {
                if (!this.EulerMatrixUpToDate)
                {

                 
                    lastEulerMatrix = EulerRotationMatrix(eulerAngles);
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
      
        public Matrix EulerRotationMatrix(Vector3 eulerAngles)
        {
            //euler.X = alpha, euler.Y = beta, euler.Z = gamme
            float sinAlpha = (float)Math.Sin(eulerAngles.X);
            float cosAlpha = (float)Math.Cos(eulerAngles.X);

            float sinBeta = (float)Math.Sin(eulerAngles.Y);
            float cosBeta = (float)Math.Cos(eulerAngles.Y);

            float sinGamma = (float)Math.Sin(eulerAngles.Z);
            float cosGamma = (float)Math.Cos(eulerAngles.Z);


            Vector4 row1 = new Vector4(cosBeta*cosGamma, cosGamma * sinAlpha * sinBeta - cosAlpha * sinGamma, cosAlpha * cosGamma * sinBeta + sinAlpha * sinGamma, 0);
            Vector4 row2 = new Vector4(cosBeta * sinGamma, cosAlpha * cosGamma + sinAlpha * sinBeta * sinGamma, -cosGamma * sinAlpha +cosAlpha * sinBeta * sinGamma, 0);
            Vector4 row3 = new Vector4(-sinBeta, cosBeta * sinAlpha, cosAlpha * cosBeta, 0);
            Vector4 row4 = new Vector4(0,0,0,1);
            Matrix result = new Matrix(row1,row2,row3,row4);
            return Matrix.CreateFromYawPitchRoll(eulerAngles.X, eulerAngles.Y, eulerAngles.Z);
            return (result);
        }
        private Vector3 EulerRotationFromDirection(Vector3 dir)
        {
            float theta_x;
            float theta_y;
            float theta_z;

            if (dir.X == 0)
            {
                theta_y = 0;
                theta_z = 0;
            }
            else
            {
                theta_y = (float)Math.Atan(dir.Z / dir.X);
                theta_z = (float)Math.Atan(dir.Y / dir.X);
            }
            if (dir.Z == 0)
            {
                theta_x = 0;
            }
            else
            {
                theta_x = (float)Math.Atan(dir.Y / dir.Z);
            }

            return new Vector3(theta_x, theta_y, theta_z);
        }
    }
}
