namespace HomeWork_DrinkWather.Menyu;

internal class Register
{   
    public static void Eror(string FileName)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Xais Olnur Mellumati Duzgun Daxil Edin !!!");
        Console.ResetColor();
        RegisterUser(FileName);
    } 
    public static void RegisterUser(string FileName)
    {
        Console.Write("Adiniz-> ");
        string? InputName = Console.ReadLine();
        while (string.IsNullOrEmpty(InputName)) Eror(FileName);

        Console.Write("Istifadeci Adiniz(*Programa Daxil Olduqda*)-> ");
        string? InputUserName = Console.ReadLine();
        while (string.IsNullOrEmpty(InputUserName)) Eror(FileName);

        double result;
        Console.Write("Chekiniz-> ");
        string? InputWeight = Console.ReadLine();
        while (string.IsNullOrEmpty(InputWeight) || !double.TryParse(InputWeight,out result)) Eror(FileName);

        List<History> history = new();

        //User user = new(InputName, InputUserName,result,history); 

        var user = new User
        {
            Name = InputName,
            UserName = InputUserName,
            Weight = result,
            HistoryDate = new()
        };


        //User user = new()
        //{
        //    Name = InputName,
        //    UserName = InputUserName,
        //    Weight = result,
        //    HistoryDate = new() {}
        //};

        user.AppendUser(user,FileName);
             
    }

}

