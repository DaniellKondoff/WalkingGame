using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using WalkingGame.Factories;
using WalkingGame.Model;
using Microsoft.Xna.Framework.Content;

namespace WalkingGame.Animations.Animators
{
    public class FallingObjectAnimator : Animator
    {
        List<FallingObject> fallingOnjects = new List<FallingObject>();
        FallingObjectFactory factory;

        public FallingObjectAnimator(ContentManager manager)
        {
            this.factory = new FallingObjectFactory(manager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var fallingObject in fallingOnjects)
            {
                Vector2 vector = new Vector2(fallingObject.X, fallingObject.Y);
                spriteBatch.Draw(fallingObject.Texture, vector, Color.White);
            }
        }

        public override void Update(GameTime gameTime, Vector2 velocity)
        {
            UpdateAnimation(gameTime, velocity);
            foreach (var fallingObject in fallingOnjects)
            {
                fallingObject.Y +=3;
            }
        }

        protected override void BufferAnimations()
        {
            
        }

        protected override void UpdateAnimation(GameTime gameTime, Vector2 velocity)
        {
            var fallingObject = this.factory.ProduceFallingObject(gameTime);
            if (fallingObject != null)
            {
                this.fallingOnjects.Add(fallingObject);
            }
        }
    }
}
