using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    public class Chop_Frame : Stack_Map_Frame
    {
        public ushort Offset_Delta { get; private set; }

        public override void Parse(ref Memory<byte> hexdump)
        {
            base.Parse(ref hexdump);
            Offset_Delta = hexdump.Read2();
        }
    }
}
