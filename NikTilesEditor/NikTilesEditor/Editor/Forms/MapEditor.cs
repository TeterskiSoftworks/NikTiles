using NikTiles.Engine;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;

namespace NikTiles.Editor.Forms {
    public partial class MapEditor : Form {
        bool mouseDown = false;


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

        private void mapDisplay_MouseDown(object sender, MouseEventArgs mouse) {
            mouseDown = true;
            if (mouse.Button == MouseButtons.Left) {
                if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt))
                    MapDisplay.GetCurrentMap().TileAt(Engine.Cursor.GetX(), Engine.Cursor.GetY()).Deselect();
                else MapDisplay.GetCurrentMap().TileAt(Engine.Cursor.GetX(), Engine.Cursor.GetY()).Select();
            }
        }

        private void mapDisplay_MouseMove(object sender, MouseEventArgs mouse) {
            Engine.Cursor.SetCursor(mouse);
            if (mouseDown && mouse.Button == MouseButtons.Left){
                if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt))
                    MapDisplay.GetCurrentMap().TileAt(Engine.Cursor.GetX(), Engine.Cursor.GetY()).Deselect();
                else MapDisplay.GetCurrentMap().TileAt(Engine.Cursor.GetX(), Engine.Cursor.GetY()).Select();
            }
        }

        private void mapDisplay_MouseUp(object sender, MouseEventArgs mouse) {
            mouseDown = false;
            if (mouse.Button == MouseButtons.Left) {
                if(IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt))
                    MapDisplay.GetCurrentMap().TileAt(Engine.Cursor.GetX(), Engine.Cursor.GetY()).Deselect();
                else MapDisplay.GetCurrentMap().TileAt(Engine.Cursor.GetX(), Engine.Cursor.GetY()).Select();
            }
        }

        private bool IsKeyDown(Microsoft.Xna.Framework.Input.Keys key) {
            return Keyboard.GetState().IsKeyDown(key);
        }

        private void mapDisplay_KeyDown(object sender, KeyEventArgs e) {
            if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.G)) {
                Tile.viewGrid = !Tile.viewGrid;
            }
        }
    }
}