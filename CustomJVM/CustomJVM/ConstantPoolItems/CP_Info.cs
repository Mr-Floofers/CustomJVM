using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.ConstantPoolItems
{
    public abstract class CP_Info
    {
        public abstract ConstantPoolTags Tag { get; }

        public abstract void Parse(ref Memory<byte> hexdump);
    }
}
