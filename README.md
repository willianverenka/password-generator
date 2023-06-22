# password-generator
This is a simple yet effective console application that generates a random password based on the user preferences.
It is entirely build upon .NET 7.0 platform with C#. 

The algorithm employs the .NET System.Security.Cryptography namespace to produce random integers, instead of using the built-in Random class. This is because the Random class generates pseudo-random numbers, which are not suitable for security purposes.
The feedback provided by the application is the Zxcvbn password strength estimation library, you can check the used C# implementation [here.(https://github.com/trichards57/zxcvbn-cs)]

##Getting started
You can build it yourself from the source code using Visual Studio or another IDE that supports .NET, or you can download the executable from releases.

###Prerequisistes

Make sure you have .NET SDK 7.0 or over installed.
You can check it opening the cmd and inserting **dotnet --info**.
If it doesnt't work, you can follow the steps from [Microsoft(https://dotnet.microsoft.com/download)] to download it. `

###Installing
1. Clone the repository to your local machine: `git clone https://github.com/willianverenka/password-generator.git`
2. Navigate to the project directory: `cd pasgen`

###Usage
1. Run the program: `dotnet run`
2. You will be prompted to select options to navigate through the menu and to select your criteria (length and special characters) to generate a password.
3. When your password is ready, you have the option to copy it to your clipboard so you can paste it wherever you want. If you didn't like the password, you can just go back to the menu and generate another one.
4. You can exit safely the program through the available menu or just closing it yourself.
