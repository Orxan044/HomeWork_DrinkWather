using HomeWork_DrinkWather.Menyu;
using System.Text.Json;

namespace HomeWork_DrinkWather;

internal class Program
{
    static void Main(string[] args)
    {
        string? FileNameUser = "DateUser.json"; 
        MenyuHelp.Menyu(FileNameUser);
    }
}

