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
        public class Square
        {
            double width, length, height;

            public Square(double width = 0, double length = 0, double height = 0)
            {
                this.width = width;
                this.length = length;
                this.height = height;
            }

            public double Area
            {
                get { return width * length; }
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
