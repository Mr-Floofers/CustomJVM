using CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo;
using System;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    public struct Full_Frame
    {
        public FrameTypes Frame_Type => FrameTypes.FULL_FRAME;
        public ushort Offset_Delta { get; private set; }
        public ushort Number_Of_Locals { get; private set; }
        public Verification_Type_Info[] Locals { get; private set; }
        public ushort Number_Of_Stack_Items { get; private set; }
        public Verification_Type_Info[] Stack { get; private set; }
        public void Parse(ref Memory<byte> hexdump)
        {
            Offset_Delta = hexdump.Read2();
            Number_Of_Locals = hexdump.Read2();
            Locals = new Verification_Type_Info[Number_Of_Locals];
            for (int i = 0; i < Locals.Length; i++)
            {
                Locals[i].Parse(ref hexdump);
            }
            Number_Of_Stack_Items = hexdump.Read2();
            Stack = new Verification_Type_Info[Number_Of_Stack_Items];
            for (int i = 0; i < Stack.Length; i++)
            {
                Stack[i].Parse(ref hexdump);
            }
        }
    }
}