using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;

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

        public void Draw(Matrix4 transformationMatrix, TextureBuffer texture, TextureBuffer target, float[,] zbuffer, PointLight light)
        {
            Vertex[] transformedVertices = new Vertex[vertices.Length];
            for (int vertexNum = 0; vertexNum < vertices.Length; vertexNum++)
                transformedVertices[vertexNum] = new Vertex(
                    vertices[vertexNum].position.Transform(transformationMatrix, 1),
                    vertices[vertexNum].texture,
                    vertices[vertexNum].normal
                    );

            Point2F[] points = {RescaleToBuffer(transformedVertices[0].position, target),
                                RescaleToBuffer(transformedVertices[1].position, target),
                                RescaleToBuffer(transformedVertices[2].position, target)};

            int x0 = (int)Math.Floor(Math.Min(points[0].x, Math.Min(points[1].x, points[2].x)));
            int y0 = (int)Math.Floor(Math.Min(points[0].y, Math.Min(points[1].y, points[2].y)));
            int x1 = (int)Math.Ceiling(Math.Max(points[0].x, Math.Max(points[1].x, points[2].x)));
            int y1 = (int)Math.Ceiling(Math.Max(points[0].y, Math.Max(points[1].y, points[2].y)));

            // Бангладеш частичного выхода прямоугольника за пределы рисуемой области
            x0 = x0 < 0 ? 0 : x0;
            y0 = y0 < 0 ? 0 : y0;
            x1 = x1 > target.Width ? target.Width : x1;
            y1 = y1 > target.Height ? target.Height : y1;

            for (int x = x0; x < x1; x++)
                for (int y = y0; y < y1; y++)
                {
                    if (GetBarycentric(x, y, points, transformedVertices, out Vertex pointVertex))
                        target.SetPixel(x, y, pointVertex.position.values[2], GetPixelColor(pointVertex, texture, light), ref zbuffer[x, y]);
                }
        }

        private Color GetPixelColor(Vertex vertex, TextureBuffer texture, PointLight light)
        {
            Point3F pointPosition = new Point3F(vertex.position.values[0], vertex.position.values[1], vertex.position.values[2]);
            Point3F lightDirection = light.position - pointPosition;

            float lightLength = (float)Math.Sqrt((lightDirection.x * lightDirection.x) + (lightDirection.y * lightDirection.y) + (lightDirection.z * lightDirection.z));
            lightDirection /= lightLength;

            Point3F normalPosition = new Point3F(vertex.normal.values[0], vertex.normal.values[1], vertex.normal.values[2]);

            float lightStrength = (lightDirection.x * normalPosition.x + lightDirection.y * normalPosition.y + lightDirection.z * normalPosition.z);
            lightStrength = lightStrength < 0 ? 0 : lightStrength;

            Color color = texture.GetPixel(vertex.texture.values[0], vertex.texture.values[1]);
            color = Color.FromArgb(255, (int)(color.R * lightStrength * light.color.red), (int)(color.G * lightStrength * light.color.green), (int)(color.B * lightStrength * light.color.blue));
            return color;
        }

        private bool GetBarycentric(int x, int y, Point2F[] points, Vertex[] transformedVertices, out Vertex pointVertex)
        {
            float[] coeffs = new float[3];

            coeffs[0] = ((points[1].y - points[2].y) * (x - points[2].x) + (points[2].x - points[1].x) * (y - points[2].y)) /
                 ((points[1].y - points[2].y) * (points[0].x - points[2].x) + (points[2].x - points[1].x) * (points[0].y - points[2].y));
            coeffs[1] = ((points[2].y - points[0].y) * (x - points[2].x) + (points[0].x - points[2].x) * (y - points[2].y)) /
                 ((points[1].y - points[2].y) * (points[0].x - points[2].x) + (points[2].x - points[1].x) * (points[0].y - points[2].y));
            coeffs[2] = 1 - coeffs[0] - coeffs[1];
            
            if (coeffs[0] >= 0 && coeffs[1] >= 0 && coeffs[2] >= 0)
            {
                VertexParam position = VertexParam.FromBarycentric(new VertexParam[] {
                    transformedVertices[0].position,
                    transformedVertices[1].position,
                    transformedVertices[2].position },
                    coeffs);
                VertexParam texture = VertexParam.FromBarycentric(new VertexParam[] {
                    transformedVertices[0].texture,
                    transformedVertices[1].texture,
                    transformedVertices[2].texture },
                    coeffs);
                VertexParam normal = VertexParam.FromBarycentric(new VertexParam[] {
                    transformedVertices[0].normal,
                    transformedVertices[1].normal,
                    transformedVertices[2].normal },
                    coeffs);
                pointVertex = new Vertex(position, texture, normal);
                return true;
            }
            pointVertex = new Vertex();
            return false;
        }

        private Point2F RescaleToBuffer(VertexParam coordinate, TextureBuffer buffer)
        {
            Point2F point;
            point.x = (1 + coordinate.values[0]) * buffer.Width / 2;
            point.y = (1 + coordinate.values[1]) * buffer.Height / 2;

            return point;
        }
    }
}
