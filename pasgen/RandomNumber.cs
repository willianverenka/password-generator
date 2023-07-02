namespace pasgen
{
    public static class RandomNumber
    {
        public static int GenerateRn(string characterSet) => System.Security.Cryptography.RandomNumberGenerator.GetInt32(0, characterSet.Length);
    }
}