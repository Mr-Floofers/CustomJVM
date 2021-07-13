using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes
{
    class SourceFile_Attribute_Info : Attribute_Info
    {
        public SourceFile_Attribute_Info(ushort attribute_name_index) : base(attribute_name_index)
        {
        }

        public ushort SourceFile_Index { get; private set; }

        public override void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            //Attribute_Name_Index = hexdump.Read2();
            Attribute_Length = hexdump.Read4();
            SourceFile_Index = hexdump.Read2();
        }
    }
}
