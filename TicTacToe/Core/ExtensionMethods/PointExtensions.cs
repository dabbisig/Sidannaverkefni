using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TicTacToe.Core.ExtensionMethods
{
    public static class PointExtensions
    {
        public static Point? ToTopLeft(this Point point, int square)
        {
            switch (square)
            { 
                case 1:
                    return new Point(0, 0);
                case 2:
                    return new Point(110, 0);
                case 3:
                    return new Point(220, 0);
                case 4:
                    return new Point(0, 110);
                case 5:
                    return new Point(110, 110);
                case 6:
                    return new Point(220, 110);
                case 7:
                    return new Point(0, 220);
                case 8:
                    return new Point(110, 220);
                case 9:
                    return new Point(220, 220);
                default:
                    return null;
            }
        }

        public static int ToSquareNumber(this Point point)
        {
            int x = point.X;
            int y = point.Y;
            if (x >= 0 && x <= 100 && y >= 0 && y <= 100) return 1;
            if (x >= 110 && x <= 210 && y >= 0 && y <= 100) return 2;
            if (x >= 220 && x <= 320 && y >= 0 && y <= 100) return 3;
            if (x >= 0 && x <= 100 && y >= 110 && y <= 210) return 4;
            if (x >= 110 && x <= 210 && y >= 110 && y <= 210) return 5;
            if (x >= 220 && x <= 320 && y >= 110 && y <= 210) return 6;
            if (x >= 0 && x <= 100 && y >= 220 && y <= 320) return 7;
            if (x >= 110 && x <= 210 && y >= 220 && y <= 320) return 8;
            if (x >= 220 && x <= 320 && y >= 220 && y <= 320) return 9;
            return 0;
        }
    }
}
