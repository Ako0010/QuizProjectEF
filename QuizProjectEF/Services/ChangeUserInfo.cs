
using System.Text.RegularExpressions;
using QuizProject.Models;
using QuizProject.Services.Interface;

namespace QuizProject.Services;

public class ChangeUserInfo : IChangeUserInfo
{
    public void ChangeUserInfoo(User user, UserService userService)
    {
        Console.Clear();
        Console.WriteLine("Melumat Deyismek");
        Console.WriteLine("1. Şifrəni dəyiş");
        Console.WriteLine("2. Doğum tarixini dəyiş");
        Console.WriteLine("3. Geri Qayit");
        Console.Write("Seçim: ");
        var secim = Console.ReadLine();

        Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d).{8,}$");

        switch (secim)
        {
            case "1":
                do
                {
                    Console.Write("Yeni şifrə daxil edin: ");
                    var newPassword = Console.ReadLine();
                    if (newPassword == null || newPassword.Trim() == "")
                    {
                        Console.WriteLine("Şifrə boş ola bilməz!");
                    }
                    else if (!regex.IsMatch(newPassword))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Şifrə ən az 8 simvol olmalı, ən azı 1 hərf və 1 rəqəm daxil edilməlidir!");
                        Console.ResetColor();
                    }
                    else
                    {
                        user.Password = newPassword;
                        userService.UpdateUser(user);
                        Console.WriteLine("Şifrə uğurla dəyişdirildi.");
                        break;
                    }
                } while (true);
                break;


            case "2":
                Console.Write("Yeni doğum tarixini daxil edin (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDob))
                {
                    user.BirthDate = newDob;
                    userService.UpdateUser(user);
                    Console.WriteLine("Doğum tarixi uğurla dəyişdirildi.");
                }
                else
                {
                    Console.WriteLine("Yanlış tarix formatı.");
                }
                break;

            case "3":
                return;

            default:
                Console.WriteLine("Yanlış seçim!");
                break;
        }

        Console.WriteLine("Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }
}

