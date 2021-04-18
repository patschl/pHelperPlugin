namespace Turbo.plugins.patrick.skills
{
    using System.Collections.Generic;

    public static class SnoPowerList
    {
        public static readonly Dictionary<string, int> CoeElementToIndex = new Dictionary<string, int>
        {
            {"Arcane", 1},
            {"Cold", 2},
            {"Fire", 3},
            {"Holy", 4},
            {"Lightning", 5},
            {"Physical", 6},
            {"Poison", 7}
        };
    }
}