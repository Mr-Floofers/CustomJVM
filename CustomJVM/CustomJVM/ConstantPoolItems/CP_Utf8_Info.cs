using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.ConstantPoolItems
{
    public class CP_Utf8_Info : CP_Info
    {
        public override ConstantPoolTags Tag => ConstantPoolTags.CP_Utf8_Info;

        public ushort Length { get; private set; }
        public byte[] Bytes { get; private set; }

        public override void Parse(ref Memory<byte> hexdump)
        {
            Length = hexdump.Read2();
            Bytes = new byte[Length];
            for(int i = 0; i < Bytes.Length; i++)
            {
                Bytes[i] = hexdump.Read1();
            }
        }
    }
}
