using System.Text.Json;

namespace HomeWork_DrinkWather.Menyu;

internal class SigIn
{
    public static void SigInProgram(string FileName)
    {
        Console.Write("Istifadeci Adiniz-> ");
        string? InputUserName = Console.ReadLine();
        while (string.IsNullOrEmpty(InputUserName))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Duzgun Mellumat Daxil Edin !!!");
            Console.ResetColor();
            SigInProgram(FileName);
        }

        if (File.Exists(FileName))
        {
            List<User> users = new();
            bool check = true;
            var jsonRead = File.ReadAllText(FileName);
            var jsonDeserialize = JsonSerializer.Deserialize<List<User>>(jsonRead);
            jsonDeserialize?.ForEach(j => users.Add(j));

            foreach (var user in users)
            {
                if (user.UserName == InputUserName) { check = false; UserMenu.CheckDay(user, FileName); }
            }
            if (check)
            { 
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Istifadeci Tapilmadi!!!");
                Console.ResetColor();
                SigInProgram(FileName); 
            }
        
        }

    }
}

