using Zxcvbn;
using System.Diagnostics;

namespace pasgen
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            bool IsWindows = Environment.OSVersion.Platform == PlatformID.Win32NT;
            Console.Clear();
            Console.WriteLine("Welcome to the password generator!\n");
            int intInput;
            while(true)
            {
                var mainMenu = new Menu(new string[] {"Generate new password", "Visit Github repository", "Exit"}, true);
                mainMenu.Display();
                var input = Console.ReadLine();
                while(!Input.IsValidInteger(input, out intInput) || intInput > 3 || intInput < 1)
                {
                    Console.Clear();
                    mainMenu.Display();
                    Console.WriteLine($"{input} is not a valid input\n");
                    input = Console.ReadLine();
                }
                if(intInput == 1)
                {
                    Console.Clear();
                    var userPreferenceMenu = new Menu(new string[]
                    {
                        "Which length would you like?",
                        "You can generate a password from 8 up to 24 characters",
                        "TIP: Following BitWarden password strength chart, it should have at least 14 characters."
                    }, false);
                    userPreferenceMenu.Display();
                    var pasInput = Console.ReadLine();
                    int lengthInput;
                    while(!Input.IsValidInteger(pasInput, out lengthInput) || lengthInput < 8 || lengthInput > 24)
                    {
                        Console.Clear();
                        userPreferenceMenu.Display();
                        Console.WriteLine($"{pasInput} isn't a valid input.");
                        pasInput = Console.ReadLine();
                    }
                    var specialCharactersMenu = new Menu("Do you want to include special characters such as !@#$%^&* in your password? (Y/N)");
                    specialCharactersMenu.Display();    
                    var ynInput = Console.ReadLine();
                    while(!Input.IsYesOrNo(ynInput))
                    {
                        specialCharactersMenu.Display();
                        Console.WriteLine($"{ynInput} isn't a valid input.");
                        ynInput = Console.ReadLine();
                    }
                    Console.Clear();
                    Password generatedPassword = new Password(lengthInput, Input.IsYes(ynInput));
                    string password = generatedPassword.FinalPassword;
                    var evaluatedPassword = Core.EvaluatePassword(password);
                    var passwordRevelationMenu = new Menu(new string[] {
                        "Your generated password is:",
                        $"{password}",
                        $"Your password is {Feedback.Description(evaluatedPassword.Score)}.",
                        $"It could be cracked after 10^{(int)evaluatedPassword.GuessesLog10} guesses."
                    }, false);
                    if(IsWindows)
                    {
                        passwordRevelationMenu.Display();
                        var clipboardMenu = new Menu("Would you like to copy it to the clipboard? (Y/N)");
                        clipboardMenu.Display();
                        ynInput = Console.ReadLine();
                        while(!Input.IsYesOrNo(ynInput))
                        {
                            clipboardMenu.Display();
                            Console.WriteLine($"{ynInput} isn't a valid input.");
                            ynInput = Console.ReadLine();
                        }
                        if(Input.IsYes(ynInput))
                        {
                            Console.Clear();
                            Clipboard.SetText(password);
                            Console.WriteLine("Password copied to the clipboard.\n");
                        }
                    }
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(intInput == 2)
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = "https://github.com/willianverenka/password-generator",
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    }
                    catch(Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine($"An error occurred while opening the web page: {ex.Message}");
                        Console.WriteLine($"You can manually search for willianverenka/password-generator if you wish.\n");
                        if(IsWindows)
                        {
                            var clipboardMenu = new Menu("Would you like to copy the URL to the clipboard? (Y/N)");
                            clipboardMenu.Display();
                            var errorInput = Console.ReadLine();
                            while(!Input.IsYesOrNo(errorInput))
                            {
                                clipboardMenu.Display();
                                Console.WriteLine($"{errorInput} isn't a valid input.");
                            }
                            if(Input.IsYes(input))
                            {
                                Clipboard.SetText("https://github.com/willianverenka/password-generator");
                                Console.WriteLine("URL copied to the clipboard.");
                            }
                        }
                        Console.WriteLine("Press any key to go back to the main menu.");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }
    }
}