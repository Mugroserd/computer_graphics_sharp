using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    class Mesh
    {
        private List<Triangle> triangles;

        public Mesh(List<Triangle> triangles)
        {
            this.triangles = triangles;
        }

        public void DrawWire(TextureBuffer target, Matrix4 transformationMatrix, Color color)
        {
            int[,] zbuffer = new int[640, 640];
            for (int i = 0; i < 640; i++)
                for (int j = 0; j < 640; j++)
                    zbuffer[i, j] = +2147483647;
            foreach (Triangle triangle in triangles)
                // triangle.DrawWire(target, transformationMatrix, color);
                triangle.DrawTriangle(target, transformationMatrix, ref zbuffer);
        }
        //getstrung
    }
}
