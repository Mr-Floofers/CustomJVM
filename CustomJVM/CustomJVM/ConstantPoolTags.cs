using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM
{
    public enum ConstantPoolTags : byte
    {
        CP_Utf8_Info = 0x01,
        CP_Integer_Info = 0x03,
        CP_Float_Info = 0x04,
        CP_Long_Info = 0x05,
        CP_Double_Info = 0x06,
        CP_Class_Info = 0x07,
        CP_String_Info = 0x08,
        CP_FieldRef_Info = 0x09,
        CP_MethodRef_Info = 0x0A,
        CP_InterfaceMethodRef_Info = 0x0B,
        CP_NameAndType_Info = 0x0C,
        CP_MethodHandle_Info = 0x0F,
        CP_MethodType_Info = 0x10,
        CP_Dynamic_Info = 0x11,
        CP_InvokeDynamic_Info = 0x12,
        CP_Module_Info = 0x13,
        CP_Package_Info = 0x14,
    }
}
