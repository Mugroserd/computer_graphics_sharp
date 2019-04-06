using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;
using System.Drawing.Imaging;

namespace Renderer
{
    class TextureBuffer
    {
        private Bitmap bitmap;
        private BitmapData data;
        private int width, height;

        public TextureBuffer(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            this.width = width;
            this.height = height;
        }

        public TextureBuffer(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            width = bitmap.Width;
            height = bitmap.Height;
        }

        public void Open()
        {
            data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        }

        public void Close()
        {
            bitmap.UnlockBits(data);
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public int Width { get { return width; } }

        public int Height { get { return height; } }

        public void SetPixel(float x, float y, float z, Color color, ref float zBuf)
        {
            int bitmapCoordX = (int)(width * x);
            int bitmapCoordY = height - (int)(height * y);
            if (z < zBuf && bitmapCoordX > 0 && bitmapCoordX < width && bitmapCoordY > 0 && bitmapCoordY < height)
            {
                bitmap.SetPixel(bitmapCoordX, bitmapCoordY, color);
                zBuf = z;
            }
        }

        public unsafe void SetPixel(int x, int y, float z, Color color, ref float zBuf)
        {
            if (z < zBuf && x > 0 && x < width && y > 0 && y < height)
            {
                zBuf = z;
                int stride = data.Stride;
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;
                    ptr[(x * 3) + y * stride] = color.B;
                    ptr[(x * 3) + y * stride + 1] = color.G;
                    ptr[(x * 3) + y * stride + 2] = color.R;
                }
                // bitmap.SetPixel(x, y, color);
            }
        }

        public Color GetPixel(float x, float y)
        {
            return bitmap.GetPixel((int)(width * x) % width, (height - (int)(height * y)) % height);
        }
    }
}