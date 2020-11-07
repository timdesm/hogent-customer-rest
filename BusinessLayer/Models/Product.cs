using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessLayer.Models
{
    public enum Product
    {
        [EnumMember(Value = "Leffe")]
        LEFFE,

        [EnumMember(Value = "Westmalle")]
        WESTMALLE,

        [EnumMember(Value = "Orval")]
        ORVAL,

        [EnumMember(Value = "Duvel")]
        DUVEL
    }
}
