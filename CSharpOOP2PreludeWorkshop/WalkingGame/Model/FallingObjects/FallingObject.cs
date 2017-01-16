
using System;
using WalkingGame.Interfaces;

namespace WalkingGame.Model
{
    public abstract class FallingObject : GameObject,ICollidable
    {
        public FallingObject(float x) : base(x, 0)
        {
        }

        public abstract void Collide(CharacterEntity character);
        
    }
}
