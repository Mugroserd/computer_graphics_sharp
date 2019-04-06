using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    class VertexParam
    {
        public enum Type
        {
            position,
            texture,
            normal
        }

        public readonly Type type;
        public readonly byte valuesAmt;
        public readonly float[] values;

        public VertexParam(Type type, byte valuesAmt, float[] values)
        {
            this.type = type;
            this.valuesAmt = valuesAmt;
            this.values = new float[valuesAmt];
            for (int currentValueNumber = 0; currentValueNumber < valuesAmt; currentValueNumber++)
                this.values[currentValueNumber] = values[currentValueNumber];
        }

        static public VertexParam FromBarycentric(VertexParam[] vertices, float[] coeffs)
        {
            float[] values = new float[vertices[0].valuesAmt];
            for (int valueNum = 0; valueNum < vertices[0].valuesAmt; valueNum++)
                values[valueNum] = vertices[0].values[valueNum] * coeffs[0] + vertices[1].values[valueNum] * coeffs[1] + vertices[2].values[valueNum] * coeffs[2];

            return new VertexParam(vertices[0].type, vertices[0].valuesAmt, values);
        }
        
        public VertexParam Transform(Matrix4 mat, float constant)
        {
            byte newValuesAmt = (byte)(valuesAmt + 1);
            float[] newValues = new float[newValuesAmt];
            newValues[newValuesAmt - 1] = constant;
            for (int valueNum = 0; valueNum < newValuesAmt; valueNum++)
            {
                newValues[valueNum] = 0;
                for (int cellNum = 0; cellNum < 4; cellNum++)
                {
                    if(cellNum >= values.Length)
                        newValues[valueNum] += constant * mat.values[valueNum, cellNum];
                    else
                        newValues[valueNum] += values[cellNum] * mat.values[valueNum, cellNum];
                }
            }

            for (int valueNum = 0; valueNum < newValuesAmt; valueNum++)
                newValues[valueNum] /= newValues[newValuesAmt - 1];

            return new VertexParam(type, newValuesAmt, newValues);
        }
    }
}
