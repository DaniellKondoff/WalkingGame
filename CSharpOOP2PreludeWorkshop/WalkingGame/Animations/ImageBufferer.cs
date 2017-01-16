using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
namespace WalkingGame.Animations
{
    class ImageBufferer
    {
        private static ImageBufferer imageBufferer;
        private List<Texture2D> textures = new List<Texture2D>();

        public List<Texture2D> Textures
        {
            get
            {
                return textures;
            }
        }

        public static ImageBufferer Initialize(ContentManager manager)
        {
            if (imageBufferer == null)
            {
                imageBufferer = new ImageBufferer();
                imageBufferer.BufferImages(manager);
            }
            return imageBufferer;
        }

        public void  BufferImages(ContentManager manager)
        {
          
            string path =
           @"D:\SoftUni\C#_OOP_OLD\01.C#OOP_BASIC_\07.Workshop\CSharpOOP2PreludeWorkshop\WalkingGame\Assets"; // insert your own path here
            var currentDir = Directory.GetFiles(path);
            foreach (var fileName in currentDir)
            {
                string extractedFileName = fileName.Substring(fileName.LastIndexOf(@"\") - "Assets".Length);
                string fileNameWithoutExtension = extractedFileName.Substring(0, extractedFileName.Length - 4);
                Texture2D texture = manager.Load<Texture2D>(fileNameWithoutExtension);
                this.textures.Add(texture);
            }
        }
    }
}
