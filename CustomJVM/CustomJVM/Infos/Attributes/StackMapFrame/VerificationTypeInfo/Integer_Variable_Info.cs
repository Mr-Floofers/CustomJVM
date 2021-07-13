using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct Integer_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_Integer;
        public void Parse(ref Memory<byte> hexdump)
        {

        }
    }
}