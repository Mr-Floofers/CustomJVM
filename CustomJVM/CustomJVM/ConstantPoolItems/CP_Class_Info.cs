using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.ConstantPoolItems
{
    public class CP_Class_Info : CP_Info
    {
        public override ConstantPoolTags Tag => ConstantPoolTags.CP_Class_Info;

        public ushort Name_Index { get; private set; }

        public override void Parse(ref Memory<byte> hexdump)
        {
            Name_Index = hexdump.Read2();
        }
    }
}
