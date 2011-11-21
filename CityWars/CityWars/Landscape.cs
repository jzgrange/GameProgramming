using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CityWars
{
    class Landscape
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

        public Landscape()
        {
 
        }
    }
}
