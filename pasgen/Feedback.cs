namespace pasgen
{
    public static class Feedback
        {
            public static string Description(int score)
            {
                string feedbackString;
                switch(score)
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
                    default:
                        feedbackString = string.Empty;
                        break;
                }
                return feedbackString;
            }
        }
}