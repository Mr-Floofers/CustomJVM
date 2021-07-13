using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct Null_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_Null;
        public void Parse(ref Memory<byte> hexdump)
        {

        }
    }
}