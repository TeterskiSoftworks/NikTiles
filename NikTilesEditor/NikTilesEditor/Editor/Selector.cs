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
            Point, Line, Box, BoxFill, BoxAlign, BoxAlignFill, Circle}
            
        //add mouse state memory here

        private static int[] head, tail;
        private static bool firstPress = false;
        private static Mode currentMode = Mode.Box;


        public static void SetCurrentMode(Mode mode) { currentMode = mode; }


        public static void Select(bool deselect, bool mouseDown) {
            switch (currentMode) {
                case Mode.Point        : PointSelect   (deselect                  ); break;
                case Mode.Line         : LineSelect    (deselect, mouseDown       ); break;
                case Mode.Box          : BoxSelect     (deselect, mouseDown, false); break;
                case Mode.BoxFill      : BoxSelect     (deselect, mouseDown, true ); break;
                case Mode.BoxAlign     : BoxAlignSelect(deselect, mouseDown, false); break;
                case Mode.BoxAlignFill : BoxAlignSelect(deselect, mouseDown, true ); break;
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
                MapDisplay.GetCurrentMap().TileAt(head).Select();
            } else if (!mouseDown && firstPress) {
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

        public static void BoxSelect(bool deselect, bool mouseDown, bool fill) {
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
                MapDisplay.GetCurrentMap().TileAt(head).Select();
            } else if (!mouseDown && firstPress) {
                tail = new int[] { cursor[0], cursor[1] };
                MapDisplay.GetCurrentMap().TileAt(tail).Select();
                //Swaps head and tail if necessary
                if (head[0] > tail[0]) {
                    int temp = head[0];
                    head[0] = tail[0]; tail[0] = temp;
                }
                if (head[1] > tail[1]) {
                    int temp = head[1];
                    head[1] = tail[1]; tail[1] = temp;
                }

                if (fill) {
                    for (int y = head[1]; y <= tail[1]; y++) {
                        for (int x = head[0]; x <= tail[0]; x++) {
                            MapDisplay.GetCurrentMap().TileAt(x, y).Select();
                        }
                    }
                } else { 
                    for (int x = head[0]; x <= tail[0]; x++) {
                        MapDisplay.GetCurrentMap().TileAt(x, head[1]).Select();
                        MapDisplay.GetCurrentMap().TileAt(x, tail[1]).Select();
                    }

                    for (int y = head[1]; y <= tail[1]; y++) {
                        MapDisplay.GetCurrentMap().TileAt(head[0], y).Select();
                        MapDisplay.GetCurrentMap().TileAt(tail[0], y).Select();
                    }
                }
                firstPress = false;
            }
        }

        public static void BoxAlignSelect(bool deselect, bool mouseDown, bool fill) {
            int[] cursor = new int[2];
            bool swapped = false;


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
                MapDisplay.GetCurrentMap().TileAt(head).Select();
            } else if (!mouseDown && firstPress) {
                firstPress = false;
                tail = new int[] { cursor[0], cursor[1] };

                //Swaps head and tail if necessary
                if (head[0] > tail[0]) {
                    int temp = head[0];
                    head[0] = tail[0]; tail[0] = temp;
                    temp = head[1];
                    head[1] = tail[1]; tail[1] = temp;
                    swapped = true;
                }

                //Checks what type of alignment is needed
                //Selection anchor is determined by
                //which point was selected first.
                if (Math.Abs(tail[1] - head[1]) < Math.Abs(tail[0] - head[0])) {


                    //Horizontally aligns the head and tail
                    if (head[0] % 2 != tail[0] % 2) {

                        if (!swapped) tail[1] = head[1];
                        else head[1] = tail[1];

                        if (head[0] % 2 != tail[0] % 2) {
                            if (swapped) head[0] += head[0]==0 ? 1 : -1;
                            else tail[0] += tail[0]==0 ? 1 : -1;
                        }

                    } else if (!swapped) tail[1] = head[1];
                    else head[1] = tail[1];

                    #region Selection On Horizontal Case.
                    //consider making it into its own function.

                    int yTop = 0, yBottom = 0;
                    bool topOverflow = false, bottomOverflow = false;
                    for (int x = 0; head[0] + x < tail[0] - x; x++) {
                        if (!topOverflow && head[1] - yTop >= 0) {
                            MapDisplay.GetCurrentMap().TileAt(head[0] + x, head[1] - yTop).Select();
                            MapDisplay.GetCurrentMap().TileAt(tail[0] - x, tail[1] - yTop).Select();
                            if ((head[0] + x) % 2 == 0) yTop++;

                        } else if (!topOverflow) topOverflow = true;

                        if (!bottomOverflow && head[1] + yBottom < MapDisplay.GetCurrentMap().Height()) {
                            MapDisplay.GetCurrentMap().TileAt(head[0] + x, head[1] + yBottom).Select();
                            MapDisplay.GetCurrentMap().TileAt(tail[0] - x, tail[1] + yBottom).Select();
                            if ((head[0] + x) % 2 == 1) yBottom++;

                        } else if (!bottomOverflow) bottomOverflow = true;

                    }

                    if (!topOverflow) MapDisplay.GetCurrentMap().TileAt((tail[0] - head[0]) / 2 + head[0], head[1] - yTop).Select();
                    if (!bottomOverflow) MapDisplay.GetCurrentMap().TileAt((tail[0] - head[0]) / 2 + head[0], head[1] + yBottom).Select();
                    #endregion


                } else {
                    if (!swapped) tail[0] = head[0];
                    else head[0] = tail[0];

                    //Swaps head and tail if necessary
                    if (head[1] > tail[1]) {
                        int temp = head[0];
                        head[0] = tail[0]; tail[0] = temp;
                        temp = head[1];
                        head[1] = tail[1]; tail[1] = temp;
                    }

                    #region Selection On Vertical Case.
                    //consider making it into its own function.
                    int yNW_SE = 0, yNE_SW = 0, xLeft = 0, xRight = 0;
                    bool leftOverflow = false, rightOverflow = false;
                    for (int y = 0; head[1] + y < tail[1] - y; y++) {
                        if (!leftOverflow && head[0] - xLeft >= 0) {
                            MapDisplay.GetCurrentMap().TileAt(head[0] - xLeft, head[1] + y - yNW_SE).Select();


                            if ((head[0] + xLeft) % 2 == 0) {
                                MapDisplay.GetCurrentMap().TileAt(tail[0] - xLeft -2, tail[1] - y + yNE_SW).Select();
                            } else {
                                MapDisplay.GetCurrentMap().TileAt(tail[0] - xLeft, tail[1] - y + yNE_SW).Select();
                            }

                            xLeft++;
                            if ((head[0] + xLeft) % 2 == 1) yNW_SE++;
                            
                            

                        } else if (!leftOverflow) leftOverflow = true;

                        if (!rightOverflow && head[0] + xRight < MapDisplay.GetCurrentMap().Width()) {
                            MapDisplay.GetCurrentMap().TileAt(head[0] + xRight, head[1] + y - yNE_SW).Select();
                            MapDisplay.GetCurrentMap().TileAt(tail[0] + xRight, tail[1] - y + yNW_SE).Select();
                            xRight++;
                            if ((head[0] + xRight) % 2 == 1) {
                                yNE_SW++;
                            }


                        } else if (!rightOverflow) rightOverflow = true;

                    }

                   // if (!leftOverflow)  MapDisplay.GetCurrentMap().TileAt( head[0]-xLeft , (tail[1]-head[1])/2 +head[1] ).Select();
                   // if (!rightOverflow) MapDisplay.GetCurrentMap().TileAt( head[0]+xRight, (tail[1]-head[1])/2 +head[1] ).Select();
                    #endregion

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
