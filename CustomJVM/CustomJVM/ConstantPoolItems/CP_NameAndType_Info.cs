using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.ConstantPoolItems
{
    public class CP_NameAndType_Info : CP_Info
    {
        public override ConstantPoolTags Tag => ConstantPoolTags.CP_NameAndType_Info;

        public ushort Name_Index { get; private set; }
        public ushort Descriptor_Index { get; private set; }

        public override void Parse(ref Memory<byte> hexdump)
        {
            Name_Index = hexdump.Read2();
            Descriptor_Index = hexdump.Read2();
        }
    }
}
