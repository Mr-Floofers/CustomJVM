using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public class Uninitialized_Variable_Info : Verification_Type_Info
    { 
        public ushort Offset { get; private set; }
        public override void Parse(ref Memory<byte> hexdump)
        {
            base.Parse(ref hexdump);
            Offset = hexdump.Read2();
        }
    }
}