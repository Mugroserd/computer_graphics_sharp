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
        
        public VertexParam Transform(Matrix4 mat, float constant)
        {
            float[] newValues = new float[valuesAmt];
            for (int valueNum = 0; valueNum < valuesAmt; valueNum++)
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
            return new VertexParam(type, valuesAmt, newValues);
        }
    }
}
