using CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo;
using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    public struct Same_Locals_1_Stack_Item_Frame_Extended
    {
        public FrameTypes Frame_Type => FrameTypes.SAME_LOCALS_1_STACK_ITEM_EXTENDED;
        public ushort Offset_Delta { get; private set; }
        public Verification_Type_Info[] Stack { get; private set; }
        public void Parse(ref Memory<byte> hexdump)
        {
            Offset_Delta = hexdump.Read2();
            Stack = new Verification_Type_Info[1];
            Stack[0].Parse(ref hexdump);
        }
    }
}