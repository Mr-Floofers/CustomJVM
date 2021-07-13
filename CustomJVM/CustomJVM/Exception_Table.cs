using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM
{
    public struct Exception_Table
    {
        public ushort Start_PC;
        public ushort End_PC;
        public ushort Handler_PC;
        public ushort Catch_Type;

        public void Parse(ref Memory<byte> hexdump)
        {
            Start_PC = hexdump.Read2();
            End_PC = hexdump.Read2();
            Handler_PC = hexdump.Read2();
            Catch_Type = hexdump.Read2();
        }
    }
}
