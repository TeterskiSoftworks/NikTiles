using NikTiles.Editor.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikTiles.Engine;

namespace NikTiles.Editor {
    public static class Selector {

        /// <summary>
        /// The mode refers to how the selector functions. E.i. point selection, line selection, etc.
        /// </summary>
        public struct Mode { //does it have to be a struct?
            public const int POINT = 0;
            public const int LINE = 1;
            public const int BOX = 2;
            public const int CIRCLE = 3;

            public static int current = POINT;
            
            public static void SetCurrentMode(int mode) {current = mode;}
        }

        private static int[] coord1, coord2;
        private static bool firstPress = false;


        public static void Select(bool deselect, bool mouseDown) {
            switch (Mode.current) {
                case Mode.POINT: PointSelect(deselect              ); break;
                case Mode.LINE : LineSelect (deselect, mouseDown); break;
            }

        }

        public static void PointSelect( bool deselect) {
            int y = Cursor.GetY();
            int x = Cursor.GetX();
            if (y >= 0 && y < MapDisplay.GetCurrentMap().Height() && x >= 0 && x < MapDisplay.GetCurrentMap().Width()) {
                if (!deselect) MapDisplay.GetCurrentMap().TileAt(x,y).Select();
                else MapDisplay.GetCurrentMap().TileAt(x,y).Deselect();
            }
        }

        public static void LineSelect(bool deselect, bool mouseDown) {
            int y = Cursor.GetY();
            int x = Cursor.GetX();
            if (mouseDown && !firstPress) {
                firstPress = true;
                coord1 = new int[] { y, x };
            } else if (mouseDown && firstPress) {
                coord2 = new int[] { y, x };
            }
        }

        public static void SelectAll() {
            for (int y = 0; y < MapDisplay.GetCurrentMap().Height(); y++) {
                for (int x = 0; x < MapDisplay.GetCurrentMap().Width(); x++) {
                    MapDisplay.GetCurrentMap().TileAt(x, y).Select();
                }
            }
        }
        public static void DeselectAll() {
            for (int y = 0; y < MapDisplay.GetCurrentMap().Height(); y++) {
                for (int x = 0; x < MapDisplay.GetCurrentMap().Width(); x++) {
                    MapDisplay.GetCurrentMap().TileAt(x, y).Deselect();
                }
            }
        }
        public static void InverseSelection() {
            for (int y = 0; y < MapDisplay.GetCurrentMap().Height(); y++) {
                for (int x = 0; x < MapDisplay.GetCurrentMap().Width(); x++) {
                    MapDisplay.GetCurrentMap().TileAt(x, y).InverseSelection();
                }
            }
        }

    }
}
