using CustomJVM.ConstantPoolItems;
using CustomJVM.InfoManagers;
using CustomJVM.Infos.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomJVM.Infos
{
    public class Method_Info
    {
        public MethodAccessFlags Access_Flags { get; private set; }
        public ushort Name_Index { get; private set; }
        public ushort Descriptor_Index { get; private set; }
        public ushort Attributes_Count { get; private set; }
        public Attribute_Info[] Attributes { get; private set; }

        public uint?[] Locals { get; private set; }
        public Code_Attribute_Info CodeAttribute { get; private set; }

        public void Parse(ref Memory<byte> hexdump, Constant_Pool constant_pool)
        {
            Access_Flags = (MethodAccessFlags)hexdump.Read2();
            Name_Index = hexdump.Read2();
            Descriptor_Index = hexdump.Read2();
            Attributes_Count = hexdump.Read2();

            Attributes = new Attribute_Info[Attributes_Count];

            for (int i = 0; i < Attributes_Count; i++)
            {
                //Read 2 for the name_index which when we decode will tell us what type of attribute to create
                //either do a switch on the name_index
                //or have a dictionary
                ushort nameIndex = hexdump.Read2();
                var currentAttribute = (CP_Utf8_Info)constant_pool[nameIndex - 1];
                string name = currentAttribute.UTF8ToString();

                AttributeTypes attributeType = (AttributeTypes)Enum.Parse(typeof(AttributeTypes), name);
                Attribute_Info info = Program.AttributesMap[attributeType](nameIndex);
                info.Parse(ref hexdump, constant_pool);

                if (attributeType == AttributeTypes.Code)
                {
                    CodeAttribute = (Code_Attribute_Info)info;
                }
                Attributes[i] = info;
            }
            Locals = new uint?[CodeAttribute.Max_Locals];
        }

        public uint? Execute(Constant_Pool constant_pool, Method_Info_Manager method_info_manager)
        {
            Memory<byte> code = CodeAttribute.Code.AsMemory();
            OpCodes currentOpCode = (OpCodes)code.Read1();
            int bytes = 0;

            while (!code.IsEmpty)
            {
                switch (currentOpCode)
                {
                    case OpCodes.iconst_5:
                        {
                            Program.Stack.Push(5);

                            bytes++;
                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.bipush:
                        {
                            byte value = code.Read1();
                            Program.Stack.Push(value);

                            bytes += 2;
                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.iload_0:
                        {
                            Program.Stack.Push(Locals[0]);

                            bytes += 2;
                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.iload_1:
                        {
                            Program.Stack.Push(Locals[1]);

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.iload_2:
                        {
                            Program.Stack.Push(Locals[2]);

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.istore_1:
                        {
                            uint? value = Program.Stack.Pop();
                            Locals[1] = value;

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.istore_2:
                        {
                            uint? value = Program.Stack.Pop();
                            Locals[2] = value;

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.istore_3:
                        {
                            uint? value = Program.Stack.Pop();
                            Locals[3] = value;

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.iadd:
                        {
                            uint? val1 = Program.Stack.Pop();
                            uint? val2 = Program.Stack.Pop();
                            Program.Stack.Push(val1 + val2);

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.if_icmple:
                        {
                            byte val1 = (byte)Program.Stack.Pop();
                            byte val2 = (byte)Program.Stack.Pop();
                            short jumpVal = (short)((val1 << 8) | val2);

                            if (val1 <= val2)
                            {
                                int traveledBytes = (int)(CodeAttribute.Code_Length - code.Length);
                                int toTraveledBytes = traveledBytes - jumpVal;
                                code = CodeAttribute.Code.AsMemory();
                                code.Slice(toTraveledBytes);
                            }
                            
                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.ireturn:
                        {
                            uint? value = Program.Stack.Pop();
                            return value;

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.@return:
                        {
                            Program.Stack.Pop();
                            return null;

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                    case OpCodes.invokestatic:
                        {
                            ushort index = code.Read2();
                            var methodRef = (CP_MethodRef_Info)constant_pool[index - 1];
                            var nameAndType = (CP_NameAndType_Info)constant_pool[methodRef.Name_And_Type_Index - 1];

                            //var thing = ((CP_Utf8_Info)constant_pool[nameAndType.Descriptor_Index - 1]).UTF8ToString();

                            Method_Info callingMethod = null;
                            foreach (var method in method_info_manager)
                            {
                                if (nameAndType.Name_Index == method.Name_Index && nameAndType.Descriptor_Index == method.Descriptor_Index)
                                {
                                    callingMethod = method;
                                    continue;
                                }
                            }

                            //parse descriptor
                            string descriptor = ((CP_Utf8_Info)constant_pool[nameAndType.Descriptor_Index - 1]).UTF8ToString();
                            int paramatersCount = 0;


                            Regex pattern = new Regex(@"\((\w*)\)(\w)");
                            Match match = pattern.Match(descriptor);
                            string paramaters = match.Groups[1].Value;
                            string returnType = match.Groups[2].Value;

                            List<string> test = MatchDescriptor(descriptor);

                            //List<string> matchableStrings = new List<string>()
                            //{
                            //    "I",
                            //    "Ljava/lang/String;"
                            //};

                            //int descriptorIndex = 0;
                            //string currentMatch = "";
                            //while (!matchableStrings.Contains(currentMatch))
                            //{

                            //}

                            //for (int i = 0; i < descriptor.Length; i++)
                            //{
                            //    switch (descriptor[i])
                            //    {
                            //        case 'I':
                            //            {
                            //                paramatersCount++;
                            //                break;
                            //            }
                            //        case ')':
                            //            {
                            //                i = descriptor.Length;
                            //                break;
                            //            }
                            //        default:
                            //            {
                            //                break;
                            //            }
                            //    }
                            //}


                            for (int i = 0; i < test.Count; i++)
                            {
                                callingMethod.Locals[i] = Program.Stack.Pop();
                            }
                            callingMethod.Execute(constant_pool, method_info_manager);

                            currentOpCode = (OpCodes)code.Read1();
                            break;
                        }
                }
            }
            return null;
        }

        List<string> MatchDescriptor(string descriptor)
        {
            Regex pattern = new Regex(@"\((.*)\)(.*)");
            Match match = pattern.Match(descriptor);
            string paramaters = match.Groups[1].Value;
            string returnType = match.Groups[2].Value;

            List<string> matchableStrings = new List<string>()
            {
                "I",
                "Ljava/lang/String;"
            };

            string currentMatch = "";
            List<string> matches = new List<string>();

            for (int i = 0; i < paramaters.Length; i++)
            {
                currentMatch += paramaters[i];
                if (matchableStrings.Contains(currentMatch))
                {
                    matches.Add(currentMatch);
                    currentMatch = "";
                }
            }

            return matches;
        }
    }
}
