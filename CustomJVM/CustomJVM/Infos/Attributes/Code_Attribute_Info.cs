using CustomJVM.ConstantPoolItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes
{
    public class Code_Attribute_Info : Attribute_Info
    {
        public Code_Attribute_Info(ushort attribute_name_index) : base(attribute_name_index)
        {
        }

        public ushort Max_Stack { get; private set; }
        public ushort Max_Locals { get; private set; }
        public uint Code_Length { get; private set; }
        public byte[] Code { get; private set; }
        public ushort Exception_Table_Length { get; private set; }
        public Exception_Table[] Exception_Table { get; private set; }
        public ushort Attributes_Count { get; private set; }
        public Attribute_Info[] Attributes { get; private set; }

        public override void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            //Attribute_Name_Index = hexdump.Read2();
            Attribute_Length = hexdump.Read4();
            Max_Stack = hexdump.Read2();
            Max_Locals = hexdump.Read2();

            Code_Length = hexdump.Read4();
            Code = new byte[Code_Length];
            for (int i = 0; i < Code_Length; i++)
            {
                Code[i] = hexdump.Read1();
            }

            Exception_Table_Length = hexdump.Read2();
            Exception_Table = new Exception_Table[Exception_Table_Length];
            for (int i = 0; i < Exception_Table_Length; i++)
            {
                Exception_Table[i].Parse(ref hexdump);
            }

            Attributes_Count = hexdump.Read2();
            Attributes = new Attribute_Info[Attributes_Count];
            for (int i = 0; i < Attributes_Count; i++)
            {
                ushort nameIndex = hexdump.Read2();
                var currentAttribute = (CP_Utf8_Info)constant_pool[nameIndex-1];
                string name = currentAttribute.UTF8ToString();

                AttributeTypes attributeType = (AttributeTypes)Enum.Parse(typeof(AttributeTypes), name);

                Attribute_Info info = Program.AttributesMap[attributeType](nameIndex);
                info.Parse(ref hexdump, constant_pool);
                Attributes[i] = info;
            }
        }
    }
}
