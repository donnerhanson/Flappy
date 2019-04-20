using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bat.Content
{
    class Brick : Sprite
    {
        public float X { get; set; } // x position of brick on screen
        public float Y { get; set; } // y position of brick on screen
        public float Width { get; set; } // width of brick
        public float Height { get; set; } // height of brick
        public bool Visible { get; set; } // does brick still exist
        private Color color;

        public bool isFire { get; set; }

       private int fallSpeed;

        enum State
        {
            Falling,
            OffScreen,
            Destroyed
        }

        State currState;

        private int GenRandInt()
        {
            Random r = new Random();
            int nextValue = r.Next(0, 2); // returns random from 0 - 1
            return nextValue;
        }
        private int GenRandX()
        {
            Random r = new Random();
            int nextValue = r.Next((int)ScreenGlobals.SCREEN_WIDTH/2, ScreenGlobals.SCREEN_WIDTH); // returns random from 0 - 1
            return nextValue;
        }
        private int GenRandY() // generate somewhere in the top 2 thirds
        {
            Random r = new Random();
            int nextValue = r.Next((int)ScreenGlobals.SCREEN_HEIGHT/2, ScreenGlobals.SCREEN_HEIGHT); // returns random from 0 - 1
            return nextValue;
        }

        private Texture2D imgBrick { get; set; } // cached image of brick
        private SpriteBatch spriteBatch; // allows us to write on backbuffer when we need to draw self
        private GameContent gameContent;

        public Brick(float x, float y, Color colorIn, SpriteBatch spriteBatch, GameContent gameContent)
        {
            currState = State.Falling;

            X = GenRandX();
            Y = 0;
            imgBrick = gameContent.imgBrick;
            Width = imgBrick.Width;
            Height = imgBrick.Height;
            fallSpeed = 1;

            this.spriteBatch = spriteBatch;
            Visible = true;

            if (colorIn == Color.Firebrick)
            {
                this.color = Color.Firebrick;
                isFire = true;
            }
            else if (colorIn == Color.Blue)
            {
                this.color = Color.Blue;
                isFire = false;
            }
            else
            {
                this.color = Color.Firebrick;
                isFire = true;
            }

        }

        public Brick(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            X = x;
            Y = y;
            this.spriteBatch = spriteBatch;
            this.gameContent = gameContent;
        }

        public static bool HitTest(Rectangle r1, Rectangle r2)
        {
            if (Rectangle.Intersect(r1, r2) != Rectangle.Empty)
                return true;
            else
                return false;
        }
        public void Draw()
        {
            spriteBatch.Begin();

            if (currState == State.Falling && Visible)
            {
                spriteBatch.Draw(imgBrick, new Vector2(X, Y),
                    null, color, MathHelper.ToRadians(90.0f),
                    new Vector2(Width / 2f, Height / 2f), 1.0f, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }

        public void Update()
        {
            // Move the brick down by the fall speed given to us in the constructor.
            Y += (int)fallSpeed*3;
            X -= (int)fallSpeed;

            if (Y >= ScreenGlobals.SCREEN_HEIGHT)
            {
                currState = State.OffScreen;

            }
           

        }

    }
}
