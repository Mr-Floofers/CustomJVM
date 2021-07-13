using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct Uninitialized_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_Uninitialized;
        public ushort Offset { get; private set; }
        public void Parse(ref Memory<byte> hexdump)
        {

        }
    }
}