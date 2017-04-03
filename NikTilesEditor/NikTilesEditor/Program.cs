using System;
using System.Windows.Forms;
using NikTiles.Editor.Forms;

namespace NikTilesEditor {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (MapEditor mapEditor = new MapEditor())
                Application.Run(mapEditor);
        }
    }
#endif
}

