using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct UninitializedThis_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_UninitializedThis;
        public void Parse(ref Memory<byte> hexdump)
        {

        }
    }
}