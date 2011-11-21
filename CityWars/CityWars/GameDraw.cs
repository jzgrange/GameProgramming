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
    class GameDraw
    {
        public void DrawText(SpriteBatch spriteBatch, SpriteFont font, float cannonAngle, int cannonPower)
        {
            double cannonAng = (-cannonAngle * 57.3)+30;
            spriteBatch.DrawString(font, "Cannon angle: " +cannonAng.ToString(), new Vector2(20, 20), Color.Yellow);
            spriteBatch.DrawString(font, "Cannon Power: " + cannonPower.ToString(), new Vector2(20, 40), Color.Yellow);
        }

        public void DrawBuildings(BuildingData[] playerBuildings, int numberOfBuildings, SpriteBatch spriteBatch, Texture2D buildingTexture)
        {
            for (int i = 0; i < numberOfBuildings; i++)
            {
                if (playerBuildings[i].IsAlive)
                {
                    spriteBatch.Draw(buildingTexture, playerBuildings[i].Position, null, Color.Yellow, 0, new Vector2(0, buildingTexture.Height), (playerBuildings[i].Size), SpriteEffects.None, 0);
                }
            }

        }

        public void DrawEnemyBuildings(BuildingData[] enemyBuildings, int numberOfBuildings, SpriteBatch spriteBatch, Texture2D buildingTexture)
        {
            foreach (BuildingData enemyBuilding in enemyBuildings)
            {
                if (enemyBuilding.IsAlive)
                {
                    spriteBatch.Draw(buildingTexture, enemyBuilding.Position, null, Color.Red, 0, new Vector2(0, buildingTexture.Height), (enemyBuilding.Size), SpriteEffects.None, 0);
                }

            }
        }

        public void DrawScenery(Texture2D backgroundTexture, Texture2D foregroundTexture, int screenWidth, int screenHeight, SpriteBatch spriteBatch)
        {

            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            spriteBatch.Draw(foregroundTexture, screenRectangle, Color.White);

        }

        public void DrawWeapon(Texture2D cannonTexture, Vector2 cannonOrigin, int xPos, int yPos,float playerScaling, SpriteBatch spriteBatch, float cannonAngle)
        {
            spriteBatch.Draw(cannonTexture, new Vector2(xPos, yPos), null, Color.White, cannonAngle, cannonOrigin, playerScaling, SpriteEffects.None, 1);
        }

    }
}
