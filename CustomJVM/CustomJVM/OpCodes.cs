using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM
{
    public enum OpCodes : byte
    {
        iconst_5 = 0x08,
        bipush = 0x10,
        iload_0 = 0x1a,
        iload_1 = 0x1b,
        iload_2 = 0x1c,
        istore_1 = 0x3c,
        istore_2 = 0x3d,
        istore_3 = 0x3e,
        iadd = 0x60,
        if_icmple = 0xa4,
        ireturn = 0xac,
        @return = 0xb1,
        invokestatic = 0xb8,
    }
}
