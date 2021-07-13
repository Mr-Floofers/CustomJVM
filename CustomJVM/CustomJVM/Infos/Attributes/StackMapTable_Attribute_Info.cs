using CustomJVM.Infos.Attributes.StackMapFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes
{
    public class StackMapTable_Attribute_Info : Attribute_Info
    {
        public ushort Number_Of_Entries { get; private set; }

        public Stack_Map_Frame[] Entries { get; private set; }

        public StackMapTable_Attribute_Info(ushort attribute_name_index) : base(attribute_name_index)
        {
        }

        public override void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            Attribute_Length = hexdump.Read4();
            Number_Of_Entries = hexdump.Read2();
            Entries = new Stack_Map_Frame[Number_Of_Entries];
            for (int i = 0; i < Number_Of_Entries; i++)
            {
                Entries[i] = new Stack_Map_Frame();
                Entries[i].Parse(ref hexdump);
            }
        }
    }
}
