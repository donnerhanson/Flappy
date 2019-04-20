using Flappy_Bat;
using Flappy_Bat.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Flappy_Bat.Content.States;
using System;

namespace Flappy_Bat
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player mPlayerSprite;


        private State _currentState;
        private State _nextState;

        public void ChangeState(State curr)
        {
            _nextState = curr;
        }
        public void AssignStart()
        {
            _currGameState = GAME_STATE_ENUM.Playing;
            _currentState = new GameState(this, graphics.GraphicsDevice, Content);

        }


        public enum GAME_STATE_ENUM
        {
            Menu,
            Playing,
            Paused,
            Dead
        }

        private GAME_STATE_ENUM _currGameState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = ScreenGlobals.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = ScreenGlobals.SCREEN_HEIGHT;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            // TODO: Add your initialization logic here
            _currentState = new GameState(this, GraphicsDevice, Content); // issues with getting state to change
            mPlayerSprite = new Player(graphics.GraphicsDevice);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           GameContent gameContent = new GameContent(Content);
            
            // Create a new SpriteBatch, which can be used to draw textures.
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
         
             _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            //_currentState.LoadContent();

                


            if (_currentState.GetStateType() == true)
                mPlayerSprite.LoadContent(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            // TODO: Add your update logic here

            // START AT MENU
          if (_currentState.GetStateType()==false)
             _currGameState = GAME_STATE_ENUM.Menu;

            if (_nextState != null)
            {
                _currentState = _nextState;
                
                _nextState = null;
            }
            
          
            if (_currentState.GetStateType()==true)
            {
                _currGameState = GAME_STATE_ENUM.Playing;
            }
            // _currentState.PostUpdate(gameTime);
            // PLAY
#pragma warning: initialized initial gamestate for testing
            

            if (_currGameState == GAME_STATE_ENUM.Playing)
            {
                if (mPlayerSprite == null)
                    LoadContent();
                    mPlayerSprite.Update(gameTime);
            }

            // PAUSE
            // ADD A MENU HERE

            // GAME OVER
            if (mPlayerSprite.getCurrState() == mPlayerSprite.getDead())
            {
                // probably add a game over state or menu
                Exit();
            }
            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (_currGameState == GAME_STATE_ENUM.Menu)
            {
                _currentState.Draw(gameTime, spriteBatch);
            }
            // TODO: Add your drawing code here

            if (_currentState.GetStateType() == true)
                _currGameState = GAME_STATE_ENUM.Playing;
            if (_currGameState == GAME_STATE_ENUM.Playing)
            {
                Console.WriteLine("Playing");
                spriteBatch.Begin();
                //Draw the game
                mPlayerSprite.Draw(this.spriteBatch);
                spriteBatch.End();
            }
            
            

            base.Draw(gameTime);
        }
    }
}
