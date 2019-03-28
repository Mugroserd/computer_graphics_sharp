using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    class Triangle
    {
        public struct Vertex
        {
            public VertexParam position;
            public VertexParam texture;
            public VertexParam normal; // нормально

            public Vertex(VertexParam position, VertexParam texture, VertexParam normal)
            {
                this.position = position;
                this.texture = texture;
                this.normal = normal;
            }
        }
        private Vertex[] vertices = new Vertex[3];

        public Triangle(Vertex[] vertices)
        {
            for (int vertexNum = 0; vertexNum < 3; vertexNum++)
                this.vertices[vertexNum] = vertices[vertexNum];
        }

        public void DrawWire(TextureBuffer target, Matrix4 transformationMatrix, Color color)
        {
            VertexParam[] transformedCoords = new VertexParam[vertices.Length];
            for (int vertexNum = 0; vertexNum < vertices.Length; vertexNum++)
                transformedCoords[vertexNum] = vertices[vertexNum].position.Transform(transformationMatrix, 1);
        }

        public void DrawTriangle(TextureBuffer target, Matrix4 transformationMatrix, ref int[,] zbuffer)
        {
            VertexParam[] transformedCoords = new VertexParam[vertices.Length];
            for (int vertexNum = 0; vertexNum < vertices.Length; vertexNum++)
                transformedCoords[vertexNum] = vertices[vertexNum].position.Transform(transformationMatrix, 1);
            target.DrawTriangle(transformedCoords[0], transformedCoords[1], transformedCoords[2], vertices[0].texture, vertices[1].texture, vertices[2].texture, ref zbuffer);
        }
    }
}
