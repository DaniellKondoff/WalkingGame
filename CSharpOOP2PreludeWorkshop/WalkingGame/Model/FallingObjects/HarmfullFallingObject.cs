

using Microsoft.Xna.Framework.Graphics;
using System;

namespace WalkingGame.Model.FallingObjects
{
    class HarmfullFallingObject : FallingObject
    {
        public HarmfullFallingObject(Texture2D texture, float x) : base(x)
        {
            base.Texture = texture;
        }

        public override void Collide(CharacterEntity character)
        {
            throw new NotImplementedException();
        }
    }
}
