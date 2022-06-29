using System;
using System.Collections.Generic;
using System.Text;

namespace minesweeper
{
    class Graphics
    {
        public void Mine()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("__");
            Console.ResetColor();
        }
        public void Hidden()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("__");
            Console.ResetColor();
        } 
        public void HiddenLight()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("__");
            Console.ResetColor();
        }
        public void WriteCyan(string x)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(x);
            Console.ResetColor();
        }
    }
}

