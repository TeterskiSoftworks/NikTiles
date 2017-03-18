using NikTiles.Engine;
using System.Windows.Forms;

namespace NikTiles.Forms {
    public partial class MapEditor : Form {

        public MapEditor() {

            InitializeComponent();
        }

       
        private void mapPanel_Layout(object sender, LayoutEventArgs e) {
            int width = mapPanel.Width;
            int height = mapPanel.Height;

            mapDisplay.ResizeView(width, height);
            Camera.SetCenter(0, 0);
        }

        private void mapPanel_Scroll(object sender, ScrollEventArgs e) {
            Camera.SetCenter(mapPanel.HorizontalScroll.Value*2, mapPanel.VerticalScroll.Value);
        }
    }
}
