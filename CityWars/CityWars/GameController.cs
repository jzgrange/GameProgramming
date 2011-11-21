using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CityWars
{
    class GameController
    {
        public float ProcessKeyboardAngle(float cannonAngle)
        {
            KeyboardState keybState = Keyboard.GetState();
            if (keybState.IsKeyDown(Keys.Left))
            {
                cannonAngle = -0.01f;
                return cannonAngle;
            }
            if (keybState.IsKeyDown(Keys.Right))
            {
                cannonAngle = 0.01f;
                return cannonAngle;
            }
            if (cannonAngle > MathHelper.PiOver2)
            {
                cannonAngle = (-MathHelper.PiOver2);
                return cannonAngle;
            }
            if (cannonAngle < (-MathHelper.PiOver2))
            {
                cannonAngle = MathHelper.PiOver2;
                return cannonAngle;
            }
            else
                return 0;

        }
        public int ProcessKeyboardPower(int cannonPower)
        {
            KeyboardState keybState = Keyboard.GetState();

            if (keybState.IsKeyDown(Keys.Down))
            {
                cannonPower = -1;
                return cannonPower;
            }
            if (keybState.IsKeyDown(Keys.Up))
            {
                cannonPower = 1;
                return cannonPower;
            }

            if (keybState.IsKeyDown(Keys.PageDown))
            {
                cannonPower = -20;
                return cannonPower;
            }

            if (keybState.IsKeyDown(Keys.PageUp))
            {
                cannonPower = 20;
                return cannonPower;
            }

            if (cannonPower > 1000)
            {
                cannonPower = 1000;
                return cannonPower;
            }
            if (cannonPower < 0)
            {
                cannonPower = 0;
                return cannonPower;
            }
            else
                return 0;

        }
    }
}
