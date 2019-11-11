using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.Utility
{
    public static class EnumConverter
    {
        public static EnumType Convert<EnumType>(Enum Enumerator) {
            return (EnumType)Enum.Parse(typeof(EnumType), Enumerator.ToString());
        }
    }
}
