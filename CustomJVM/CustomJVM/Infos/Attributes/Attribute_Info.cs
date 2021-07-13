using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes
{
    public abstract class Attribute_Info
    {
        public ushort Attribute_Name_Index { get; protected set; }
        public uint Attribute_Length { get; protected set; }

        public Attribute_Info(ushort attribute_name_index)
        {
            Attribute_Name_Index = attribute_name_index;
        }
        public abstract void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool);
    }
}
