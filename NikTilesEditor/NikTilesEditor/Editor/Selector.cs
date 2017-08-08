using NikTiles.Editor.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NikTiles.Engine;
using Microsoft.Xna.Framework;

namespace NikTiles.Editor {
    public static class Selector {

        /// <summary>
        /// The mode refers to how the selector functions. E.i. point selection, line selection, etc.
        /// </summary>
        public enum Modes { Point, Line, Box, BoxAlign, Circle }

        private static int[] head, tail;
        private static int width = 1;
        private static bool firstPress = false, deselect=false,mouseDown=false;
        private static Modes currentMode = Modes.Point;

        public static Modes Mode { set { currentMode = value; } get { return currentMode; } }

        public static bool Deselect { get { return deselect; } set { deselect = value; } }

        public static bool MouseDown { get { return mouseDown; } set { mouseDown = value;  } }

        public static void Select() {
            switch (currentMode) {
                case Modes.Point:    PointSelect();         break;
                case Modes.Line:     LineSelect();          break;
                case Modes.Box:      BoxSelect(width);      break;
                case Modes.BoxAlign: BoxAlignSelect(width); break;
            }

        }

        private static void PointSelect() {
            switch (MapEditor.Mode) {

                #region Floor

                case MapEditor.Modes.Floor:
                    if (Cursor.Y >= 0 && Cursor.Y < MapDisplay.CurrentMap.Height &&
                    Cursor.X >= 0 && Cursor.X < MapDisplay.CurrentMap.Width)
                        MapDisplay.CurrentMap.TileAt(Cursor.X, Cursor.Y).SelectFloor(!Deselect);
                    break;

                    #endregion

                #region Wall
                case MapEditor.Modes.Wall:
                    if (Cursor.Y >= 0 && Cursor.Y < MapDisplay.CurrentMap.Height &&
                        Cursor.X >= 0 && Cursor.X < MapDisplay.CurrentMap.Width) {
                        if (Cursor.X % 2 == 1) {
                            if (Cursor.MouseMapPosition == Color.Red)
                                MapDisplay.CurrentMap.TileAt(Cursor.X + 1, Cursor.Y + 1).SelectWall(!Deselect,false);
                            else if (Cursor.MouseMapPosition == Color.Yellow)
                                MapDisplay.CurrentMap.TileAt(Cursor.X - 1, Cursor.Y + 1).SelectWall(!Deselect,true);
                            else
                                MapDisplay.CurrentMap.TileAt(Cursor.X, Cursor.Y).SelectWall(!Deselect,Cursor.MouseMapPosition == Color.Green);
                        } else {
                            if (Cursor.MouseMapPosition == Color.Aqua)
                                MapDisplay.CurrentMap.TileAt(Cursor.X + 1, Cursor.Y).SelectWall(!Deselect,false);
                            else if (Cursor.MouseMapPosition == Color.LawnGreen)
                                MapDisplay.CurrentMap.TileAt(Cursor.X - 1, Cursor.Y).SelectWall(!Deselect,true);
                            else
                                MapDisplay.CurrentMap.TileAt(Cursor.X, Cursor.Y).SelectWall(!Deselect,Cursor.MouseMapPosition == Color.Gold);
                        }
                    }
                    break;
                    #endregion
            }
        }

