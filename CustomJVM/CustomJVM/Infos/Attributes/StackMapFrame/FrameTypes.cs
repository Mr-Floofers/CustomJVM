using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RangeAttribute : Attribute
    {
        public byte Start { get; }
        public byte End { get; }

        public RangeAttribute(byte start, byte end)
            => (Start, End) = (start, end);

        public RangeAttribute(byte value)
            : this(value, value) { }
    }
    public enum FrameTypes : byte
    {
        [Range(0, 63)]
        SAME,

        [Range(64, 127)]
        SAME_LOCALS_1_STACK_ITEM,

        [Range(247)]
        SAME_LOCALS_1_STACK_ITEM_EXTENDED,

        [Range(248, 250)]
        CHOP,

        [Range(251)]
        SAME_FRAME_EXTENDED,

        [Range(252, 254)]
        APPEND,

        [Range(255)]
        FULL_FRAME
    }
}
