﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingGame.Input
{
    public class InputHandler
    {
        private CharacterEntity character;

        public InputHandler(CharacterEntity character)
        {
            this.character = character;
        }

        
        public Point GetInput()
        {

            KeyboardState state = Keyboard.GetState();
            Point point = new Point();
            //if (state.IsKeyDown(Keys.S))
            //{
            //    // this.Y += 5;
            //    point.Y += 15;
            //}
            //if (state.IsKeyDown(Keys.W))
            //{
            //    //this.Y -= 5;
            //    point.Y -= 15;
            //}
            if (state.IsKeyDown(Keys.A))
            {

                // this.X -= 5;
                point.X -= 15;
            }
            if (state.IsKeyDown(Keys.D))
            {

                //this.X += 5;
                point.X += 15;
            }
            return point;
        }

        Vector2 GetDesiredVelocityFromInput()
        {
            Vector2 desiredVelocity = new Vector2();

            var newPoint = this.GetInput();


            if ((this.character.X + newPoint.X) + 5 < Globals.GLOBAL_WIDTH && (this.character.X + newPoint.X) + 13 >= 0 &&
                (this.character.Y + newPoint.Y) + 5 < Globals.GLOBAL_HEIGHT && (this.character.Y + newPoint.Y) + 13 >= 0)
            {
                desiredVelocity.X = newPoint.X;
                desiredVelocity.Y = newPoint.Y;

                if (desiredVelocity.X != 0 || desiredVelocity.Y != 0)
                {
                    desiredVelocity.Normalize();
                    const float desiredSpeed = 200;
                    desiredVelocity *= desiredSpeed;
                }
            }

            return desiredVelocity;
        }

        public Vector2 Move(GameTime gameTime)
        {

            //this.GetInput();
            Vector2 velocity = Vector2.Zero;

            velocity = GetDesiredVelocityFromInput();

            this.character.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.character.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            return velocity;
        }
    }
}
