using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct Top_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_Top;

        public void Parse(ref Memory<byte> hexdump)
        {
            
        }
    }
}
