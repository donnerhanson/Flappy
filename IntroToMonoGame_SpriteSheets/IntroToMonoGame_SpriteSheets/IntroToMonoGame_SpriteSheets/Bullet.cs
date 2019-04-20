﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Flappy_Bat
{

    class Bullet : Sprite
    {
        const string BULLET_ASSETNAME = "bullet";

        Vector2 mDirection;
        Vector2 mSpeed;
        Vector2 mStartPosition;

        // bullet types

        const bool FIRE = true;
        const bool ICE = false;
        bool mType = FIRE;

        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, BULLET_ASSETNAME);
            Scale = 0.5f;
            FrameSize = Size.Width;
        }

        public void Update(GameTime theGameTime)
        {
            base.Update(theGameTime, mSpeed, mDirection);
        }

        public override void Draw(SpriteBatch theSpriteBatch)
        {
            base.Draw(theSpriteBatch);
        }

        public void Fire(Vector2 theStartPosition, Vector2 theSpeed, Vector2 theDirection, bool type)
        {
            Position = theStartPosition;
            mStartPosition = theStartPosition;
            mSpeed = theSpeed;
            mDirection = theDirection;
            mType = type;
        }
        bool isFire()
        {
            return mType;
        }
    }
}
