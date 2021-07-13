using CustomJVM.ConstantPoolItems;
using CustomJVM.Infos.Attributes.StackMapFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomJVM
{
    public static class Extensions
    {
        public static byte Read1(this ref Memory<byte> hexdump) //u1
        {
            byte ret = hexdump.Span[0]; //Read byte at the top
            hexdump = hexdump.Slice(1); // Advance memory by 1 byte
            return ret;
        }
        public static ushort Read2(this ref Memory<byte> hexdump) //u2
        {
            Span<ushort> casted = MemoryMarshal.Cast<byte, ushort>(hexdump.Span);
            ushort ret = casted[0].ReverseBytes();
            hexdump = hexdump.Slice(2);
            return ret;
        }
        public static uint Read4(this ref Memory<byte> hexdump) //u4
        {
            Span<uint> casted = MemoryMarshal.Cast<byte, uint>(hexdump.Span);
            uint ret = casted[0].ReverseBytes();
            hexdump = hexdump.Slice(4);
            return ret;
        }
        public static ushort ReverseBytes(this ushort item)
        {
            byte lowByte = (byte)item;
            byte highByte = (byte)(item >> 8);
            return (ushort)(lowByte << 8 | highByte);
        }

        public static uint ReverseBytes(this uint item)
        {
            byte lowByte = (byte)item;
            byte midLowByte = (byte)(item >> 8);
            byte midHighByte = (byte)(item >> 16);
            byte highByte = (byte)(item >> 24);
            return (uint)(lowByte << 24 | midLowByte << 16 | midHighByte << 8 | highByte);
        }

        public static string UTF8ToString(this CP_Utf8_Info info)
        {
            string returnString = new string(info.Bytes.Select(x => (char)x).ToArray());
            return returnString;
        }

        public static RangeAttribute GetRange(this FrameTypes frameType)
            => frameType.GetType().GetCustomAttribute<RangeAttribute>();
    }
}
