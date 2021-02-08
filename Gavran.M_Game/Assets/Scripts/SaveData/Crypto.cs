namespace GavranGame
{
    public static class Crypto
    {
        public static string CryptoXOR(string str, int key = 666)
        {
            var result = string.Empty;
            foreach (var item in str)
            {
                result += (char)(item ^ key);
            }
            return result;
        }
    }
}