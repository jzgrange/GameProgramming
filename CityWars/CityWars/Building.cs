using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CityWars
{
    class Building
    {
        //public struct BuildingData
        //{
        //    public Vector2 Position;
        //    public bool IsAlive;
        //    public float Angle;
        //    public float Power;
        //    public float Size;
        //}

        public void SetUpPlayer(BuildingData[] playerBuildings, int numberOfBuildings)
        {

            for (int i = 0; i < numberOfBuildings; i++)
            {
                playerBuildings[i].IsAlive = true;
                playerBuildings[i].Size = 0.7f;
            }
            playerBuildings[0].Position = new Vector2(77, 393);
            playerBuildings[1].Position = new Vector2(50, 393);
            playerBuildings[2].Position = new Vector2(105, 393);
            playerBuildings[3].Position = new Vector2(27, 393);
            for (int i =0; i<numberOfBuildings;i++)
            {
                playerBuildings[i].Size = (0.5f);
            }
        }

        public void SetUpEnemy( BuildingData[] enemyBuildings, int numberOfBuildings)
        {
            //enemyBuildings = new BuildingData[numberOfBuildings];
            for (int i = 0; i < numberOfBuildings; i++)
            {
                enemyBuildings[i].IsAlive = true;
            }
            enemyBuildings[0].Position = new Vector2(670, 410);
            enemyBuildings[1].Position = new Vector2(700, 410);
            enemyBuildings[2].Position = new Vector2(730, 410);
            enemyBuildings[3].Position = new Vector2(760, 410);
            enemyBuildings[2].Size = (0.6f);
            for (int i = 0; i < numberOfBuildings; i++)
            {
                enemyBuildings[i].Size = (0.5f);
            }

        }
    }
}
