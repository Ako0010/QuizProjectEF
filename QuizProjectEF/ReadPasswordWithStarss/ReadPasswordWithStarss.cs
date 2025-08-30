

namespace QuizProject.ReadPasswordWithStarss;

public class ReadPasswordWithStarsss
{
    public static string ReadPasswordWithStars()
    {
        string password = "";
        ConsoleKeyInfo info = Console.ReadKey(true);
        while (info.Key != ConsoleKey.Enter)
        {
            if (info.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                password += info.KeyChar;
                Console.Write("*");
            }
            info = Console.ReadKey(true);
        }
        return password;
    }
}
