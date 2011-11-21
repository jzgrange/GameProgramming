using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CityWars
{
    public struct BuildingData
    {
        public Vector2 Position;
        public bool IsAlive;
        public float Angle;
        public float Power;
        public float Size;
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class DrawGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D backgroundTexture; //background Texture
        Texture2D foregroundTexture;
        int screenWidth; //used to render background to screen
        int screenHeight;
        BuildingData[] playerBuildings;
        BuildingData[] enemyBuildings;
        int numberOfBuildings = 4;
        Texture2D buildingTexture;
        Texture2D cannonTexture;


        public DrawGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "CityWars!";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            backgroundTexture = Content.Load<Texture2D>("CitiBkg");
            foregroundTexture = Content.Load<Texture2D>("foreground");
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            buildingTexture = Content.Load<Texture2D>("newbuilding");
            cannonTexture = Content.Load<Texture2D>("cannon");

            SetUpPlayer();
            SetUpEnemy();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void DrawGame(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawScenery();
            DrawBuildings();
            DrawEnemyBuildings();
            spriteBatch.End();

            

            base.Draw(gameTime);
        }
        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

            spriteBatch.Draw(foregroundTexture, screenRectangle, Color.White);

        }

        private void DrawBuildings()
        {
            foreach (BuildingData playerBuilding in playerBuildings)
            {
                if (playerBuilding.IsAlive)
                {
                    spriteBatch.Draw(buildingTexture, playerBuilding.Position, null, Color.Yellow, 0, new Vector2(0, buildingTexture.Height), (playerBuilding.Size), SpriteEffects.None, 0);
                }
            }

        }


        private void DrawEnemyBuildings()
        {
            foreach (BuildingData enemyBuilding in enemyBuildings)
            {
                if (enemyBuilding.IsAlive)
                {
                    spriteBatch.Draw(buildingTexture, enemyBuilding.Position, null, Color.Red, 0, new Vector2(0, buildingTexture.Height), (enemyBuilding.Size), SpriteEffects.None, 0);
                }

            }
        }

        private void SetUpPlayer()
        {
   
            playerBuildings = new BuildingData[numberOfBuildings];
            for (int i = 0; i < numberOfBuildings; i++)
            {
                playerBuildings[i].IsAlive = true;
                playerBuildings[i].Angle = MathHelper.ToRadians(90);
                playerBuildings[i].Power = 100;
                playerBuildings[i].Size = 0.7f;
            }
            playerBuildings[0].Position = new Vector2(77, 393);
            playerBuildings[1].Position = new Vector2(50, 393);
            playerBuildings[2].Position = new Vector2(105, 393);
            playerBuildings[3].Position = new Vector2(27, 393);
            playerBuildings[0].Size = (0.5f);

        }

        private void SetUpEnemy()
        {
            enemyBuildings = new BuildingData[numberOfBuildings];
            for(int i = 0; i < numberOfBuildings; i++)
            {
                enemyBuildings[i].IsAlive = true;
                enemyBuildings[i].Angle = MathHelper.ToRadians(90);
                enemyBuildings[i].Power = 100;
                enemyBuildings[i].Size=0.7f;
            }
            enemyBuildings[0].Position = new Vector2(670,410);
            enemyBuildings[1].Position = new Vector2(700,410);
            enemyBuildings[2].Position = new Vector2(730,410);
            enemyBuildings[3].Position = new Vector2(760,410);
            enemyBuildings[2].Size = (0.6f);
 
        }
    }
}
