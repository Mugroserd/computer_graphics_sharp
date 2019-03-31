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

        public void DrawPixel(int x, int y, Point3F point1, Point3F point2, Point3F point3, float[,] pointsColors, ref int zBuf)
        {
            Color pixelValue;
            Point3F drawingPoint;
            drawingPoint.x = x;
            drawingPoint.y = y;
            float l1, l2, l3;

            l1 = ((point2.y - point3.y) * (x - point3.x) + (point3.x - point2.x) * (y - point3.y)) /
                ((point2.y - point3.y) * (point1.x - point3.x) + (point3.x - point2.x) * (point1.y - point3.y));
            l2 = ((point3.y - point1.y) * (x - point3.x) + (point1.x - point3.x) * (y - point3.y)) /
                ((point2.y - point3.y) * (point1.x - point3.x) + (point3.x - point2.x) * (point1.y - point3.y));
            l3 = 1 - l1 - l2;

            if (l1 >= 0 && l2 >= 0 && l3 >= 0)
            {
                drawingPoint.z = (float)(point1.z * l1 + point2.z * l2 + point3.z * l3);
                pixelValue = textureBitmap.GetPixel(((int)(pointsColors[0, 0] * l1 + pointsColors[1, 0] * l2 + pointsColors[2, 0] * l3) % textureBitmap.Width),
                             (textureBitmap.Height - (int)(pointsColors[0, 1] * l1 + pointsColors[1, 1] * l2 + pointsColors[2, 1] * l3)) % textureBitmap.Height);
                SetPixel(drawingPoint, pixelValue, ref zBuf);
            }
        }

        private Point3F ConvertToRange(VertexParam coordinate)
        {
            Point3F point;

            point.x = width/2 + coordinate.values[0] * width;

            point.y = height/2 + coordinate.values[1] * height;

            point.z = height/2 + coordinate.values[2] * height;
            return point;
        }

        private float[,] ConvertToTexture(VertexParam[] texturePoints)
        {
            float[,] values = new float[3, 2];

            for (int i = 0; i < 3; i++)
            {
                values[i, 0] = texturePoints[i].values[0] * textureBitmap.Width;
                values[i, 1] = texturePoints[i].values[1] * textureBitmap.Height;
            }

            return values;
        }

        public void SetPixel(Point3F drawingPoint, Color color, ref int zBuf)
        {
            if (drawingPoint.z < zBuf)
            {
                buffer.SetPixel((int)Math.Ceiling(drawingPoint.x), (int)Math.Ceiling(drawingPoint.y), color);
                zBuf = (int)Math.Ceiling(drawingPoint.z);
            }
        }

        public void DrawTriangle(VertexParam coordinate1, VertexParam coordinate2, VertexParam coordinate3, VertexParam point1texture, VertexParam point2texture, VertexParam point3texture, ref int[,] zbuffer)
        {
            Point3F point1 = ConvertToRange(coordinate1);
            Point3F point2 = ConvertToRange(coordinate2);
            Point3F point3 = ConvertToRange(coordinate3);

            int x0 = (int)Math.Floor(Math.Min(point1.x, Math.Min(point2.x, point3.x)));
            int x1 = (int)Math.Ceiling(Math.Max(point1.x, Math.Max(point2.x, point3.x)));
            int y0 = (int)Math.Floor(Math.Min(point1.y, Math.Min(point2.y, point3.y)));
            int y1 = (int)Math.Ceiling(Math.Max(point1.y, Math.Max(point2.y, point3.y)));

            float[,] convertedTextureCoordinates = new float[3, 2];
            VertexParam[] verticesTextures = new VertexParam[3];
            verticesTextures[0] = point1texture;
            verticesTextures[1] = point2texture;
            verticesTextures[2] = point3texture;
            convertedTextureCoordinates = ConvertToTexture(verticesTextures);

            if ((x1 > width && y1 > height && x0 > height && y0 > height) || (x0 < 0 && x1 < 0 && y0 < 0 && y1 < 0)) return; // Проверка выхода прямоугольника за пределы рисуемого объекта
            else
            {
                x0 = x0 < 0 ? 0 : x0;   // Проверка частичного выхода прямоугольника за пределы рисуемого объекта (и исправление)
                y0 = y0 < 0 ? 0 : y0;
                x1 = x1 > width ? width : x1;
                y1 = y1 > height ? height : y1;
                for (int x = x0; x < x1; x++)
                    for (int y = y0; y < y1; y++)
                    {
                        DrawPixel(x, y, point1, point2, point3, convertedTextureCoordinates, ref zbuffer[x, y]);
                    }
            }
        }
    }
}