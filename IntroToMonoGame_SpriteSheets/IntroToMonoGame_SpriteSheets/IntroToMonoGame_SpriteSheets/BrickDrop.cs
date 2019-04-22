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
        public float GetX() { return FallingBrick.X; } // x position of brick on screen
        public float GetY() { return FallingBrick.Y; } // y position of brick on screen

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
            // X is overridden anyway with rand and Y is always 0 could get rid of that but base sprite needs the x,y
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