        //add width?
        private static void LineSelect() {
            int[] cursor = GetCursor();


            if (mouseDown && !firstPress) {
                firstPress = true;
                head = new int[] { cursor[0], cursor[1] };
                switch (MapEditor.Mode) {
                    case MapEditor.Modes.Floor:
                        MapDisplay.CurrentMap.TileAt(head).SelectFloor(!Deselect);
                        break;

                    case MapEditor.Modes.Wall:
                        //MapDisplay.CurrentMap.TileAt(head).SelectWalls(!Deselect);
                        break;
                }
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

                        //Corrected for a jagged coordinated grid.

                        if (steep) {
                            if (selection[0] % 2 == 0) {
                                switch (MapEditor.Mode) {
                                    case MapEditor.Modes.Floor:
                                        MapDisplay.CurrentMap.TileAt(selection[0], selection[1] + 1).SelectFloor(!Deselect);
                                        break;
                                    case MapEditor.Modes.Wall:
                                        if (dy <= 0) {
                                            MapDisplay.CurrentMap.TileAt(selection[0], selection[1] + 1).SelectWall(!Deselect, false);
                                            MapDisplay.CurrentMap.TileAt(selection[0] - 1, selection[1]).SelectWall(!Deselect, true);
                                        } else {
                                            MapDisplay.CurrentMap.TileAt(selection[0] + 1, selection[1]).SelectWall(!Deselect, false);
                                            MapDisplay.CurrentMap.TileAt(selection[0], selection[1] + 1).SelectWall(!Deselect, true);
                                        }
                                        break;
                                }
                            }
                        } else {
                            if (dy <= 0) {
                                if (selection[0] % 2 == 1) {
                                    if (oldY == selection[1] + 1) {
                                        switch (MapEditor.Mode) {
                                            case MapEditor.Modes.Floor:
                                                MapDisplay.CurrentMap.TileAt(selection).SelectFloor(!Deselect);
                                                MapDisplay.CurrentMap.TileAt(selection[0] + 1, selection[1]).SelectFloor(!Deselect);
                                                break;
                                            case MapEditor.Modes.Wall:
                                                MapDisplay.CurrentMap.TileAt(selection).SelectWall(!Deselect,false);
                                                MapDisplay.CurrentMap.TileAt(selection[0] - 1, selection[1]).SelectWall(!Deselect,true);
                                                break;
                                        }
                                    }
                                    selection[1]--;
                                }
                            } else if (selection[0] % 2 == 0) {
                                if (oldY == selection[1] - 1) {
                                    switch (MapEditor.Mode) {
                                        case MapEditor.Modes.Floor:
                                            MapDisplay.CurrentMap.TileAt(selection[0] + 1, selection[1]).SelectFloor(!Deselect);
                                            MapDisplay.CurrentMap.TileAt(selection[0], selection[1] + 1).SelectFloor(!Deselect);
                                            break;
                                        case MapEditor.Modes.Wall:
                                            MapDisplay.CurrentMap.TileAt(selection[0] + 2, selection[1] + 1).SelectWall(!Deselect,false);
                                            MapDisplay.CurrentMap.TileAt(selection[0] + 1, selection[1] + 1).SelectWall(!Deselect,true);
                                            break;
                                    }
                                } else selection[1]++;
                            }

                        }
                    }
                    switch (MapEditor.Mode) {
                        case MapEditor.Modes.Floor:
                            MapDisplay.CurrentMap.TileAt(selection).SelectFloor(!Deselect);
                            break;
                        case MapEditor.Modes.Wall:
                            if(dy <=0) MapDisplay.CurrentMap.TileAt(selection[0], selection[1]).SelectWall(!Deselect,false);
                            else       MapDisplay.CurrentMap.TileAt(selection[0], selection[1]).SelectWall(!Deselect,true);
                            break;
                    }

                    oldY = steep ? selection[0] : selection[1];
                }

