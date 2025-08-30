using QuizProjectEF.Helper;
using QuizProject.Models;
using QuizProject.Services;
using QuizProject.Services.Interface;
using QuizProject.ReadPasswordWithStarss;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using QuizProjectEF.DBEntity;

QuizDBContext dbContext = new QuizDBContext();
IScoreService scoreServicee = new ScoreService(dbContext);

var userService = new UserService(dbContext);
var quizService = new QuizPlayerService(dbContext,scoreServicee);
var scoreService = new ScoreService(dbContext);
IChangeUserInfo changeUserInfo = new ChangeUserInfo();
ReadPasswordWithStarsss readPasswordWithStar = new ReadPasswordWithStarsss();


bool isRunning = true;

while (isRunning)
{
    User user = null;


    while (user == null)
    {
        Console.WriteLine(""" 
 █████╗ ██╗  ██╗ ██████╗      ██████╗ ██╗   ██╗██╗███████╗    
██╔══██╗██║ ██╔╝██╔═══██╗    ██╔═══██╗██║   ██║██║╚══███╔╝    
███████║█████╔╝ ██║   ██║    ██║   ██║██║   ██║██║  ███╔╝     
██╔══██║██╔═██╗ ██║   ██║    ██║▄▄ ██║██║   ██║██║ ███╔╝      
██║  ██║██║  ██╗╚██████╔╝    ╚██████╔╝╚██████╔╝██║███████╗    
╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝      ╚══▀▀═╝  ╚═════╝ ╚═╝╚══════╝    
""");
        Console.WriteLine("\n1. Qeydiyyat");
        Console.WriteLine("2. Giriş");
        Console.WriteLine("3. Çıxış");
        Console.Write("Seçim: ");
        var option = Console.ReadLine();

        if (option == "1")
        {
            string username;
            do
            {
                Console.Write("İstifadəçi adı: ");
                username = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(username) || username.Length < 3 || username.Length > 10)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("İstifadəçi adı 3 ve ya 10 simvol arasında olmalıdır!");
                    Console.ResetColor();
                }
                else if (dbContext.Users.Any(u => u.UserName == username)) 
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bu istifadəçi adı artıq mövcuddur.");
                    Console.ResetColor();
                    username = null;
                }
            } while (string.IsNullOrEmpty(username) || username.Length < 3 || username.Length > 10);


            string password;
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d).{8,}$");

            do
            {
                Console.Write("Şifrə Daxil Edin:  ");
                password = ReadPasswordWithStarsss.ReadPasswordWithStars();

                if (!regex.IsMatch(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Şifrə ən az 8 simvol olmalı, ən azı 1 hərf və 1 rəqəm daxil edilməlidir!");
                    Console.ResetColor();
                }
            } while (!regex.IsMatch(password));
            string hashedPassword = HashPassword.HashPasswordd(password);


            DateTime dateofbirth;
            while (true)
            {
                Console.Write("\nDoğum tarixi Il-Ay-Gün : ");
                string dateInput = Console.ReadLine()?.Trim();

                if (DateTime.TryParse(dateInput, out dateofbirth))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yanlış format! Tarix İl-Ay-Gün formatında olmalıdır.");
                Console.ResetColor();
            }


            user = userService.Register(username, hashedPassword, dateofbirth);
        }
        else if (option == "2")
        {
            Console.Write("İstifadəçi adı: ");
            var username = Console.ReadLine();
            Console.Write("Şifrə: ");
            var password = ReadPasswordWithStarsss.ReadPasswordWithStars();
            var hashedPassword = HashPassword.HashPasswordd(password);

            Console.Clear();
            user = userService.Login(username, hashedPassword);
            Console.ForegroundColor = ConsoleColor.Red;
            if (user == null) Console.WriteLine("Yanlış giriş.");
            Console.ResetColor();
            Console.WriteLine();
        }
        else if (option == "3")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Quizi Test Etdiyiniz Üçün Təşəkkürlər :) ");
            Console.ResetColor();
            return;
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Yanlış Seçim Etdiniz! ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    Console.Clear();

    bool inMainMenu = true;

    while (inMainMenu)
    {
        Console.WriteLine($"\nXoş gəlmisiniz, {user.UserName}!");

        Console.WriteLine("\n1. Quiz başla");
        Console.WriteLine("2. Məlumat dəyişmək");
        Console.WriteLine("3. Nəticələrim");
        Console.WriteLine("4. Sıralama");
        Console.WriteLine("5. Hesabdan çıxış");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Clear();
            var categories = quizService.GetCategories();
            Console.WriteLine("Kateqoriyalar:");
            for (int i = 0; i < categories.Count; i++)
                Console.WriteLine($"{i + 1}. {categories[i]}");

            if (!categories.Contains("Qarışıq"))
            {
                Console.WriteLine($"{categories.Count + 1}. Qarışıq");
            }

            Console.WriteLine("0. Geri");


            Console.Write("Seçim: ");
            var input = Console.ReadLine();
            Console.Clear();

            if (input == "0")
            {
                Console.Clear();
                continue;

            }

            if (int.TryParse(input, out int index))
            {
                if (index > 0 && index <= categories.Count)
                {
                    var selectedCategory = categories[index - 1];
                    int score = quizService.PlayQuizAndReturnScore(selectedCategory);

                    var selectedQuiz = dbContext.Quizzes.FirstOrDefault(q => q.Category == selectedCategory);

                    scoreService.SaveScore(new UserScore
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        QuizId = selectedQuiz.QuizId,
                        Category = selectedCategory,
                        Score = score,
                        Date = DateTime.Now
                    });
                }
                else if (index == categories.Count + 1)
                {
                    int score = quizService.PlayMixedQuiz(20);

                    var originalQuestions = dbContext.Questions
                        .Where(q => q.Quiz.Category != "Qarışıq")
                        .OrderBy(q => Guid.NewGuid())
                        .Take(20)
                        .ToList();

                    var mixedQuestions = new List<Question>();

                    foreach (var q in originalQuestions)
                    {
                        var newQuestion = new Question
                        {
                            Text = q.Text,
                            Answers = new List<Answer>()
                        };

                        foreach (var a in q.Answers)
                        {
                            newQuestion.Answers.Add(new Answer
                            {
                                Text = a.Text,
                                IsCorrect = a.IsCorrect
                            });
                        }

                        mixedQuestions.Add(newQuestion);
                    }


                    var mixedQuiz = new Quiz
                    {
                        Category = "Qarışıq",
                        Questions = mixedQuestions
                    };

                    dbContext.Quizzes.Add(mixedQuiz);
                    dbContext.SaveChanges();

                    if (scoreService == null)
                    {
                        Console.WriteLine("ScoreService null dur!");
                        return;
                    }

                    if (user == null)
                    {
                        Console.WriteLine("User null dur!");
                        return;
                    }

                    if (mixedQuiz == null)
                    {
                        Console.WriteLine("MixedQuiz null dur!");
                        mixedQuiz = dbContext.Quizzes.FirstOrDefault(); 
                    }


                    scoreService.SaveScore(new UserScore
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        QuizId = mixedQuiz.QuizId,
                        Category = "Qarışıq",
                        Score = score,
                        Date = DateTime.Now
                    });

                }
                else
                {
                    Console.WriteLine("Yanlış seçim!");
                }
            }
            else
            {
                Console.WriteLine("Yanlış seçim!");
            }
        }
        else if (choice == "2")
        {
            changeUserInfo.ChangeUserInfoo(user, userService);
            Console.Clear();
            break;
        }
        else if (choice == "3")
        {
            Console.Clear();
            Console.WriteLine($"\n{user.UserName} adlı istifadəçinin nəticələri:");
            var scores = scoreService.GetUserScores(user.UserName);
            if (scores.Count == 0)
            {
                Console.WriteLine("Nəticə yoxdur.");
            }
            else
            {
                foreach (var s in scores.OrderByDescending(x => x.Date))
                {
                    int wrong = 20 - s.Score;
                    Console.WriteLine($"{s.Date:yyyy-MM-dd} | {s.Category} | Düzgün: {s.Score} | Səhv: {wrong}");
                }
            }
            Console.WriteLine("Çıxmaq istəyirsinizsə  hər hansı bir düyməyə basın..");
            Console.ReadKey();
            Console.Clear();
        }
        else if (choice == "4")
        {
            Console.Clear();
            var categories = quizService.GetCategories();

            Console.WriteLine("Kateqoriyalar:");
            for (int i = 0; i < categories.Count; i++)
                Console.WriteLine($"{i + 1}. {categories[i]}");

            Console.Write("Seçim: ");
            var index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= categories.Count)
            {
                Console.WriteLine("Yanlış seçim!");
                return;
            }

            var selectedCategory = categories[index];

            Console.WriteLine($"\n {selectedCategory} üzrə Sıralama:\n");
            var topScores = scoreService.GetTopScores(selectedCategory, 20);

            if (topScores.Count == 0)
                Console.WriteLine("Heç bir nəticə yoxdur.");
            else
            {
                int rank = 1;
                foreach (var s in topScores)
                    Console.WriteLine($"{rank++}. {s.UserName} — {s.Score} xal ({s.Date:yyyy-MM-dd})");
            }
            Console.WriteLine("Çıxmaq istəyirsinizsə hər hansı bir düyməyə basın..");
            Console.ReadKey();
            Console.Clear();
        }

        else if (choice == "5")
        {
            inMainMenu = false;
            Console.Clear();
            break;
        }

        else 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Yanlış Seçim Etdiniz! ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

}
