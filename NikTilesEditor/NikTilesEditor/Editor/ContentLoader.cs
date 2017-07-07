using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using NikTiles.Engine;
using Microsoft.Xna.Framework.Content;
using WinFormsGraphicsDevice;

namespace NikTiles.Editor {
    static class ContentLoader {


        #region Declarations
        private static bool loaded = false;
        private static string contentFolder = "Content";
        private static GraphicsDevice graphicsDevice;
        #endregion

        /// <summary>
        /// Dynamically loads .png images to be converted and added into textures.
        /// 
        /// Textures files are to be added in .PNG format in a folder with the same name as contentFolder ("Textures")
        /// in the root directory of the program.
        /// 
        /// This function can only be run once.
        /// </summary>
        public static void LoadTextures(GraphicsDevice graphicsDevice, ServiceContainer Services) {
            if (!loaded) {
                ContentLoader.graphicsDevice = graphicsDevice;
                LoadUserInterface(Services);

                Engine.Texture.floor = LoadFilesFrom(contentFolder + "/Floor", "*.png");
                
                Engine.Texture.floor.Add("Empty", new Engine.Texture("Empty", new Texture2D(graphicsDevice, 1, 1)));
                Material.floor.Add("Empty",
                    new FloorMaterial("Empty",Engine.Texture.floor["Empty"],Engine.Texture.floor["Empty"]));

            }

        }

        /// <summary>
        /// Loads images relating to the programs user interface.
        /// </summary>
        private static void LoadUserInterface(ServiceContainer Services) {
            ContentManager content = new ContentManager(Services, "Content");

            Engine.Texture.selection = content.Load<Texture2D>("Selection");
            Engine.Texture.grid = content.Load<Texture2D>("Cursor/Sprites/Floor");

            MemoryStream stream = new MemoryStream();
            content.Load<Texture2D>("Cursor/MouseMap").SaveAsPng(stream, Tile.Width, Tile.Height);
            Microsoft.Xna.Framework.Color[] mouseMap = CreateColorArray(new Bitmap(stream, true));
            stream.Dispose();

            Engine.Cursor.LoadCursorTextures(
                mouseMap,
                content.Load<Texture2D>("Cursor/Sprites/Floor"),
                content.Load<Texture2D>("Cursor/Sprites/Wall"));
            
        }

        /// <summary>
        /// Loads files from given location as Texture2D, returning a dictionary.
        /// </summary>
        /// <param name="contentFolder">The location of the image files.</param>
        /// <param name="searchFilter">Search parameters for the file (ex. file extension)</param>
        private static Dictionary<String, Engine.Texture> LoadFilesFrom(string contentFolder, string searchFilter) {
            Dictionary<String, Engine.Texture> textures = new Dictionary<string, Engine.Texture>();

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/" + contentFolder);
            if (dir.Exists) {
                textures = new Dictionary<String, Engine.Texture>();

                FileInfo[] files = dir.GetFiles(searchFilter);
                foreach (FileInfo file in files) {

                    String key = Path.GetFileNameWithoutExtension(file.Name);
                    textures[key] = new Engine.Texture(key, CreateTexture2D((Bitmap)Image.FromFile(file.FullName, true)));

                }
            }
            return textures;
        }

        /// <summary>
        /// Loads a single file from the given directory.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="graphicsDevice"></param>
        /// <returns></returns>
        private static Texture2D LoadFileFrom(string contentFolder, string searchFilter) {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/" + contentFolder);
            if (dir.Exists) {
                FileInfo[] files = new DirectoryInfo(Application.StartupPath + "/" + contentFolder).GetFiles(searchFilter);
                foreach (FileInfo file in files) {
                    texture = CreateTexture2D((Bitmap)Image.FromFile(file.FullName, true));
                }
            }
            return texture;
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

        public static Texture2D CreateTexture2D(Bitmap img) {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture = new Texture2D(graphicsDevice, img.Width, img.Height);
            texture.SetData(CreateColorArray(img));
            return texture;
        }

    }
}