                switch (MapEditor.Mode) {
                    case MapEditor.Modes.Floor:
                        if (steep) {
                            MapDisplay.CurrentMap.TileAt(head[1], head[0]).SelectFloor(!Deselect);
                            MapDisplay.CurrentMap.TileAt(tail[1], tail[0]).SelectFloor(!Deselect);
                        } else {
                            MapDisplay.CurrentMap.TileAt(head).SelectFloor(!Deselect);
                            MapDisplay.CurrentMap.TileAt(tail).SelectFloor(!Deselect);
                        }
                        break;
                    case MapEditor.Modes.Wall:
                        //NEXT!
                        //if (steep) {
                        //    MapDisplay.CurrentMap.TileAt(head[1], head[0]).SelectWalls(!Deselect);
                        //    MapDisplay.CurrentMap.TileAt(tail[1], tail[0]).SelectWalls(!Deselect);
                        //} else {
                        //    MapDisplay.CurrentMap.TileAt(head).SelectWalls(!Deselect);
                        //    MapDisplay.CurrentMap.TileAt(tail).SelectWalls(!Deselect);
                        //}
                        break;
                }

            }
        }

        private static void BoxSelect(int width) {
            int[] cursor = GetCursor();

            //Check if inbounds
            if (Cursor.X < 0) cursor[0] = 0;
            else if (Cursor.X >= MapDisplay.CurrentMap.Width)
                cursor[0] = MapDisplay.CurrentMap.Width - 1;
            else cursor[0] = Cursor.X;


            if (Cursor.Y < 0) cursor[1] = 0;
            else if (Cursor.Y >= MapDisplay.CurrentMap.Height)
                cursor[1] = MapDisplay.CurrentMap.Height - 1;
            else cursor[1] = Cursor.Y;


            if (mouseDown && !firstPress) {
                firstPress = true;
                head = new int[] { cursor[0], cursor[1] };
                MapDisplay.CurrentMap.TileAt(head).SelectFloor(!Deselect);
            } else if (!mouseDown && firstPress) {
                tail = new int[] { cursor[0], cursor[1] };
                MapDisplay.CurrentMap.TileAt(tail).SelectFloor(!Deselect);
                //Swaps head and tail if necessary
                if (head[0] > tail[0]) {
                    int temp = head[0];
                    head[0] = tail[0]; tail[0] = temp;
                }
                if (head[1] > tail[1]) {
                    int temp = head[1];
                    head[1] = tail[1]; tail[1] = temp;
                }

                if (width < 0) {
                    for (int y = head[1]; y <= tail[1]; y++) for (int x = head[0]; x <= tail[0]; x++)
                        MapDisplay.CurrentMap.TileAt(x, y).SelectFloor(!Deselect);
                } else for (int xOffset = 0, yOffset = 0; xOffset < width; xOffset++, yOffset++) {
                        if (head[1] + yOffset < tail[1]) for (int x = head[0]; x <= tail[0]; x++) {
                                MapDisplay.CurrentMap.TileAt(x, head[1] + yOffset).SelectFloor(!Deselect);
                                MapDisplay.CurrentMap.TileAt(x, tail[1] - yOffset).SelectFloor(!Deselect);
                            }
                        if (head[0] + xOffset < tail[0]) for (int y = head[1]; y <= tail[1]; y++) {
                                MapDisplay.CurrentMap.TileAt(head[0] + xOffset, y).SelectFloor(!Deselect);
                                MapDisplay.CurrentMap.TileAt(tail[0] - xOffset, y).SelectFloor(!Deselect);
                            }
                    }
                firstPress = false;
            }
        }

        private static void BoxAlignSelect(int width) {
            int[] cursor = GetCursor();
            bool swapped = false;

            if (mouseDown && !firstPress) {
                firstPress = true;
                head = new int[] { cursor[0], cursor[1] };
                MapDisplay.CurrentMap.TileAt(head).SelectFloor(!Deselect);
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

        private static void BoxAlignHorizontal(int width, int[] start, int[] end) {

            int yTop = 0, yBottom = 0;
            bool topOverflow = false, bottomOverflow = false;
            for (int x = 0; start[0] + x < end[0] - x; x++) {
                if (!topOverflow && start[1] - yTop >= 0) {
                    MapDisplay.CurrentMap.TileAt(start[0] + x, start[1] - yTop).SelectFloor(!Deselect);
                    MapDisplay.CurrentMap.TileAt(end[0] - x, end[1] - yTop).SelectFloor(!Deselect);
                    if ((start[0] + x) % 2 == 0) yTop++;

                } else if (!topOverflow) topOverflow = true;

                if (!bottomOverflow && start[1] + yBottom < MapDisplay.CurrentMap.Height) {
                    MapDisplay.CurrentMap.TileAt(start[0] + x, start[1] + yBottom).SelectFloor(!Deselect);
                    MapDisplay.CurrentMap.TileAt(end[0] - x, end[1] + yBottom).SelectFloor(!Deselect);
                    if ((start[0] + x) % 2 == 1) yBottom++;

                } else if (!bottomOverflow) bottomOverflow = true;

            }

            if (!topOverflow && start[1]-yTop>=0)
                MapDisplay.CurrentMap.TileAt((end[0] - start[0]) / 2 + start[0], start[1] - yTop).SelectFloor(!Deselect);
            if (!bottomOverflow && start[1]+yBottom<MapDisplay.CurrentMap.Height)
                MapDisplay.CurrentMap.TileAt((end[0] - start[0]) / 2 + start[0], start[1] + yBottom).SelectFloor(!Deselect);

            if (width != 1 && start[0] != end[0] && start[0]+2 != end[0]) {
                BoxAlignHorizontal(width - 1, new int[] { start[0] + 2, start[1] }, new int[] { end[0] - 2, end[1] });
            }
        }

        private static void BoxAlignVertical(int width, int[] start, int[] end) {
            int yNW = 0, yNE = 0, ySW = 0, ySE = 0, xLeft = 0, xRight = 0;
            bool leftOverflow = false, rightOverflow = false;

            for (int y = 0; start[1] + y < end[1]; y++) {
                if (!leftOverflow && start[0] - xLeft >= 0) {
                    MapDisplay.CurrentMap.TileAt(start[0] -xLeft, start[1] +y-yNW).SelectFloor(!Deselect);
                    MapDisplay.CurrentMap.TileAt(end[0]   -xLeft, end[1]   -y+yNE).SelectFloor(!Deselect);
                    xLeft++;
                    if ((start[0] + xLeft) % 2 == 1) yNW++;
                    else yNE++;

                } else if (!leftOverflow) leftOverflow = true;

                if (!rightOverflow && start[0] + xRight < MapDisplay.CurrentMap.Width) {
                    MapDisplay.CurrentMap.TileAt(start[0] +xRight, start[1] +y-ySW).SelectFloor(!Deselect);
                    MapDisplay.CurrentMap.TileAt(end[0]   +xRight, end[1]   -y+ySE).SelectFloor(!Deselect);
                    xRight++;
                    if ((start[0] + xRight) % 2 == 1) ySW++;
                    else ySE++;

                } else if (!rightOverflow) rightOverflow = true;

            }

            if (!leftOverflow && start[0]-xLeft >= 0) {
                if (start[0]%2 == 1 && (start[0] + xLeft) % 2 == 0) MapDisplay.CurrentMap.TileAt(start[0] - xLeft, (end[1] - start[1]) / 2 + start[1] +1).SelectFloor(!Deselect);
                else MapDisplay.CurrentMap.TileAt(start[0] - xLeft, (end[1] - start[1]) / 2 + start[1]).SelectFloor(!Deselect);
            }
            if (!rightOverflow && start[0]+xRight < MapDisplay.CurrentMap.Width) {
                if (start[0] % 2 == 1 && (start[0] + xRight) % 2 == 0) MapDisplay.CurrentMap.TileAt(start[0] + xRight, (end[1] - start[1]) / 2 + start[1] + 1).SelectFloor(!Deselect);
                else MapDisplay.CurrentMap.TileAt(start[0] + xRight, (end[1] - start[1]) / 2 + start[1]).SelectFloor(!Deselect);
            }

            if(width!=1 && start[1] != end[1] && start[1]+1 != end[1]) BoxAlignVertical(width-1, new int[] { start[0], start[1]+1 }, new int[] { end[0], end[1]-1 });
        }

        private static int[] GetCursor() {
            int[] cursor = new int[2];

            //Check if inbounds
            if (Cursor.X < 0) cursor[0] = 0;
            else if (Cursor.X >= MapDisplay.CurrentMap.Width)
                cursor[0] = MapDisplay.CurrentMap.Width - 1;
            else cursor[0] = Cursor.X;


            if (Cursor.Y < 0) cursor[1] = 0;
            else if (Cursor.Y >= MapDisplay.CurrentMap.Height)
                cursor[1] = MapDisplay.CurrentMap.Height - 1;
            else cursor[1] = Cursor.Y;


            return cursor;
        }

        public static void SelectAll() {
            for (int y = 0; y < MapDisplay.CurrentMap.Height; y++) {
                for (int x = 0; x < MapDisplay.CurrentMap.Width; x++) {
                    MapDisplay.CurrentMap.TileAt(x, y).SelectFloor(true);
                }
            }
        }

        public static void DeselectAll() {
            for (int y = 0; y < MapDisplay.CurrentMap.Height; y++)
                for (int x = 0; x < MapDisplay.CurrentMap.Width; x++)
                    MapDisplay.CurrentMap.TileAt(x, y).Select(false);
        }

        public static void InverseSelection() {
            for (int y = 0; y < MapDisplay.CurrentMap.Height; y++) {
                for (int x = 0; x < MapDisplay.CurrentMap.Width; x++) {
                    MapDisplay.CurrentMap.TileAt(x, y).InverseSelection();
                }
            }
        }

        public static int Width { set { width = value; } }

        public static void ApplyFloorMaterial(string material) {
            for (int y = 0; y < MapDisplay.CurrentMap.Height; y++) {
                for (int x = 0; x < MapDisplay.CurrentMap.Width; x++) {
                    if(MapDisplay.CurrentMap.TileAt(x,y).Selected)
                        MapDisplay.CurrentMap.TileAt(x, y).Material = material;
                }
            }
        }


    }
}
