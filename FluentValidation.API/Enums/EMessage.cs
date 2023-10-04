using System.ComponentModel;

namespace FluentValidation.API.Enums;

public enum EMessage : ushort
{
    [Description("{0} need to be filled.")]
    Required,

    [Description("{0} allows {1} chars.")]
    InvalidLength,

    [Description("{0} is in the wrong format, it should be: {1}.")]
    InvalidFormat,

    [Description("{0} has to be greater than {1}.")]
    GreaterThan
}
