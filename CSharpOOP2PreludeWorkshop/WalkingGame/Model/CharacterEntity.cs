namespace WalkingGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CharacterEntity : GameObject
    {
        

        public CharacterEntity(GraphicsDevice graphicsDevice,float x, float y) 
            : base(x,y)
        {
            if (base.CharacterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/charactersheet.png"))
                {
                    base.CharacterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }
        }

       

    }
}
