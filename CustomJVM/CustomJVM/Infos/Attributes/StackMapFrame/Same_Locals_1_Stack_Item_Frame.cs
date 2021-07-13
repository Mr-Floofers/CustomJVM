using CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo;
using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    public struct Same_Locals_1_Stack_Item_Frame
    {
        public FrameTypes Frame_Type => FrameTypes.SAME_LOCALS_1_STACK_ITEM; /* 64-127 */
        public Verification_Type_Info[] Stack { get; private set; }

        public void Parse(ref Memory<byte> hexdump)
        {
            Stack = new Verification_Type_Info[1];
            Stack[0].Parse(ref hexdump);
        }
    }
}