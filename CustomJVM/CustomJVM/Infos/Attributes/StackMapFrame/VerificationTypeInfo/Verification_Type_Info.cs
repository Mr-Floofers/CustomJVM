using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM.Infos.Attributes.StackMapFrame.VerificationTypeInfo
{
    public abstract class Verification_Type_Info
    {
        //[FieldOffset(0)]
        //public Top_Variable_Info Top_Variable_Info;

        //[FieldOffset(0)]
        //public Integer_Variable_Info Integer_Variable_Info;

        //[FieldOffset(0)]
        //public Float_Variable_Info Float_Variable_Info;

        //[FieldOffset(0)]
        //public Long_Variable_Info Long_Variable_Info;

        //[FieldOffset(0)]
        //public Double_Variable_Info Double_Variable_Info;

        //[FieldOffset(0)]
        //public Null_Variable_Info Null_Variable_Info;

        //[FieldOffset(0)]
        //public UninitializedThis_Variable_Info UninitializedThis_Variable_Info;

        //[FieldOffset(0)]
        //public Object_Variable_Info Object_Variable_Info;

        //[FieldOffset(0)]
        //public Uninitialized_Variable_Info Uninitialized_Variable_Info;

        //[FieldOffset(1)]
        //public VerificationTypeTags CurrentVerificationType;

        public void Parse(ref Memory<byte> hexdump)
        {
            VerificationTypeTags currentTag = (VerificationTypeTags)hexdump.Read1();
            switch (currentTag)
            {
                case VerificationTypeTags.ITEM_Top:
                    //Top_Variable_Info = new Top_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Integer:
                    //Integer_Variable_Info = new Integer_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Float:
                    //Float_Variable_Info = new Float_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Double:
                    //Double_Variable_Info = new Double_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Long:
                    //Long_Variable_Info = new Long_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Null:
                    //Null_Variable_Info = new Null_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_UninitializedThis:
                    //UninitializedThis_Variable_Info = new UninitializedThis_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Object:
                    //Object_Variable_Info = new Object_Variable_Info();
                    break;
                case VerificationTypeTags.ITEM_Uninitialized:
                    //Uninitialized_Variable_Info = new Uninitialized_Variable_Info();
                    break;
            }
        }
    }
}
