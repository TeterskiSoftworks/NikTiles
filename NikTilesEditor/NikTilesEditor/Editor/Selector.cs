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
            Point, Line, Box, BoxFill, BoxAlign, BoxAlignFill, Circle }

        private static int[] head, tail;
        private static int width = 1;
        private static bool firstPress = false, deselect=false,mouseDown=false;
        private static Mode currentMode = Mode.Point;


        public static void SetMode(Mode mode) { currentMode = mode; }
        public static void Deselect(bool deselect) { Selector.deselect = deselect; }
        public static bool Deselect() { return deselect; }  //rename
        public static void MouseDown(bool mouseDown) { Selector.mouseDown = mouseDown; }
        public static bool MouseDown() { return mouseDown; }

        public static void Select() {
            switch (currentMode) {
                case Mode.Point: PointSelect(); break;
                case Mode.Line:  LineSelect(); break;

                case Mode.Box:     BoxSelect(width); break;
                case Mode.BoxFill: BoxSelect(-1); break;

                case Mode.BoxAlign:     BoxAlignSelect(width); break;
                case Mode.BoxAlignFill: BoxAlignSelect(-1); break;
            }

        }

        //!!!!!!!!! add summeries to the entire file.

        public static void PointSelect() {
            int y = Cursor.GetY();
            int x = Cursor.GetX();
            if (y >= 0 && y < MapDisplay.GetCurrentMap().Height() && x >= 0 && x < MapDisplay.GetCurrentMap().Width())
                MapDisplay.GetCurrentMap().TileAt(x, y).Select();
        }

        //add width?
        public static void LineSelect() {
            int[] cursor = GetCursor();


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
                int yStep = (head[1] < tail[1] ? yStep = 1 : yStep = -1);

                //Iterate over bounding box generating points between head and tail
                cursor[1] = head[1];
                int oldY = new int();
                for (int x = head[0]; x < tail[0]; x++) {

                    int[] selection = steep ? new int[] { cursor[1], x } : new int[] { x, cursor[1] };

                    error -= Math.Abs(dy);
                    if (error < 0) {

                        cursor[1] += yStep;
                        error += dx;

                        //Corrections for a jagged coordinated grid.

                        if (steep) {
                            if (selection[0] % 2 == 0) MapDisplay.GetCurrentMap().TileAt(selection[0], selection[1] + 1).Select();
                        } else {
                            if (dy <= 0) {
                                if (selection[0] % 2 == 1) {
                                    if (oldY == selection[1] + 1) {
                                        MapDisplay.GetCurrentMap().TileAt(selection).Select();
                                        MapDisplay.GetCurrentMap().TileAt(selection[0] + 1, selection[1]).Select();
                                    }
                                    selection[1]--;
                                }
                            } else if (selection[0] % 2 == 0) {
                                if (oldY == selection[1] - 1) {
                                    MapDisplay.GetCurrentMap().TileAt(selection[0] + 1, selection[1]).Select();
                                    MapDisplay.GetCurrentMap().TileAt(selection[0], selection[1] + 1).Select();
                                } else selection[1]++;
                            }

                        }
                    }

                    MapDisplay.GetCurrentMap().TileAt(selection).Select();

                    oldY = steep ? selection[0] : selection[1];
                }

                if (steep) {
                    MapDisplay.GetCurrentMap().TileAt(head[1], head[0]).Select();
                    MapDisplay.GetCurrentMap().TileAt(tail[1], tail[0]).Select();
                } else {
                    MapDisplay.GetCurrentMap().TileAt(head).Select();
                    MapDisplay.GetCurrentMap().TileAt(tail).Select();
                }

            }
        }

        public static void BoxSelect(int width) {
            int[] cursor = GetCursor();

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

                for (int xOffset = 0, yOffset=0; xOffset < width; xOffset++, yOffset++) {
                    if(head[1]+yOffset<tail[1]) for (int x = head[0]; x <= tail[0]; x++) {
                        MapDisplay.GetCurrentMap().TileAt(x, head[1]+yOffset).Select();
                        MapDisplay.GetCurrentMap().TileAt(x, tail[1]-yOffset).Select();
                    }
                    if (head[0]+xOffset < tail[0]) for (int y = head[1]; y <= tail[1]; y++) {
                        MapDisplay.GetCurrentMap().TileAt(head[0]+xOffset, y).Select();
                        MapDisplay.GetCurrentMap().TileAt(tail[0]-xOffset, y).Select();
                    }
                }
                firstPress = false;
            }
        }

        public static void BoxAlignSelect(int width) {
            int[] cursor = GetCursor();
            bool swapped = false;

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
                            if (swapped) head[0] += head[0] == 0 ? 1 : -1;
                            else tail[0] += tail[0] == 0 ? 1 : -1;
                        }

                    } else if (!swapped) tail[1] = head[1];
                    else head[1] = tail[1];

                    BoxAlignHorizontal(width, head, tail);


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

                    BoxAlignVertical(width,head,tail);

                }


            }
        }

        public static void BoxAlignHorizontal(int width, int[] start, int[] end) {

            int yTop = 0, yBottom = 0;
            bool topOverflow = false, bottomOverflow = false;
            for (int x = 0; start[0] + x < end[0] - x; x++) {
                if (!topOverflow && start[1] - yTop >= 0) {
                    MapDisplay.GetCurrentMap().TileAt(start[0] + x, start[1] - yTop).Select();
                    MapDisplay.GetCurrentMap().TileAt(end[0] - x, end[1] - yTop).Select();
                    if ((start[0] + x) % 2 == 0) yTop++;

                } else if (!topOverflow) topOverflow = true;

                if (!bottomOverflow && start[1] + yBottom < MapDisplay.GetCurrentMap().Height()) {
                    MapDisplay.GetCurrentMap().TileAt(start[0] + x, start[1] + yBottom).Select();
                    MapDisplay.GetCurrentMap().TileAt(end[0] - x, end[1] + yBottom).Select();
                    if ((start[0] + x) % 2 == 1) yBottom++;

                } else if (!bottomOverflow) bottomOverflow = true;

            }

            if (!topOverflow && start[1]-yTop>=0)
                MapDisplay.GetCurrentMap().TileAt((end[0] - start[0]) / 2 + start[0], start[1] - yTop).Select();
            if (!bottomOverflow && start[1]+yBottom<MapDisplay.GetCurrentMap().Height())
                MapDisplay.GetCurrentMap().TileAt((end[0] - start[0]) / 2 + start[0], start[1] + yBottom).Select();

            if (width != 1 && start[0] != end[0]) {
                BoxAlignHorizontal(width - 1, new int[] { start[0] + 2, start[1] }, new int[] { end[0] - 2, end[1] });
            }
        }

        public static void BoxAlignVertical(int width, int[] start, int[] end) {
            int yNW = 0, yNE = 0, ySW = 0, ySE = 0, xLeft = 0, xRight = 0;
            bool leftOverflow = false, rightOverflow = false;

            for (int y = 0; start[1] + y < end[1]; y++) {
                if (!leftOverflow && start[0] - xLeft >= 0) {
                    MapDisplay.GetCurrentMap().TileAt(start[0] -xLeft, start[1] +y-yNW).Select();
                    MapDisplay.GetCurrentMap().TileAt(end[0]   -xLeft, end[1]   -y+yNE).Select();
                    xLeft++;
                    if ((start[0] + xLeft) % 2 == 1) yNW++;
                    else yNE++;

                } else if (!leftOverflow) leftOverflow = true;

                if (!rightOverflow && start[0] + xRight < MapDisplay.GetCurrentMap().Width()) {
                    MapDisplay.GetCurrentMap().TileAt(start[0] +xRight, start[1] +y-ySW).Select();
                    MapDisplay.GetCurrentMap().TileAt(end[0]   +xRight, end[1]   -y+ySE).Select();
                    xRight++;
                    if ((start[0] + xRight) % 2 == 1) ySW++;
                    else ySE++;

                } else if (!rightOverflow) rightOverflow = true;

            }

            if (!leftOverflow && start[0]-xLeft >= 0) {
                if (start[0]%2 == 1 && (start[0] + xLeft) % 2 == 0) MapDisplay.GetCurrentMap().TileAt(start[0] - xLeft, (end[1] - start[1]) / 2 + start[1] +1).Select();
                else MapDisplay.GetCurrentMap().TileAt(start[0] - xLeft, (end[1] - start[1]) / 2 + start[1]).Select();
            }
            if (!rightOverflow && start[0]+xRight < MapDisplay.GetCurrentMap().Width()) {
                if (start[0] % 2 == 1 && (start[0] + xRight) % 2 == 0) MapDisplay.GetCurrentMap().TileAt(start[0] + xRight, (end[1] - start[1]) / 2 + start[1] + 1).Select();
                else MapDisplay.GetCurrentMap().TileAt(start[0] + xRight, (end[1] - start[1]) / 2 + start[1]).Select();
            }

            if(width!=1 && start[1] != end[1] && start[1]+1 != end[1]) BoxAlignVertical(width-1, new int[] { start[0], start[1]+1 }, new int[] { end[0], end[1]-1 });
        }

        public static int[] GetCursor() {
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


            return cursor;
        }

        public static void SelectAll() {
            for (int y = 0; y < MapDisplay.GetCurrentMap().Height(); y++) {
                for (int x = 0; x < MapDisplay.GetCurrentMap().Width(); x++) {
                    MapDisplay.GetCurrentMap().TileAt(x, y).Select();
                }
            }
        }

        public static void DeselectAll() {
            for (int y = 0; y < MapDisplay.GetCurrentMap().Height(); y++)
                for (int x = 0; x < MapDisplay.GetCurrentMap().Width(); x++)
                    MapDisplay.GetCurrentMap().TileAt(x, y).Select(false);
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
