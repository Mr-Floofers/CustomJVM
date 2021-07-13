using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes
{
    class LineNumberTable_Attribute_Info : Attribute_Info
    {
        public LineNumberTable_Attribute_Info(ushort attribute_name_index) : base(attribute_name_index)
        {
        }

        //    u2 attribute_name_index;
        //    u4 attribute_length;
        //    u2 line_number_table_length;
        //{   u2 start_pc;
        //    u2 line_number;
        //}
        //line_number_table[line_number_table_length];

        public ushort Line_Number_Table_Length { get; private set; }
        public LineNumberTable[] Line_Number_Table { get; private set; }

        public override void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            //Attribute_Name_Index = hexdump.Read2();
            Attribute_Length = hexdump.Read4();

            Line_Number_Table_Length = hexdump.Read2();
            Line_Number_Table = new LineNumberTable[Line_Number_Table_Length];
            for (int i = 0; i < Line_Number_Table_Length; i++)
            {
                Line_Number_Table[i].Parse(ref hexdump);
            }
        }
    }
}
