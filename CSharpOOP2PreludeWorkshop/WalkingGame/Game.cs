﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WalkingGame
{
    using Animations;
    using Animations.Animators;
    using Input;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputHandler inputHandler;
        private CharacterEntity character;
        private FallingObjectAnimator fallingObjectAnimator;
        CharacterAnimator charAnimator;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.character = new CharacterEntity(this.GraphicsDevice,Globals.GLOBAL_WIDTH/2,Globals.GLOBAL_HEIGHT - Globals.CHARACTER_FRAME_SIZE);
            this.charAnimator = new CharacterAnimator(this.character);
            this.inputHandler = new InputHandler(this.character);
            this.graphics.PreferredBackBufferWidth = Globals.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Globals.GLOBAL_HEIGHT;
            this.fallingObjectAnimator = new FallingObjectAnimator(this.Content);
            this.graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            //List<Texture2D> textures = this.imageBufferer.BufferImages(this.Content);
            
            spriteBatch = new SpriteBatch(GraphicsDevice);  
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }
              

            // TODO: Add your update logic here
            Vector2 velocity = this.inputHandler.Move(gameTime);
            this.fallingObjectAnimator.Update(gameTime, Vector2.Zero);
            this.charAnimator.Update(gameTime, velocity);
            base.Update(gameTime);
            this.Window.Title = string.Format("X : {0} Y : {1} ", this.character.X,
                this.character.Y);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            this.spriteBatch.Begin();
            this.charAnimator.Draw(this.spriteBatch);
            this.fallingObjectAnimator.Draw(this.spriteBatch);
            this.spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
