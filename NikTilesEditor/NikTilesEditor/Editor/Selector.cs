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

            public static int current = LINE;
            
            public static void SetCurrentMode(int mode) {current = mode;}
        }

        //add mouse state memory here


        private static int[] head, tail;
        private static bool firstPress = false;


        public static void Select(bool deselect, bool mouseDown) {
            switch (Mode.current) {
                case Mode.POINT: PointSelect(deselect           ); break;
                case Mode.LINE : LineSelect (deselect, mouseDown); break;
            }

        }

        public static void PointSelect(bool deselect) {
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
                head = new int[] { x, y };
                //do a check for mouseUp
            } else if (mouseDown && firstPress) {
                tail = new int[] { x, y };
                firstPress = false;


                //Bresenham's Line Algorithm
                // needs to be adjusted to the 
                // jagged coordinate system used.

                int dx = tail[0] - head[0]; int dy = tail[1] - head[1];

                //Rotates the line to a better slope 
                //if its too steep.
                bool steep = Math.Abs(dy) > Math.Abs(dx);
                if (steep) {
                    int temp = head[0];
                    head[0] = head[1]; head[1] = temp;
                    temp = tail[0];
                    tail[0] = tail[1]; tail[1] = temp;
                }

                //Swaps head and tail if necessary
                if (head[0] > tail[0]) {             
                    int temp = head[0];
                    head[0] = tail[0]; tail[0] = temp;
                    temp = head[1];
                    head[1] = tail[1]; tail[1] = temp;
                }

                //Recaulating slope
                dx = tail[0] - head[0]; dy = tail[1] - head[1];

                //Calculating error
                int error = dx / 2;
                int yStep = (head[1] < tail[1] ? yStep = 1 : yStep=-1);

                //Iterate over bounding box generating points between head and tail
                y = head[1];
                for(int _x=head[0]; _x < tail[0] + 1; _x++) {
                    if (steep) MapDisplay.GetCurrentMap().TileAt(y, _x).Select();
                    else MapDisplay.GetCurrentMap().TileAt(_x, y).Select();

                    error -= Math.Abs(dy);
                    if (error < 0) {
                        y += yStep;
                        error += dx;
                    }
                }

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
