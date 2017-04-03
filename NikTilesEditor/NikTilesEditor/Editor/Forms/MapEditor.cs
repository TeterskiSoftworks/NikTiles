using NikTiles.Engine;
using System.Windows.Forms;

namespace NikTiles.Editor.Forms {
    public partial class MapEditor : Form {

        public MapEditor() {

            InitializeComponent();
        }


        private void mapPanel_Layout(object sender, LayoutEventArgs e) {
            mapDisplay.ResizeView(mapPanel.Width, mapPanel.Height);
            Camera.SetCenter(mapPanel.HorizontalScroll.Value * 2, mapPanel.VerticalScroll.Value);
        }

        private void mapPanel_Scroll(object sender, ScrollEventArgs e) {
            Camera.SetCenter(mapPanel.HorizontalScroll.Value * 2, mapPanel.VerticalScroll.Value);
        }
    }
}