using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM
{
    struct LineNumberTable
    {
        public ushort Start_PC;
        public ushort Line_Number;

        public void Parse(ref Memory<byte> hexdump)
        {
            Start_PC = hexdump.Read2();
            Line_Number = hexdump.Read2();
        }
    }
}
