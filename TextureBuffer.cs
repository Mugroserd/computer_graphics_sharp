using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;

namespace Renderer
{
    class TextureBuffer
    {
        private Bitmap buffer;
        private Bitmap textureBitmap = new Bitmap("webber_diffuse4.png");
        private int width, height;
        private Random rand = new Random();

        public TextureBuffer(int width, int height)
        {
            buffer = new Bitmap(width, height);
            this.width = width;
            this.height = height;
        }

        public Bitmap GetBitmap()
        {
            return buffer;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        public void ShadeBackgroundPixel(int x, int y, Point3F point1, Point3F point2, Point3F point3, UInt32[] pointsColors, ref int zBuf)
        {
            UInt32 pixelValue;
            Point3F drawingPoint;
            drawingPoint.x = x;
            drawingPoint.y = y;
            float l1, l2, l3;

            l1 = ((point2.y - point3.y) * (x - point3.x) + (point3.x - point2.x) * (y - point3.y)) /
                ((point2.y - point3.y) * (point1.x - point3.x) + (point3.x - point2.x) * (point1.y - point3.y));
            l2 = ((point3.y - point1.y) * (x - point3.x) + (point1.x - point3.x) * (y - point3.y)) /
                ((point2.y - point3.y) * (point1.x - point3.x) + (point3.x - point2.x) * (point1.y - point3.y));
            l3 = 1 - l1 - l2;

                if (l1 >= 0 && l1 <= 1 && l2 >= 0 && l2 <= 1 && l3 >= 0 && l3 <= 1)
                {
                    drawingPoint.z = (float)(point1.z * l1 + point2.z * l2 + point3.z * l3);
                    pixelValue = (UInt32)0xFF000000 |
                            ((UInt32)(l1 * ((pointsColors[0] & 0x00FF0000) >> 16) + l2 * ((pointsColors[1] & 0x00FF0000) >> 16) + l3 * ((pointsColors[2] & 0x00FF0000) >> 16)) << 16) |
                            ((UInt32)(l1 * ((pointsColors[0] & 0x0000FF00) >> 8) + l2 * ((pointsColors[1] & 0x0000FF00) >> 8) + l3 * ((pointsColors[2] & 0x0000FF00) >> 8)) << 8) |
                            (UInt32)(l1 * (pointsColors[0] & 0x000000FF) + l2 * (pointsColors[1] & 0x000000FF) + l3 * (pointsColors[2] & 0x000000FF));
                    SetPixel(drawingPoint, pixelValue, ref zBuf);
                }
        }

        private Point3F ConvertToRange(VertexParam coordinate)
        {
            Point3F point;

            point.x = buffer.Width/2 + coordinate.values[0] * buffer.Width;

            point.y = buffer.Height/2 + coordinate.values[1] * buffer.Height;

            point.z = buffer.Height/2 + coordinate.values[2];
            return point;
        }
        
        private UInt32[] ConvertToTexture(VertexParam texturePoint1, VertexParam texturePoint2, VertexParam texturePoint3)
        {
            UInt32[] colors = new UInt32[3];

            Color tempColor = textureBitmap.GetPixel((int)(Math.Ceiling(texturePoint1.values[0] * textureBitmap.Width - 1)),
                                                     (int)(Math.Ceiling(texturePoint1.values[1] * textureBitmap.Height - 1)));
            colors[0] = (UInt32)tempColor.ToArgb();

            tempColor = textureBitmap.GetPixel((int)(Math.Ceiling(texturePoint2.values[0] * textureBitmap.Width - 1)),
                                                     (int)(Math.Ceiling(texturePoint2.values[1] * textureBitmap.Height - 1)));
            colors[1] = (UInt32)tempColor.ToArgb();

            tempColor = textureBitmap.GetPixel((int)(Math.Ceiling(texturePoint3.values[0] * textureBitmap.Width - 1)),
                                                     (int)(Math.Ceiling(texturePoint3.values[1] * textureBitmap.Height - 1)));
            colors[2] = (UInt32)tempColor.ToArgb();

            return colors;
        }

        private struct Point2D
        {
            public int x, y;
        }

        public void SetPixel(Point3F drawingPoint, UInt32 color, ref int zBuf)
        {
            if (drawingPoint.x >= 0 && drawingPoint.x < width && drawingPoint.y >= 0 && drawingPoint.y < height && drawingPoint.z < zBuf)
            {
                buffer.SetPixel((int)Math.Ceiling(drawingPoint.x), (int)Math.Ceiling(drawingPoint.y), Color.FromArgb((int)color));
                zBuf = (int)Math.Ceiling(drawingPoint.z);
            }
        }

        public void DrawTriangle(VertexParam coordinate1, VertexParam coordinate2, VertexParam coordinate3, VertexParam point1texture, VertexParam point2texture, VertexParam point3texture, ref int[,] zbuffer)
        {
            Point3F point1 = ConvertToRange(coordinate1);
            Point3F point2 = ConvertToRange(coordinate2);
            Point3F point3 = ConvertToRange(coordinate3);

            int x0 = (int)Math.Floor((Math.Min(point1.x, Math.Min(point2.x, point3.x))));
            int x1 = (int)Math.Ceiling((Math.Max(point1.x, Math.Max(point2.x, point3.x))));
            int y0 = (int)Math.Floor((Math.Min(point1.y, Math.Min(point2.y, point3.y))));
            int y1 = (int)Math.Ceiling((Math.Max(point1.y, Math.Max(point2.y, point3.y))));

            if(x0 > width || x1 > width || y0 > height || y1 > height || x0 < 0 || x1 < 0 || y0 < 0 || y1 < 0) { }
            else
            {
                for (int x = x0; x < x1; x++)
                    for (int y = y0; y < y1; y++)
                    {
                        ShadeBackgroundPixel(x, y, point1, point2, point3, ConvertToTexture(point1texture, point2texture, point3texture), ref zbuffer[x,y]);
                    }
            }
        }
    }
}
