namespace Turbo.plugins.patrick.skills.util
{
    using System.Collections.Generic;

    public static class CompareWithOperator
    {
        public static readonly List<string> AllOperators = new List<string>
        {
            "equal to",
            "unequal to",
            "less than",
            "greater than"
        };

        public static bool Compare(int actual, int excepted, string op)
        {
            switch (op)
            {
                case "equal to":
                    return actual == excepted;
                case "unequal to":
                    return actual != excepted;
                case "less than":
                    return actual < excepted;
                case "greater than":
                    return actual > excepted;
                default:
                    return false;
            }
        }
    }
}