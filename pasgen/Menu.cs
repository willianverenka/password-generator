namespace pasgen
{
    public class Menu
    {
        private readonly string[] _content;
        private readonly string _uniqueContent;
        private readonly bool _useNumbering;
        public Menu(string[] content, bool useNumbering)
        {
            _content = content;
            _useNumbering = useNumbering;
        }
        public Menu(string uniqueContent)
        {
            _uniqueContent = uniqueContent;
        }
        public void Display()
        {
            if(_uniqueContent != null)
            {
                Console.WriteLine(_uniqueContent);
                return;
            }
            if(_useNumbering)
            {
                for(int i = 0; i < _content.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {_content[i]}");
                }
            }
            else
            {
                for(int i = 0; i < _content.Length; i++)
                {
                    Console.WriteLine(_content[i]);
                }
            }
        }
    }
}