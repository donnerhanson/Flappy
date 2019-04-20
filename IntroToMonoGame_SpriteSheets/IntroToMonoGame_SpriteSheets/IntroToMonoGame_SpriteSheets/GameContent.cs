using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Flappy_Bat
{
    class GameContent
    {
        public Texture2D imgBrick { get; set; }

        public SpriteFont labelFont { get; set; }


        public GameContent (ContentManager Content)
    {
        

        imgBrick = Content.Load<Texture2D>("brick");
        labelFont = Content.Load<SpriteFont>("Fonts/Arial20");
    }
}
}