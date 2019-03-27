﻿using System;
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
            foreach (Triangle triangle in triangles)
                // triangle.DrawWire(target, transformationMatrix, color);
                triangle.DrawTriangle(target, transformationMatrix);
        }
        //getstrung
    }
}
