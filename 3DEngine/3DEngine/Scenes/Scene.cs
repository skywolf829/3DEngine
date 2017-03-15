using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3DEngine.Components;
using _3DEngine.GameObjects;
using _3DEngine.Scripts;

namespace _3DEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Scene : Game
    {
        private static Scene instance;

        public static Scene Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scene();
                }
                return instance;
            }
        }

        GraphicsDeviceManager graphics;
        public List<GameObject> gameObjects;
        public GameObject mainCamera;
        public float elapsed;

        public Scene()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gameObjects = new List<GameObject>();
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            mainCamera = new MainCamera();
            gameObjects.Add(new Pencil());
            gameObjects.Add(new GameObjects.Plane());
            gameObjects.Add(mainCamera);
            InitializeObjects();
            base.Initialize();
        }

        private void InitializeObjects()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Initialize();
            }
            ScriptedStarts();
        }

        private void ScriptedStarts()
        {
            mainCamera.AddComponent<CameraMovement>();
            mainCamera.GetComponent<Transform>().position = new Vector3(0, 0, 0);
            GameObject.FindObjectWithName("Pencil").GetComponent<Transform>().position.Z += .75f;
            GameObject.FindObjectWithName("Pencil").GetComponent<Transform>().eulerAngles = new Vector3(0, 0, (float)(Math.PI / 2.0f));

            GameObject.FindObjectWithName("Plane").GetComponent<Transform>().scale = 100;
        }
        protected override void LoadContent()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Load(Content);
            }
        }
        
        protected override void UnloadContent()
        {
        }
       
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
            foreach (GameObject g in gameObjects)
            {
                g.Update();
            }
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (GameObject g in gameObjects)
            {
                g.Draw(mainCamera.GetComponent<Camera>().ViewMatrix, 
                    mainCamera.GetComponent<Camera>().ProjectionMatrix);
            }

            base.Draw(gameTime);
        }
    }
}
