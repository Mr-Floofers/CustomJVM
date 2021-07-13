using CustomJVM.ConstantPoolItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM
{
    public class Constant_Pool
    {
        CP_Info[] cp_info;
        public int Length => cp_info.Length;

        public CP_Info this[int index]
            => cp_info[index];

        public void Parse(ref Memory<byte> hexdump)
        {
            CP_Info[] allConstantPoolItems = Program.GetAllTypesThatInheritT<CP_Info>();

            Dictionary<ConstantPoolTags, Func<CP_Info>> map = new Dictionary<ConstantPoolTags, Func<CP_Info>>();

            foreach (var item in allConstantPoolItems)
            {
                map.Add(item.Tag, new Func<CP_Info>(() =>
                {
                    return (CP_Info)Activator.CreateInstance(item.GetType());
                }));
            }

            ushort constant_pool_count = hexdump.Read2();
            cp_info = new CP_Info[constant_pool_count];

            for (int i = 0; i < constant_pool_count - 1; i++)
            {
                var tag = (ConstantPoolTags)hexdump.Read1();
                CP_Info currentInfo = map[tag]();

                currentInfo.Parse(ref hexdump);

                cp_info[i] = currentInfo;
            }
        }
    }
}
