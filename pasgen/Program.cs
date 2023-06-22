using Zxcvbn;

namespace pasgen
{
    class Program
    {
        public class Characters
        {
            public static string disabled_special_characters = "QWERTYUIOPASDFGHJKLXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            public static string enabled_special_characters = "QWERTYUIOPASDFGHJKLXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890 !#$%&*+-./?@\\^_~";
        }
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Welcome to the password generator!\n");
            int intInput;
            while (true)
            {
                Console.WriteLine("1. Generate new password");
                Console.WriteLine("2. Exit");
                var input = Console.ReadLine();
                if (!ValidInput(input, out intInput) || intInput > 2 || intInput < 1)
                {
                    Console.Clear();
                    Console.WriteLine($"{input} is not a valid input");
                }
                else if (intInput == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Which length would you like?");
                    Console.WriteLine("You can generate a password from 8 up to 24 characters");
                    Console.WriteLine("PS: 14-18 are recommended.");
                    var pasInput = Console.ReadLine();
                    int lengthInput;
                    while (!ValidInput(pasInput, out lengthInput) || lengthInput < 8 || lengthInput > 24)
                    {
                        Console.Clear();
                        Console.WriteLine("Which length would you like?");
                        Console.WriteLine("You can generate a password from 8 up to 24 characters");
                        Console.WriteLine("PS: 14-18 are recommended.");
                        Console.WriteLine($"{pasInput} isn't a valid input.");
                        pasInput = Console.ReadLine();
                    }
                    Console.WriteLine("Would you like special characters? !@#$%^&* among others (Y/N)");
                    var ynInput = Console.ReadLine();
                    while (!ValidAssertiveInput(ynInput))
                    {
                        Console.WriteLine($"{ynInput} isn't a valid input.");
                        ynInput = Console.ReadLine();
                    }
                    Console.Clear();
                    Password generatedPassword = new Password(lengthInput, AssertiveInput(ynInput));
                    string password = generatedPassword.GetPassword();
                    var evaluatedPassword = Core.EvaluatePassword(password);
                    Console.WriteLine("Your generated password is:\n");
                    Console.WriteLine($"{password}\n");
                    Console.WriteLine($"Your password is {LudicFeedback(evaluatedPassword.Score)}.");
                    Console.WriteLine($"It could be cracked after 10^{(int)evaluatedPassword.GuessesLog10} guesses.\n");
                    Console.WriteLine("Would you like to copy it to the clipboard? (Y/N)");
                    ynInput = Console.ReadLine();
                    while (!ValidAssertiveInput(ynInput))
                    {
                        Console.WriteLine($"{ynInput} isn't a valid input.");
                        ynInput = Console.ReadLine();
                    }
                    if (AssertiveInput(ynInput))
                    {
                        Clipboard.SetText(password);
                        Console.WriteLine("Password copied to the clipboard.\n");
                    }
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }
        public class Password
        {
            private int length;
            private bool special_characters;
            private string finalPassword;
            private string desiredSet;
            public string GetPassword()
            {
                return finalPassword;
            }
            private void Generate()
            {
                string FinalPassword = "";
                for (int i = 0; i < length; i++)
                {
                    int random = RandomNumber(desiredSet);
                    char singleCharacter = desiredSet[random];
                    FinalPassword += singleCharacter.ToString();
                }
                finalPassword = FinalPassword;
            }
            public Password(int length, bool special_characters)
            {
                this.length = length;
                this.special_characters = special_characters;
                if (!special_characters)
                {
                    desiredSet = Characters.disabled_special_characters;
                }
                else
                {
                    desiredSet = Characters.enabled_special_characters;
                }
                Generate();
            }
        }
        public static string LudicFeedback(int score)
        {
            string feedbackString = "";
            switch (score)
            {
                case 0:
                    feedbackString = "very weak";
                    break;
                case 1:
                    feedbackString = "weak";
                    break;
                case 2:
                    feedbackString = "reasonable";
                    break;
                case 3:
                    feedbackString = "strong";
                    break;
                case 4:
                    feedbackString = "very strong";
                    break;
            }
            return feedbackString;
        }
        public static int RandomNumber(string characterSet)
        {
            return System.Security.Cryptography.RandomNumberGenerator.GetInt32(0, characterSet.Length);
        }
        public static bool AssertiveInput(string input)
        {
            return input.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }
        public static bool ValidAssertiveInput(string input)
        {
            return input.Equals("Y", StringComparison.OrdinalIgnoreCase) || input.Equals("N", StringComparison.OrdinalIgnoreCase);
        }
        public static bool ValidInput(string input, out int intInput)
        {
            return int.TryParse(input, out intInput);
        }

    }
}