using CustomJVM.ConstantPoolItems;
using CustomJVM.InfoManagers;
using CustomJVM.Infos;
using CustomJVM.Infos.Attributes;
using CustomJVM.Infos.Attributes.StackMapFrame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CustomJVM
{
    class Program
    {
        public static T[] GetAllTypesThatInheritT<T>()
        {
            var thing1 = Assembly.GetAssembly(typeof(T));//.GetTypes();
            var thing4 = thing1.GetTypes();
            //var thing2 = thing1.Where(x => x.IsSubclassOf(typeof(T)));
            //var thing3 = thing2.Select(x => (T)Activator.CreateInstance(x)).ToArray();
            return default;
        }
            //=> Assembly.GetAssembly(typeof(T)).GetTypes()
            //.Where(x => x.IsSubclassOf(typeof(T)))
            //.Select(x => (T)Activator.CreateInstance(x)).ToArray();

        public static Dictionary<AttributeTypes, Func<ushort, Attribute_Info>> AttributesMap = new Dictionary<AttributeTypes, Func<ushort, Attribute_Info>>()
        {
            [AttributeTypes.Code] = new Func<ushort, Attribute_Info>((name_index) => new Code_Attribute_Info(name_index)),
            [AttributeTypes.LineNumberTable] = new Func<ushort, Attribute_Info>((name_index) => new LineNumberTable_Attribute_Info(name_index)),
            [AttributeTypes.SourceFile] = new Func<ushort, Attribute_Info>((name_index) => new SourceFile_Attribute_Info(name_index)),
        };

        public static Stack<uint?> Stack = new Stack<uint?>();
        public static Dictionary<CP_MethodRef_Info, List<Method_Info>> Methods = new Dictionary<CP_MethodRef_Info, List<Method_Info>>();

        static void Main(string[] args)
        {


            var bytes = File.ReadAllBytes("Program.class");
            var hexdump = bytes.AsMemory();


            /*
ClassFile {
    u4             magic;
    u2             minor_version;
    u2             major_version;
    u2             constant_pool_count;
    cp_info        constant_pool[constant_pool_count-1];
    u2             access_flags;
    u2             this_class;
    u2             super_class;
    u2             interfaces_count;
    u2             interfaces[interfaces_count];
    u2             fields_count;
    field_info     fields[fields_count];
    u2             methods_count;
    method_info    methods[methods_count];
    u2             attributes_count;
    attribute_info attributes[attributes_count];
}*/
            uint magic = hexdump.Read4();   
            ushort minor_version = hexdump.Read2();
            ushort major_version = hexdump.Read2();

            Constant_Pool pool = new Constant_Pool();
            pool.Parse(ref hexdump);

            AccessFlags access_flags = (AccessFlags)hexdump.Read2();
            ushort this_class = hexdump.Read2();
            ushort super_class = hexdump.Read2();

            ushort interfaces_count = hexdump.Read2();
            ushort[] interfaces = new ushort[interfaces_count];
            for (int i = 0; i < interfaces.Length; i++)
            {
                interfaces[i] = hexdump.Read2();
            }

            Field_Info_Manager field_info_manager = new Field_Info_Manager();
            field_info_manager.Parse(ref hexdump, pool);

            Method_Info_Manager method_info_manager = new Method_Info_Manager();
            method_info_manager.Parse(ref hexdump, pool);

            Attribute_Info_Manager attribute_info_manager = new Attribute_Info_Manager();
            attribute_info_manager.Parse(ref hexdump, pool);

            Method_Info main = null;
            foreach (var methodInfo in method_info_manager)
            {
                CP_Utf8_Info item = (CP_Utf8_Info)pool[methodInfo.Name_Index - 1];
                CP_Utf8_Info itemDescriptor = (CP_Utf8_Info)pool[methodInfo.Descriptor_Index - 1];
                string methodName = item.UTF8ToString();
                string descriptorName = itemDescriptor.UTF8ToString();
                if (methodName == "main" && descriptorName == "([Ljava/lang/String;)V" && methodInfo.Access_Flags == (MethodAccessFlags.ACC_PUBLIC | MethodAccessFlags.ACC_STATIC))
                {
                    main = methodInfo;
                }
            }

            main.Execute(pool, method_info_manager);

            //Code_Attribute_Info mainCode = ((Code_Attribute_Info)main.Attributes[0]);
            //Memory<byte> code = mainCode.Code.AsMemory();
            //OpCodes opcodes = (OpCodes)code.Read1();

            //Stack<uint?> stack = new Stack<uint?>();
            //uint?[] variables = new uint?[mainCode.Max_Locals];

            //while (!code.IsEmpty)
            //{
            //    switch (opcodes)
            //    {
            //        case OpCodes.iconst_5:
            //            {
            //                stack.Push(5);

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.bipush:
            //            {
            //                byte value = code.Read1();
            //                stack.Push(value);

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.iload_1:
            //            {
            //                stack.Push(variables[1]);

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.iload_2:
            //            {
            //                stack.Push(variables[2]);

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.istore_1:
            //            {
            //                uint? value = stack.Pop();
            //                variables[1] = value;

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.istore_2:
            //            {
            //                uint? value = stack.Pop();
            //                variables[2] = value;

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.istore_3:
            //            {
            //                uint? value = stack.Pop();
            //                variables[3] = value;

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.iadd:
            //            {
            //                uint? val1 = stack.Pop();
            //                uint? val2 = stack.Pop();
            //                stack.Push(val1 + val2);
            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //        case OpCodes.@return:
            //            {
            //                stack.Pop();

            //                opcodes = (OpCodes)code.Read1();
            //                break;
            //            }
            //    }
            //}
            ;
        }
    }
}
