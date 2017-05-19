﻿using NikTiles.Engine;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;

namespace NikTiles.Editor.Forms {
    public partial class MapEditor : Form {

        public MapEditor() {

            InitializeComponent();
            mapDisplay.MouseWheel += new MouseEventHandler(mapDisplay_MouseWheel);

            zoomBox.Text = "100";

            cursorBoxX.Text = "0/0";
            cursorBoxY.Text = "0/0";
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
            Selector.MouseDown(true);
            if (mouse.Button == MouseButtons.Left) {
                Selector.Deselect(IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt));
                Selector.Select();
            }
        }

        private void mapDisplay_MouseMove(object sender, MouseEventArgs mouse) {
            Engine.Cursor.SetCursor(mouse);
            if (Selector.MouseDown() && mouse.Button == MouseButtons.Left){
                Selector.Deselect(IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt));
                Selector.Select();
            }

            //cursor label update
            cursorBoxX.Text = Engine.Cursor.GetX().ToString()+"/"+MapDisplay.GetCurrentMap().Width();
            cursorBoxY.Text = Engine.Cursor.GetY().ToString()+"/"+MapDisplay.GetCurrentMap().Height();
        }

        private void mapDisplay_MouseUp(object sender, MouseEventArgs mouse) {
            Selector.MouseDown(false);
            if (mouse.Button == MouseButtons.Left) {
                Selector.Deselect(IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt));
                Selector.Select();
            }
        }

        private bool IsKeyDown(Microsoft.Xna.Framework.Input.Keys key) {
            return Keyboard.GetState().IsKeyDown(key);
        }

        private void mapDisplay_KeyDown(object sender, KeyEventArgs e) {

            if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)) {
                if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D)) Selector.DeselectAll();
                if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A)) Selector.SelectAll();
                if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.I)) Selector.InverseSelection();
            }
            
            if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.G)) { Tile.viewGrid = !Tile.viewGrid; }

            #region Selection Mode change
            if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D1))
                selectionToolStrip1.SetMode(1);
            else if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D2))
                selectionToolStrip1.SetMode(2);
            else if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D3))
                selectionToolStrip1.SetMode(3);
            else if (IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D4))
                selectionToolStrip1.SetMode(4);
            #endregion


        }
    }
}