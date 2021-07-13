using CustomJVM.Infos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.InfoManagers
{
    public class Field_Info_Manager : IEnumerable<Field_Info>
    {
        Field_Info[] fields;

        public IEnumerator<Field_Info> GetEnumerator()
        {
            for(int i = 0; i < fields.Length; i++)
            {
                yield return fields[i];
            }
        }

        public void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            ushort fields_count = hexdump.Read2();
            fields = new Field_Info[fields_count];
            for (int i = 0; i < fields_count; i++)
            {
                Field_Info info = new Field_Info();
                info.Parse(ref hexdump, constant_pool);
                fields[i] = info;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
