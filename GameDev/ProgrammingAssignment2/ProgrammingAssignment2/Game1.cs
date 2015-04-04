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

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Bouncing balls "Game"
    /// For the course Begining game programming in C# at coursera
    /// Author: Laurent Morissette
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Ball textures
        Texture2D ball0,ball1,ball2;

        //Ball speeds
        int xSpeed, ySpeed = 0;

        // used to handle generating random values
        Random rand = new Random();
        const int CHANGE_DELAY_TIME = 1000;
        int elapsedTime = 0;

        // used to keep track of current sprite and location
        Texture2D currentSprite;
        Rectangle drawRectangle = new Rectangle();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT; ;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // STUDENTS: load the sprite images here
            ball0 = Content.Load<Texture2D>("red_ball");
            ball1 = Content.Load<Texture2D>("white_ball");
            ball2 = Content.Load<Texture2D>("black_ball");


            // STUDENTS: set the currentSprite variable to one of your sprite variables
            currentSprite = ball1;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime > CHANGE_DELAY_TIME)
            {
                elapsedTime = 0;

                
                // At fisrt I used (0,2) as a range but it made the process skip the third ball 
                int spriteNumber =  rand.Next(0,3);


                // sets current sprite
                 if (spriteNumber == 0)
                {
                   currentSprite = ball0;
                }
                else if (spriteNumber == 1)
                {
                    currentSprite = ball1;
                }
                else if (spriteNumber == 2)
                {
                    currentSprite = ball2;
                }

                //Set sprite container size
                drawRectangle.Height = currentSprite.Height;
                drawRectangle.Width = currentSprite.Width;

                drawRectangle.X = WINDOW_WIDTH / 2 - currentSprite.Width / 2;
                drawRectangle.Y = WINDOW_HEIGHT / 2 - currentSprite.Height / 2;

               //Setting sprite container location
                //drawRectangle.X = WINDOW_WIDTH / 2;
                //drawRectangle.Y = WINDOW_HEIGHT / 2;


               //Setting ball speed
                
                //Same explanation as before for random range
                xSpeed = rand.Next(-4, 5);
                ySpeed = rand.Next(-4, 5);

            }

            //Move ball at the selected speeds
            drawRectangle.X += xSpeed;
            drawRectangle.Y += ySpeed;


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // STUDENTS: draw current sprite here
            spriteBatch.Begin();
            spriteBatch.Draw(currentSprite,drawRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
