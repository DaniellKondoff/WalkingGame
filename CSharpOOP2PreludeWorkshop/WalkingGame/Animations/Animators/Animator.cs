using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingGame.Interfaces;

namespace WalkingGame.Animations
{
    public abstract class Animator : IAnimator
    {
        protected abstract void BufferAnimations();

        public abstract void Update(GameTime gameTime, Vector2 velocity);

        protected abstract void UpdateAnimation(GameTime gameTime, Vector2 velocity);

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
