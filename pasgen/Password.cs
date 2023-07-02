namespace pasgen
{
    public class Password
    {
        private readonly int _length;
        private readonly bool _containsSpecialCharacters;
        private readonly string _desiredSet;
        public string FinalPassword { get; init; }
        public Password(int length, bool special_characters)
        {
            _length = length;
            _containsSpecialCharacters = special_characters;
            _desiredSet = _containsSpecialCharacters ? Characters.enabled_special_characters : Characters.disabled_special_characters;
            FinalPassword = GeneratePw();
        }
        private string GeneratePw()
        {
            string finalPassword = "";
            for(int i = 0; i < _length; i++)
            {
                int random = RandomNumber.GenerateRn(_desiredSet);
                char singleCharacter = _desiredSet[random];
                finalPassword += singleCharacter.ToString();
            }
            return finalPassword;
        }
    }
}