using NikTiles.Engine;
using System.Windows.Forms;

namespace NikTiles.Editor.Forms {
    public partial class MapEditor : Form {

        public MapEditor() {

            InitializeComponent();
            mapDisplay.MouseWheel += new MouseEventHandler(mapDisplay_MouseWheel);

        }

        private void mapDisplay_MouseWheel(object sender, MouseEventArgs mouse) {
            Camera.SetCenter(0, 0);
            Camera.Zoom(mouse.Delta * 0.001f);

            mapDisplay.Width  = (int)((MapDisplay.GetCurrentMap().Width() + 1) * Camera.GetZoomX() * Tile.Width() / 2);
            mapDisplay.Height = (int)((MapDisplay.GetCurrentMap().Height()+.5) * Camera.GetZoomY() * Tile.Height());


            Camera.SetCenter(mapPanel.HorizontalScroll.Value * 2, mapPanel.VerticalScroll.Value);
            ((HandledMouseEventArgs)mouse).Handled = true;
        }

        private void mapPanel_Layout(object sender, LayoutEventArgs e) {
            mapDisplay.ResizeView(mapPanel.Width, mapPanel.Height);
            Camera.SetCenter(mapPanel.HorizontalScroll.Value * 2, mapPanel.VerticalScroll.Value);
        }

        private void mapPanel_Scroll(object sender, ScrollEventArgs e) {
            Camera.SetCenter(mapPanel.HorizontalScroll.Value * 2, mapPanel.VerticalScroll.Value);
        }

        private void mapDisplay_MouseMove(object sender, MouseEventArgs mouse) {
            NikTiles.Engine.Cursor.SetCursor(mouse);
        }

    }
}