namespace pasgen
{
    public static class Input
    {
        public static bool IsYes(string input) => input.Equals("Y", StringComparison.OrdinalIgnoreCase);
        public static bool IsYesOrNo(string input) => input.Equals("Y", StringComparison.OrdinalIgnoreCase) || input.Equals("N", StringComparison.OrdinalIgnoreCase);
        public static bool IsValidInteger(string input, out int intInput) => int.TryParse(input, out intInput);
    }
}