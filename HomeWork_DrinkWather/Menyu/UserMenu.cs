using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeWork_DrinkWather.Menyu;

internal class UserMenu
{
    private static void HelpMenu(User user)
    {
        Console.Clear();
        Console.WriteLine($"Salam, {user.Name} ,Siz Gun Erzinde {user.CalWather} lt SU icmelisiz !");
        Console.WriteLine("----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Bugun Icdiyiniz Su -> {user.TodayLT} lt");
        Console.ForegroundColor = ConsoleColor.Green;
        if (user.CalWather <= user.TodayLT) Console.WriteLine("Siz Bu gun Su Icmeyi TAMAMLAMISIZ !!!");
        else Console.WriteLine($"Siz Bu gun {user.CalWather - user.TodayLT} lt SU icib Qutarmalisiz !");
        Console.ResetColor();
    }
    public static void UserMenuProgram(User user,string FileName)
    {
        HelpMenu(user);

        string[] Menyu = { "Su Icdim", "Tarixce", "Gunu Bitir","Chxis" };
        int Index = 0;
        while (true)
        {
            HelpMenu(user);
            Console.WriteLine("\n\n");

            for (int i = 0; i < Menyu.Length; i++)
            {
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("=> ");
                }
                else Console.Write("   ");
                Console.WriteLine(Menyu[i]);
                Console.ResetColor();
            }
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Index = Math.Max(0, Index - 1);
                    break;
                case ConsoleKey.DownArrow:
                    Index = Math.Min(Menyu.Length - 1, Index + 1);
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (Index == 0) { user.DrinkWather(); UserMenuProgram(user,FileName); }
                    if (Index == 2) { user.FinshDay(user,FileName);}
                    if (Index == 3) { break; }
                    return;
            }

        }

    }
}
