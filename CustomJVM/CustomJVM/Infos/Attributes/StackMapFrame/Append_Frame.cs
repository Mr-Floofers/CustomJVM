using CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Append_Frame
    {
        [FieldOffset(0)]
        public FrameTypes Frame_Type;// => FrameTypes.APPEND;
        [FieldOffset(1)]
        public ushort Offset_Delta;
        [FieldOffset(3)]
        public ushort[] Locals;
        public void Parse(ref Memory<byte> hexdump)
        {
            //Offset_Delta = hexdump.Read2();
            ////Locals = new Verification_Type_Info[(byte)Frame_Type-251];
            //for(int i = 0; i < Locals.Length; i++)
            //{
            //    //Locals[i].Parse(ref hexdump);
            //}
        }
    }
}