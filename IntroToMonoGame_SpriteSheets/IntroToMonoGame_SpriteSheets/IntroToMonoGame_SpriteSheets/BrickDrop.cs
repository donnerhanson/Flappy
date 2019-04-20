using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flappy_Bat.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flappy_Bat
{
    class BrickDrop
    {
        // 7 rows, each with own color
        // 10 per row
        // 3 blank at top
        // each brick is 50 x 16

        private int GenRandInt()
        {
            Random r = new Random();
            int nextValue = r.Next(0, 2); // returns random from 0 - 1
            return nextValue;
        }
        private Brick FallingBrick;

        public BrickDrop(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {

            float brickX = x;
            float brickY = y;
            Color color = Color.Firebrick;

            int i = GenRandInt();
            switch (i)
            {
                case 0:
                    color = Color.Red;
                    break;
                case 1:
                    color = Color.Blue;
                    break;
            }

            FallingBrick = new Brick(brickX, brickY, color, spriteBatch, gameContent);


        }

        public void Draw()
        {
            FallingBrick.Draw();


        }
        public void Update(GameTime gameTime)
        {
            FallingBrick.Update();
        }
        
    }
}
