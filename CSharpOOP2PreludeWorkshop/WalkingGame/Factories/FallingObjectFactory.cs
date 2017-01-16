using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingGame.Animations;
using WalkingGame.Model;
using WalkingGame.Model.FallingObjects;

namespace WalkingGame.Factories
{
   public class FallingObjectFactory
    {
        private double lastCall;
        private int harmfulObjects;
        private ImageBufferer bufferer;

        public FallingObjectFactory(ContentManager manager)
        {
            this.bufferer=ImageBufferer.Initialize(manager);
        }
        public FallingObject ProduceFallingObject(GameTime gameTime)
        {
            int randomIndex = new Random().Next() % bufferer.Textures.Count;

            if (harmfulObjects < 10)
            {
                if (lastCall + 0.5 <= gameTime.TotalGameTime.TotalSeconds)
                {
                    lastCall = gameTime.TotalGameTime.TotalSeconds;
                    harmfulObjects++;
                    string random = Path.GetRandomFileName();
                    return new HarmfullFallingObject(bufferer.Textures[randomIndex],
                        new Random(random.GetHashCode()).Next(0, Globals.GLOBAL_WIDTH));
                }

            }
            else if (harmfulObjects >= 10 && lastCall + 0.5 <= gameTime.TotalGameTime.TotalSeconds)
            {
                harmfulObjects = 0;
               // return new HelpfulFallingObject(ImageBufferer.Initialize().Textures.First(x=>x.Name==), new Random().Next(0, Globals.GLOBAL_WIDTH));

            }
            return null;
        }
    }
}
