﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Calculator
{
    public static class RoomData
    {
        private static double METRIC_PAINT_RATIO = 0.1;
        private static double CENTRE_SQUARE_SIZE = 10; //Size in pixels of debug centre square
        private static double VERTEX_SIZE = 10; //Size in pixels of room vertices
        private static double BASE_ROOM_PIXEL_SIZE = 300;
        public class Square
        {
            //Room Data
            private double width, length, height;
            //Visual Display Settings
            private Canvas outputCanvas;
            private Label centreSquare;
            //Shapes Data
            private Edge[] edges;
            private Vertex[] vertices;

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
            public Canvas Canvas
            {
                get { return outputCanvas; }
                set 
                { 
                    outputCanvas = value;
                    UpdateVertexPositions();
                    UpdateEdgePositions();
                }
            }

            public int XPos
            {
                get { return (int)outputCanvas.Width / 2; }
            }

            public int YPos
            {
                get { return (int)outputCanvas.Height / 2; }
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

            public void SetDimensions(double width, double length, double height)
            {
                this.width = width;
                this.length = length;                
                this.height = height;
            }

            /// <summary>
            /// Debug function to see the centre of a room
            /// </summary>
            /// <param name="value"></param>
            public void ToggleCentreSquare(bool value)
            {
                //Instantiate Centre Square if not done already
                if (centreSquare == null)
                {
                    centreSquare = new Label();
                    centreSquare.Width = CENTRE_SQUARE_SIZE;
                    centreSquare.Height = CENTRE_SQUARE_SIZE;
                    centreSquare.Background = Brushes.Red;
                    outputCanvas.Children.Add(centreSquare);
                }

                if (!value) 
                { 
                    centreSquare.Visibility = Visibility.Hidden; 
                    return; 
                }
                else
                {
                    centreSquare.Visibility = Visibility.Visible;
                }

                //Calculates the centre of the room and accounts for debug square size
                double centreX = XPos - (CENTRE_SQUARE_SIZE / 2);
                double centreY = YPos - (CENTRE_SQUARE_SIZE / 2);
                Canvas.SetLeft(centreSquare, centreX);
                Canvas.SetTop(centreSquare, centreY);
            }

            private void UpdateVertexPositions()
            {
                vertices = new Vertex[4];
                for (int i = 0; i < 4; i++)
                {
                    vertices[i] = new Vertex(outputCanvas);
                }

                int halfSize = (int)BASE_ROOM_PIXEL_SIZE / 2;

                vertices[0].SetPosition(XPos - halfSize, YPos + halfSize);
                vertices[1].SetPosition(XPos + halfSize, YPos + halfSize);
                vertices[2].SetPosition(XPos - halfSize, YPos - halfSize);
                vertices[3].SetPosition(XPos + halfSize, YPos - halfSize);
            }

            private void UpdateEdgePositions()
            {
                edges = new Edge[4];

                //Layed out directionally so resizing label works correctly
                edges[0] = new Edge(vertices[0], vertices[1], outputCanvas);
                edges[1] = new Edge(vertices[1], vertices[3], outputCanvas);
                edges[2] = new Edge(vertices[2], vertices[3], outputCanvas);
                edges[3] = new Edge(vertices[0], vertices[2], outputCanvas);
            }
        }

        /// <summary>
        /// Represents the connection between 2 vertices
        /// <para>v1 (Start) - v2 (End)</para>
        /// </summary>
        private class Edge
        {
            private Vertex v1, v2;
            private Label visualComponent;
            private Canvas outputCanvas;

            public Edge(Vertex v1, Vertex v2, Canvas outputCanvas)
            {
                this.v1 = v1;
                this.v2 = v2;

                this.outputCanvas = outputCanvas;

                visualComponent = new Label();
                visualComponent.Background = Brushes.LightGray;
                outputCanvas.Children.Add(visualComponent);

                SetPosition();
            }

            public void SetPosition()
            {
                //If y value is equal the edge is horizontal
                if (v1.Y == v2.Y)
                {
                    visualComponent.Width = v2.X - v1.X;
                    visualComponent.Height = VERTEX_SIZE;
                    Canvas.SetTop(visualComponent, v1.Y);
                    Canvas.SetLeft(visualComponent, v1.X);
                }
                //Otherwise the edge is vertical
                else
                {
                    visualComponent.Width = VERTEX_SIZE;
                    visualComponent.Height = v1.Y - v2.Y;
                    Canvas.SetTop(visualComponent, v2.Y);
                    Canvas.SetLeft(visualComponent, v2.X);
                }
            }
        }

        /// <summary>
        /// Represents point on a canvas
        /// </summary>
        private class Vertex
        {
            private int x, y;
            private Label visualComponent;
            private Canvas outputCanvas;

            public Vertex(Canvas outputCanvas)
            {
                x = 0; 
                y = 0;

                visualComponent = new Label();
                visualComponent.Width = VERTEX_SIZE;
                visualComponent.Height = VERTEX_SIZE;
                visualComponent.Background = Brushes.Black;

                this.outputCanvas = outputCanvas;
                outputCanvas.Children.Add(visualComponent);
                Canvas.SetZIndex(visualComponent, 1);
            }

            public void SetPosition(int x, int y)
            {
                this.x = x;
                this.y = y;

                Canvas.SetTop(visualComponent, y);
                Canvas.SetLeft(visualComponent, x);
            }

            public int X
            {
                get { return x; }
            }

            public int Y
            {
                get { return y; }
            }
        }
    }
}
