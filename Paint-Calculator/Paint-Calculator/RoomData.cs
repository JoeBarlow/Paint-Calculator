using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paint_Calculator
{
    public static class RoomData
    {
        private static double METRIC_PAINT_RATIO = 0.1;
        public class Square
        {
            double width, length, height;

            public Square(double width = 0, double length = 0, double height = 0)
            {
                this.width = width;
                this.length = length;
                this.height = height;
            }

            /// <summary>
            /// Returns area of the floor
            /// </summary>
            public double Area
            {
                get { return Math.Round(width * length, 2); }
            }

            /// <summary>
            /// Returns volume of the room
            /// </summary>
            public double Volume
            {
                get { return Math.Round(width * length * height, 2); }
            }

            /// <summary>
            /// Returns the area of all walls combined
            /// </summary>
            public double TotalWallArea
            {
                get 
                {
                    double area = (width * height * 2) + (length * height * 2);
                    return Math.Round(area, 2); 
                }
            }

            /// <summary>
            /// Calculates the required paint in litres per metre square of wall
            /// </summary>
            /// <param name="coats"></param>
            /// <returns></returns>
            public double GetPaintRequirement(int numCoats = 1)
            {
                double paint = TotalWallArea * METRIC_PAINT_RATIO * numCoats;
                return Math.Round(paint, 2);
            }
        }

        private class Edge
        {

        }

        private class Vertex
        { 
            
        }
    }
}
