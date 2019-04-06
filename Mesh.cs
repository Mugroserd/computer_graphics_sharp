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

        public void Draw(Matrix4 transformationMatrix, TextureBuffer texture, TextureBuffer target, float[,] zbuffer, PointLight light)
        {
            foreach (Triangle triangle in triangles)
                triangle.Draw(transformationMatrix, texture, target, zbuffer, light);
        }
    }
}
