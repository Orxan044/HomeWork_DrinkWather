using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_DrinkWather.Menyu;

internal class MenyuHelp
{
    public static void Menyu(string FileName) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\tSu Saglamligdir!!");
        Console.ResetColor();

        string[] Menyu = { "Daxil Olun", "Qeydiyyat" };
        int Index = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tSu Saglamligdir!!");
            Console.ResetColor();

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
                    if (Index == 0) SigIn.SigInProgram(FileName);
                    else Register.RegisterUser(FileName);

                    return;
            }

        }


    }

}

