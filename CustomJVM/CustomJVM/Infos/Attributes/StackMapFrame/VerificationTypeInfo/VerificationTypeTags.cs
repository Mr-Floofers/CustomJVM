using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public enum VerificationTypeTags : byte
    {
        ITEM_Top = 0x00,
        ITEM_Integer = 0x01,
        ITEM_Float = 0x02,
        ITEM_Double = 0x03,
        ITEM_Long = 0x04,
        ITEM_Null = 0x05,
        ITEM_UninitializedThis = 0x06,
        ITEM_Object = 0x07,
        ITEM_Uninitialized = 0x08
    }
}
