using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public struct Object_Variable_Info
    {
        public VerificationTypeTags Tag => VerificationTypeTags.ITEM_Object;
        public ushort CPool_Index { get; private set; }
        public void Parse(ref Memory<byte> hexdump)
        {

        }
    }
}