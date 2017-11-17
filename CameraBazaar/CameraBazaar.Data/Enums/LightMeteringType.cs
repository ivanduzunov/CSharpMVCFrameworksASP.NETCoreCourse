using System;

namespace CameraBazaar.Data.Enums
{
    [Flags]
    public enum LightMeteringType
    {
        Spot = 1,
        CenterWeighted = 2,
        Evaluative = 4
    }
}
