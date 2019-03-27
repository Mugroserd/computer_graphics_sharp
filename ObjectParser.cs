using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    class ObjectParser
    {
        public static Mesh GetMeshFromObj(string filename)
        {
            List<VertexParam> verticesPositions = new List<VertexParam>();
            List<VertexParam> verticesTextures = new List<VertexParam>();
            List<VertexParam> verticesNormals = new List<VertexParam>();
            List<Triangle> triangles = new List<Triangle>();

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (words[0])
                {
                    case "v":
                        verticesPositions.Add(new VertexParam(VertexParam.Type.position, 3, new float[]
                            { float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture),
                            float.Parse(words[2], System.Globalization.CultureInfo.InvariantCulture),
                            float.Parse(words[3], System.Globalization.CultureInfo.InvariantCulture) })
                            );
                        break;
                    case "vt":
                        verticesTextures.Add(new VertexParam(VertexParam.Type.texture, 2, new float[]
                            { float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture),
                            float.Parse(words[2], System.Globalization.CultureInfo.InvariantCulture) })
                            );
                        break;
                    case "vn":
                        verticesNormals.Add(new VertexParam(VertexParam.Type.normal, 3, new float[]
                            { float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture),
                            float.Parse(words[2], System.Globalization.CultureInfo.InvariantCulture),
                            float.Parse(words[3], System.Globalization.CultureInfo.InvariantCulture) })
                            );
                        break;
                    case "f":
                        Triangle.Vertex[] vertices = new Triangle.Vertex[3];
                        for (int vertexNum = 0; vertexNum < 3; vertexNum++)
                        {
                            int[] componentsIDs = new int[3];   // Identificators of vertex components
                            string[] componentsStrings = words[vertexNum + 1].Split(new char[] { '/' });    // String representation of each component
                            vertices[vertexNum] = new Triangle.Vertex(
                                verticesPositions[int.Parse(componentsStrings[0]) - 1],
                                verticesTextures[int.Parse(componentsStrings[1]) - 1],
                                verticesNormals[int.Parse(componentsStrings[2]) - 1]);
                        }
                        triangles.Add(new Triangle(vertices));
                        break;
                }
            }
            return new Mesh(triangles);
        }
    }
}