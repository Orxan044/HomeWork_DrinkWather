
using HomeWork_DrinkWather.Menyu;
using System.Text.Json;

namespace HomeWork_DrinkWather;

internal class User
{

    public string? Name { get; set; }
    public string? UserName { get; set; }
    public double Weight { get; set; }

    public List<History>? HistoryDate { get; set; }
    public double CalWather => Weight / 20;
    public double TodayLT = 0;

    public void AppendUser(User user,string FileName)
    {

        List<User> users = new List<User>();
        if (File.Exists(FileName))
        {
            var jsonRead = File.ReadAllText(FileName);
            var jsonDeserialize = JsonSerializer.Deserialize<List<User>>(jsonRead);
            jsonDeserialize?.ForEach(j => users.Add(j));
        }
        users.Add(user);

        var json = JsonSerializer.Serialize(users, options: new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(FileName, json);
    }

    public void DrinkWather()
    {
        Console.Clear();
        Console.Write("Ne Qeder Su Icdiniz? -> ");
        string? TodayLtInput = Console.ReadLine();
        double result;
        double.TryParse(TodayLtInput,out result);
        TodayLT += result;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Nus Olsun !");
        Thread.Sleep(1500);
    }

    public void FinshDay(User user,string FileName)
    {
        List<User> users = new List<User>();

        if (File.Exists(FileName))
        {
            var jsonRead = File.ReadAllText(FileName);
            var jsonDeserialize = JsonSerializer.Deserialize<List<User>>(jsonRead);
            jsonDeserialize?.ForEach(j => users.Add(j));
            foreach (var item in users)
                if (item.UserName == user.UserName) item.HistoryDate?.Add(new(DateTime.Now, user.TodayLT));
            var json = JsonSerializer.Serialize(users, options: new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
            Console.WriteLine("Sabah Gorusunedek ;)");
            TodayLT = 0;
        }
    }

    public void ShowHistory(User user,string FileName)
    {
        Console.Clear();
        List<User> users = new();
        var jsonRead = File.ReadAllText(FileName);
        var jsonDeserialize = JsonSerializer.Deserialize<List<User>>(jsonRead);
        jsonDeserialize?.ForEach(j => users.Add(j));
        foreach (var userNew in users)
        {
            if(user.UserName == userNew.UserName)
            {
                foreach (var item in userNew.HistoryDate)
                {
                    Console.WriteLine($"Tarix -> {item.DateDrink.Day} , {item.DateDrink.Month} , {item.DateDrink.Year}");
                    Console.WriteLine($"Icdiyin Suyun Miqadari -> {item.DrinkWatherLT} lt");
                }
                
            }
        }
    }



}

