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
        public float Size;
    }
    /// <summary>
    /// This is the main type for the game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public GraphicsDevice device;
        public Texture2D backgroundTexture; //background Texture
        public Texture2D foregroundTexture;
        int screenWidth; //used to render background to screen
        int screenHeight;
        public BuildingData[] playerBuildings;
        public BuildingData[] enemyBuildings;
        int numberOfBuildings = 4;
        public Texture2D buildingTexture;
        public Texture2D cannonTexture;
        public float cannonAngle = 0;
        public int cannonPower = 0;
        private float playerScaling;

        SpriteFont font;


        int xPos = 20;
        int yPos = 393;
        Vector2 cannonOrigin = new Vector2(42, 130);

        Landscape landscape = new Landscape();
        Building buildings = new Building();
        GameDraw gameDraw = new GameDraw();
        GameController gameControl = new GameController();
   
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            playerBuildings = new BuildingData[numberOfBuildings]; //Creates player Building data strut
            enemyBuildings = new BuildingData[numberOfBuildings]; //creates enemey building data strut
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
            playerScaling = 100.0f / (float)cannonTexture.Width;
            font = Content.Load<SpriteFont>("gameFont");
            

            //playerBuildings = new BuildingData[numberOfBuildings]; //Creates player Building data strut
            //enemyBuildings = new BuildingData[numberOfBuildings]; //creates enemey building data strut

            buildings.SetUpPlayer((playerBuildings), numberOfBuildings);
            buildings.SetUpEnemy((enemyBuildings), numberOfBuildings);

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

           SetCannonAngle(gameControl.ProcessKeyboardAngle(cannonAngle));
           SetCannonPower(gameControl.ProcessKeyboardPower(cannonPower));

            base.Update(gameTime);
        }

        /// <summary>
        /// This initiates the Drawing of the game, the actually drawing will take place in GameDraw
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            gameDraw.DrawScenery(backgroundTexture, foregroundTexture, screenWidth, screenHeight, spriteBatch);
            gameDraw.DrawBuildings(playerBuildings,numberOfBuildings,spriteBatch,buildingTexture);
            gameDraw.DrawEnemyBuildings(enemyBuildings,numberOfBuildings,spriteBatch,buildingTexture);
            gameDraw.DrawWeapon(cannonTexture, cannonOrigin, xPos, yPos, playerScaling, spriteBatch, cannonAngle);
            gameDraw.DrawText(spriteBatch, font, cannonAngle,cannonPower);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetCannonAngle(float angle)
        {
            cannonAngle = cannonAngle + angle;
 
        }

        private void SetCannonPower(int power)
        {
            cannonPower = cannonPower + power;
        }

       
    }
}
