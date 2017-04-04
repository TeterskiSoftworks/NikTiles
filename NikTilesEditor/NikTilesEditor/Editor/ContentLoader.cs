using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace NikTiles.Editor {
    static class ContentLoader {


        #region Declarations
        public static Dictionary<String, Texture2D> floor;  //maybe move to Tile class?

        private static bool loaded = false;
        private static string contentFolder = "Content";
        #endregion

        /// <summary>
        /// Dynamically loads .png images to be converted and added into textures.
        /// 
        /// Textures files are to be added in .PNG format in a folder with the same name as contentFolder ("Textures")
        /// in the root directory of the program.
        /// 
        /// This function can only be run once.
        /// </summary>
        public static void LoadTextures(GraphicsDevice graphicsDevice) {
            if (!loaded) {
                LoadUserInterface(graphicsDevice);

                floor = LoadFilesFrom(contentFolder + "/Floor", "*.png", graphicsDevice);

            }

        }

        /// <summary>
        /// Loads images relating to the programs user interface.
        /// </summary>
        private static void LoadUserInterface(GraphicsDevice graphicsDevice) {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/" + contentFolder + "/UI");
            if (dir.Exists) {
                FileInfo[] files = dir.GetFiles("MouseMap.png");
                Texture2D cursorTexture = new Texture2D(graphicsDevice, 1, 1);
                foreach (FileInfo file in files) {
                    Bitmap img = (Bitmap)Image.FromFile(file.FullName, true);
                    cursorTexture = new Texture2D(graphicsDevice, img.Width, img.Height);
                    cursorTexture.SetData(CreateColorArray(img));
                }

                Microsoft.Xna.Framework.Color[] mouseMap = new Microsoft.Xna.Framework.Color[0];
                files = dir.GetFiles("MouseMap.png");
                foreach (FileInfo file in files) {
                    Bitmap img = (Bitmap)Image.FromFile(file.FullName, true);

                    mouseMap = new Microsoft.Xna.Framework.Color[img.Width * img.Height];
                    mouseMap = CreateColorArray(img);

                }

                NikTiles.Engine.Cursor.LoadCursorTextures(mouseMap, cursorTexture);
            }
        }

        /// <summary>
        /// Loads files from given location as Texture2D, returning a dictionary.
        /// </summary>
        /// <param name="contentFolder">The location of the image files.</param>
        /// <param name="searchFilter">Search parameters for the file (ex. file extension)</param>
        /// <param name="graphicsDevice">Graphics device is required for the creation of new textures.</param>
        private static Dictionary<String, Texture2D> LoadFilesFrom(string contentFolder, string searchFilter, GraphicsDevice graphicsDevice) {
            Dictionary<String, Texture2D> textures = new Dictionary<string, Texture2D>();

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/" + contentFolder);
            if (dir.Exists) {
                textures = new Dictionary<String, Texture2D>();

                FileInfo[] files = dir.GetFiles(searchFilter);
                foreach (FileInfo file in files) {

                    Bitmap img = (Bitmap)Image.FromFile(file.FullName, true);
                    Texture2D texture = new Texture2D(graphicsDevice, img.Width, img.Height);
                    texture.SetData(CreateColorArray(img));


                    String key = Path.GetFileNameWithoutExtension(file.Name);
                    textures[key] = texture;

                }
            }
            return textures;
        }

        /// <summary>
        /// Creates and returns an array of color pixels representation of the image.
        /// </summary>
        /// <param name="img">The image the array is based on.</param>
        private static Microsoft.Xna.Framework.Color[] CreateColorArray(Bitmap image) {

            //consider having the image scaled to Tile width and height before loading it in.
            Microsoft.Xna.Framework.Color[] pixels = new Microsoft.Xna.Framework.Color[image.Width * image.Height];
            Color c = new Color();
            for (int y = 0; y < image.Height; y++) {
                for (int x = 0; x < image.Width; x++) {
                    c = image.GetPixel(x, y);
                    pixels[(y * image.Width) + x] = new Microsoft.Xna.Framework.Color(c.R, c.G, c.B, c.A);
                }
            }

            return  pixels;
        }

    }
}