using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    public struct Chop_Frame
    {
        public FrameTypes Frame_Type => FrameTypes.CHOP; /* 248-250 */
        public ushort Offset_Delta;
    }
}
