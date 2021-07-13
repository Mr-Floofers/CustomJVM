using CustomJVM.ConstantPoolItems;
using CustomJVM.Infos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.InfoManagers
{
    public class Method_Info_Manager : IEnumerable<Method_Info>
    {
        Method_Info[] methods;

        public Method_Info this[int index]
            => methods[index];

        public IEnumerator<Method_Info> GetEnumerator()
        {
            for(int i = 0; i < methods.Length; i++)
            {
                yield return methods[i];
            }
        }

        public void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            ushort methods_count = hexdump.Read2();
            methods = new Method_Info[methods_count];
            for(int i = 0; i < methods_count; i++)
            {
                Method_Info info = new Method_Info();
                info.Parse(ref hexdump, constant_pool);
                methods[i] = info;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void FindAllMethods(Constant_Pool constant_pool)
        {
            List<CP_MethodRef_Info> methodRefs = new List<CP_MethodRef_Info>();
            for(int i = 0; i < constant_pool.Length; i++)
            {

            }
        }
    }
}
