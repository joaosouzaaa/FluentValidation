using System.ComponentModel;

namespace FluentValidation.API.Enums;

public enum EMessage : ushort
{
    [Description("{0} need to be filled")]
    Required,

    [Description("Field {0} allows {1} chars")]
    InvalidLength,
}
