using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WalkingGame.Interfaces
{
    interface IAnimator
    {
        
        void Update(GameTime gameTime, Vector2 velocity);
        void Draw(SpriteBatch spriteBatch);
    }
}
