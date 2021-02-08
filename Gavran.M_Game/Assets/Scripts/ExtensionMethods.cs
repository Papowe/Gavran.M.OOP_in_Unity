namespace GavranGame
{
    public static class ExtensionMethods
    {
        public static float TrySingle(this string str)
        {
            return float.TryParse(str, out var result) ? result : 0;
        }

        public static bool TryBool(this string str)
        {
            return bool.TryParse(str, out var result) && result;
        }
    }
}