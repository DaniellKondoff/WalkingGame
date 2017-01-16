using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingGame.Animations
{
   public class CharacterAnimator : Animator
    {
        CharacterEntity character;
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        Animation currentAnimation;

        public CharacterAnimator(CharacterEntity character)
        {
            this.character = character;
            this.BufferAnimations();
        }

        protected override void BufferAnimations()
        {
            var walkDown = new Animation();
            walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(16, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(32, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("walkDown", walkDown);

            var walkUp = new Animation();
            walkUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(160, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(176, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("walkUp", walkUp);


            var walkLeft = new Animation();
            walkLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(64, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(80, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("walkLeft", walkLeft);


            var walkRight = new Animation();
            walkRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(112, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(128, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("walkRight", walkRight);


            // Standing animations only have a single frame of animation:
            var standDown = new Animation();
            standDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("standDown", standDown);


            var standUp = new Animation();
            standUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("standUp", standUp);

            var standLeft = new Animation();
            standLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("standLeft", standLeft);


            var standRight = new Animation();
            standRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            this.animations.Add("standRight", standRight);

        }

        protected override void UpdateAnimation(GameTime gameTime, Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                bool movingHorizontally = Math.Abs(velocity.X) > Math.Abs(velocity.Y);
                if (movingHorizontally)
                {
                    if (velocity.X > 0)
                    {
                        currentAnimation = this.animations["walkRight"];
                    }
                    else
                    {
                        currentAnimation = this.animations["walkLeft"];
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        currentAnimation = this.animations["walkDown"];
                    }
                    else
                    {
                        currentAnimation = this.animations["walkUp"];
                    }
                }
            }
            else
            {
                // If the character was walking, we can set the standing animation
                // according to the walking animation that is playing:
                if (currentAnimation == this.animations["walkRight"])
                {
                    currentAnimation = this.animations["standRight"];
                }
                else if (currentAnimation == this.animations["walkLeft"])
                {
                    currentAnimation = this.animations["standLeft"];
                }
                else if (currentAnimation == this.animations["walkUp"])
                {
                    currentAnimation = this.animations["standUp"];
                }
                else if (currentAnimation == this.animations["walkDown"])
                {
                    currentAnimation = this.animations["standDown"];
                }
                else if (currentAnimation == null)
                {
                    currentAnimation = this.animations["standDown"];
                }

                // if none of the above code hit then the character
                // is already standing, so no need to change the animation.
            }


            currentAnimation.Update(gameTime);
        }

        public override void Update(GameTime gameTime,Vector2 velocity)
        {

            

            this.UpdateAnimation(gameTime, velocity);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftPos = new Vector2(this.character.X, this.character.Y);
            Color tint = Color.White;

            var sourceRectangle = this.currentAnimation.CurrentRectangle;

            spriteBatch.Draw(this.character.CharacterSheetTexture, topLeftPos, sourceRectangle, tint);
        }
    }
}
