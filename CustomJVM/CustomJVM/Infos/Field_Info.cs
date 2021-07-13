using CustomJVM.ConstantPoolItems;
using CustomJVM.Infos.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos
{
    public class Field_Info
    {
        public FieldAccessFlags Access_Flags { get; private set; }
        public ushort Name_Index { get; private set; }
        public ushort Descriptor_Index { get; private set; }
        public ushort Attributes_Count { get; private set; }
        public Attribute_Info[] Attributes { get; private set; }

        public void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            Access_Flags = (FieldAccessFlags)hexdump.Read2();
            Name_Index = hexdump.Read2();
            Descriptor_Index = hexdump.Read2();
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
