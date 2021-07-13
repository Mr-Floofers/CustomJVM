using CustomJVM.ConstantPoolItems;
using CustomJVM.Infos;
using CustomJVM.Infos.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.InfoManagers
{
    public class Attribute_Info_Manager : IEnumerable<Attribute_Info>
    {
        Attribute_Info[] attributes;

        public IEnumerator<Attribute_Info> GetEnumerator()
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                yield return attributes[i];
            }
        }

        public void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            ushort attributes_count = hexdump.Read2();
            attributes = new Attribute_Info[attributes_count];
            for (int i = 0; i < attributes_count; i++)
            {
                ushort nameIndex = hexdump.Read2();
                var currentAttribute = (CP_Utf8_Info)constant_pool[nameIndex-1];
                string name = currentAttribute.UTF8ToString();
                AttributeTypes attributeType = (AttributeTypes)Enum.Parse(typeof(AttributeTypes), name);

                Attribute_Info info = Program.AttributesMap[attributeType](nameIndex);
                info.Parse(ref hexdump, constant_pool);
                attributes[i] = info;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
