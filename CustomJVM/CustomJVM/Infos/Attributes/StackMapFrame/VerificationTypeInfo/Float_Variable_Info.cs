using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct Float_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_Float;
        public void Parse(ref Memory<byte> hexdump)
        {

        }
    }
}