
using System;

namespace WalkingGame.Model.FallingObjects
{
    class HelpfulFallingObject : FallingObject
    {
        public HelpfulFallingObject(float x) : base(x)
        {
        }

        public override void Collide(CharacterEntity character)
        {
            throw new NotImplementedException();
        }
    }
}
