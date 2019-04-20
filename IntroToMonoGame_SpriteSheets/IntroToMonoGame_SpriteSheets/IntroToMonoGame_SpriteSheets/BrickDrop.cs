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
    class BrickDrop : Brick
    {
        public new bool Visible { get; set; } // does brick still exist
        // 7 rows, each with own color
        // 10 per row
        // 3 blank at top
        // each brick is 16 x 50

        private int GenRandInt()
        {
            Random r = new Random();
            int nextValue = r.Next(0, 2); // returns random from 0 - 1
            return nextValue;
        }
        private Brick FallingBrick;
        public bool fire { get; set; }

        public BrickDrop(float x, float y, SpriteBatch spriteBatch, GameContent gameContent) : base(x,y,spriteBatch,gameContent)
        {

            float brickX = x;
            float brickY = y;
            Color color = Color.Firebrick;
            Visible = true;
            int i = GenRandInt();
            switch (i)
            {
                case 0:
                    color = Color.Red;
                    fire = true;
                    break;
                case 1:
                    color = Color.Blue;
                    fire = false;
                    break;
            }

            FallingBrick = new Brick(brickX, brickY, color, spriteBatch, gameContent);


        }

        public new void Draw()
        {
            if (Visible)
            FallingBrick.Draw();


        }
        public void Update(GameTime gameTime)
        {
            FallingBrick.Update();
        }
        
    }
}
