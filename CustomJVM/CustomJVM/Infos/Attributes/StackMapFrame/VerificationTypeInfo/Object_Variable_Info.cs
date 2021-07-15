using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public class Object_Variable_Info : Verification_Type_Info
    {
        public ushort CPool_Index { get; private set; }
        public override void Parse(ref Memory<byte> hexdump)
        {
            base.Parse(ref hexdump);
            CPool_Index = hexdump.Read2();
        }
    }
}