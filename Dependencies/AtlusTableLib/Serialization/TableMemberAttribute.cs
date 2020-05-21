using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TGELib.Reflection;

namespace AtlusTableLib.Serialization
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TableMemberAttribute : Attribute
    {
        public int LineNumber { get; }

        public TableMemberType MemberType { get; }

        public int FixedArrayLength { get; set; }

        public int FixedStringLength { get; set; }

        public TableMemberAttribute(TableMemberType type = TableMemberType.FieldOrProperty, [CallerLineNumber]int lineNumber = 0)
        {
            MemberType = type;
            LineNumber = lineNumber;
            FixedArrayLength = -1;
            FixedStringLength = -1;
        }
    }

    public enum TableMemberType
    {
        FieldOrProperty = 0,
        Segment,
        VariableLengthStringSegmentPair,
    }
}