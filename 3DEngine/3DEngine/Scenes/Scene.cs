using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3DEngine.Components;
using _3DEngine.GameObjects;

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
        public static float elapsed;

        public Scene()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gameObjects = new List<GameObject>();
        }
        protected override void Initialize()
        {
            base.Initialize();
            mainCamera = new MainCamera();
            gameObjects.Add(new Pencil());
            gameObjects.Add(new GameObjects.Plane());
            gameObjects.Add(mainCamera);
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Initialize();
            }
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
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (GameObject g in gameObjects)
            {
                g.Draw(mainCamera.GetComponent<Transform>().position, mainCamera.GetComponent<Camera>().ViewMatrix, 
                    mainCamera.GetComponent<Camera>().ProjectionMatrix);
            }
        }
    }
}
