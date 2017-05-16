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
        public enum Mode {
            Point, Line, Box, Circle}
            
        //add mouse state memory here

        private static int[] head, tail;
        private static bool firstPress = false;
        private static Mode currentMode = Mode.Line;


        public static void SetCurrentMode(Mode mode) { currentMode = mode; }


        public static void Select(bool deselect, bool mouseDown) {
            switch (currentMode) {
                case Mode.Point: PointSelect(deselect           ); break;
                case Mode.Line : LineSelect (deselect, mouseDown); break;
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
            int[] cursor = new int[2];

            //Check if inbounds
            if (Cursor.GetX() < 0) cursor[0] = 0;
            else if (Cursor.GetX() >= MapDisplay.GetCurrentMap().Width())
                cursor[0] = MapDisplay.GetCurrentMap().Width() - 1;
            else cursor[0] = Cursor.GetX();


            if (Cursor.GetY() < 0) cursor[1] = 0;
            else if (Cursor.GetY() >= MapDisplay.GetCurrentMap().Height())
                cursor[1] = MapDisplay.GetCurrentMap().Height() - 1;
            else cursor[1] = Cursor.GetY();


            if (mouseDown && !firstPress) {
                firstPress = true;
                head = new int[] { cursor[0], cursor[1] };
                //do a check for mouseUp
            } else if (mouseDown && firstPress) {
                tail = new int[] { cursor[0], cursor[1] };
                firstPress = false;

                //Bresenham's Line Algorithm
                // adjusted to the jagged coordinate system used.

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
                cursor[1] = head[1];
                int oldY = new int();

                for(int x=head[0]; x < tail[0]; x++) {

                    int[] selection = steep ? new int[]{ cursor[1],x } : new int[] { x, cursor[1] };

                    error -= Math.Abs(dy);
                    if (error < 0) {

                        cursor[1] += yStep;
                        error += dx;

                        //Corrections for a jagged coordinated grid.

                        // Perhaps make lines smoother, no diagonal changes.
                        if (steep) {
                            if (selection[0] % 2 == 0) MapDisplay.GetCurrentMap().TileAt(selection[0], selection[1]+1).Select();
                        } else {
                            if (dy <= 0) {
                                if (selection[0] % 2 == 1) {
                                    if(oldY == selection[1] + 1) {
                                        MapDisplay.GetCurrentMap().TileAt(selection).Select();
                                        MapDisplay.GetCurrentMap().TileAt(selection[0]+1,selection[1]).Select();
                                    }
                                    selection[1]--;
                                }
                            } else if (selection[0] % 2 == 0) {
                                if (oldY == selection[1] - 1) {
                                    MapDisplay.GetCurrentMap().TileAt(selection[0]+1, selection[1]  ).Select();
                                    MapDisplay.GetCurrentMap().TileAt(selection[0]  , selection[1]+1).Select();
                                }else selection[1]++;
                            }
                            
                        }
                    }

                    MapDisplay.GetCurrentMap().TileAt(selection).Select();

                    oldY = steep ? selection[0] : selection[1];
                }
                if(steep)MapDisplay.GetCurrentMap().TileAt(tail[1],tail[0]).Select();
                else MapDisplay.GetCurrentMap().TileAt(tail).Select();
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
