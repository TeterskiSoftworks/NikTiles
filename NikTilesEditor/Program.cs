using System;
using System.Windows.Forms;
using NikTiles.Editor.Forms;

namespace NikTiles
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (MapEditor mapEditor = new MapEditor())
                Application.Run(mapEditor);
        }
    }
#endif
}
