using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingGame
{
    public abstract class GameObject
    {
        public Texture2D Texture { get; set; }

        public float X { get; set; }
        public float Y { get; set; }


        public GameObject(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public Texture2D CharacterSheetTexture
        {
            get;
            set;
        }

    }
}
