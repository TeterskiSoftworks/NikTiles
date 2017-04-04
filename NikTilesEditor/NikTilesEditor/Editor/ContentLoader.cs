using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Xna.Framework.Content;
using NikTiles.Engine;

namespace NikTiles.Editor {
    static class ContentLoader {


        #region Declarations
        public static Dictionary<String, Texture2D> textures;

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

                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/" + contentFolder + "/Floor");
                if (dir.Exists) {
                    textures = new Dictionary<String, Texture2D>();

                    FileInfo[] files = dir.GetFiles("*.png");
                    foreach (FileInfo file in files) {
                        Bitmap img = (Bitmap)Image.FromFile(file.FullName, true);

                        Microsoft.Xna.Framework.Color[] pixels = new Microsoft.Xna.Framework.Color[img.Width * img.Height];

                        for (int y = 0; y < img.Height; y++) {
                            for (int x = 0; x < img.Width; x++) {
                                System.Drawing.Color c = img.GetPixel(x, y);
                                pixels[(y * img.Width) + x] = new Microsoft.Xna.Framework.Color(c.R, c.G, c.B, c.A);
                            }
                        }

                        Texture2D texture = new Texture2D(graphicsDevice, img.Width, img.Height);
                        texture.SetData(pixels);

                        String key = Path.GetFileNameWithoutExtension(file.Name);
                        textures[key] = texture;

                    }


                }


                dir = new DirectoryInfo(Application.StartupPath + "/" + contentFolder + "/UI");
                if (dir.Exists) {
                    FileInfo[] files = dir.GetFiles("Cursor.png");
                    Texture2D cursorTexture = new Texture2D(graphicsDevice, 1, 1);
                    foreach (FileInfo file in files) {
                        Bitmap img = (Bitmap)Image.FromFile(file.FullName, true);
                        cursorTexture = new Texture2D(graphicsDevice, img.Width, img.Height);
                        Microsoft.Xna.Framework.Color[] pixels = new Microsoft.Xna.Framework.Color[img.Width * img.Height];

                        for (int y = 0; y < img.Height; y++) {
                            for (int x = 0; x < img.Width; x++) {
                                System.Drawing.Color c = img.GetPixel(x, y);
                                pixels[(y * img.Width) + x] = new Microsoft.Xna.Framework.Color(c.R, c.G, c.B, c.A);
                            }
                        }

                        cursorTexture.SetData(pixels);
                    }

                    Microsoft.Xna.Framework.Color[,] mouseMap = new Microsoft.Xna.Framework.Color[0, 0];
                    files = dir.GetFiles("MouseMap.png");
                    foreach (FileInfo file in files) {
                        Bitmap img = (Bitmap)Image.FromFile(file.FullName, true);
                        mouseMap = new Microsoft.Xna.Framework.Color[img.Width,img.Height];

                        for (int y = 0; y < img.Height; y++) {
                            for (int x = 0; x < img.Width; x++) {
                                System.Drawing.Color c = img.GetPixel(x, y);
                                mouseMap[y, x] = new Microsoft.Xna.Framework.Color(c.R, c.G, c.B, c.A);
                            }
                        }
                        
                    }

                    NikTiles.Engine.Cursor.LoadCursorTextures(mouseMap,cursorTexture);
                }

            }

        }


    }
}