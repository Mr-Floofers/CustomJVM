using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Stack_Map_Frame
    {
        [FieldOffset(0)]
        public Same_Frame Same_Frame;

        //[FieldOffset(0)]
        //public Same_Locals_1_Stack_Item_Frame Same_Locals_1_Stack_Item_Frame;

        //[FieldOffset(0)]
        //public Same_Locals_1_Stack_Item_Frame_Extended Same_Locals_1_Stack_Item_Frame_Extended;

        [FieldOffset(0)]
        public Chop_Frame Chop_Frame;

        //[FieldOffset(0)]
        //public Same_Frame_Extended Same_Frame_Extended;

        [FieldOffset(0)]
        public Append_Frame Append_Frame;

        //[FieldOffset(0)]
        //public Full_Frame Full_Frame;

        [FieldOffset(1)]
        public FrameTypes CurrentFrameType;
        public void Parse(ref Memory<byte> hexdump)
        {
            FrameTypes currentFrame = (FrameTypes)hexdump.Read1();
            switch (currentFrame)
            {
                case FrameTypes.SAME:
                    Same_Frame = new Same_Frame();
                    break;
                case FrameTypes.SAME_LOCALS_1_STACK_ITEM:
                    break;
                case FrameTypes.SAME_LOCALS_1_STACK_ITEM_EXTENDED:
                    break;
                case FrameTypes.CHOP:
                    break;
                case FrameTypes.SAME_FRAME_EXTENDED:
                    break;
                case FrameTypes.APPEND:
                    //Append_Frame = new Append_Frame();
                    break;
                case FrameTypes.FULL_FRAME:
                    break;
            }
        }
    }
}
