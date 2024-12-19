using System;
using System.Collections.Immutable;

namespace ManhattanCoreLogic.GlobalConstants;

public static class Constants
{
    public static readonly Dictionary<int, char[]> CopyPatterns = new Dictionary<int, char[]>()
    {
        {0, new[] {'2', '3', '1'}},
        {1, new[] {'5', '6', '4'}},
        {2, new[] {'8', '9', '7'}},
    };

    
}
