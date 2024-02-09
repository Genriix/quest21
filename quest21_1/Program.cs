using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quest21_1
{
    public delegate void PressKeyEventHandler();

    public class Keyboard
    {
        PressKeyEventHandler pressKey = null;

        public event PressKeyEventHandler PressKey
        {
            add { pressKey += value; }
            remove { pressKey -= value; }
        }

        public void InvokeKey()
        {
            pressKey.Invoke();
        }
    }

    class Program
    {
        static private void PressKeyA_Handler()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(
                "     X     \n" +
                "    X X    \n" +
                "   X   X   \n" +
                "  XXXXXXX  \n" +
                " X       X \n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static private void PressKeyB_Handler()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(
                " XXXXXX   \n" +
                " X     X  \n" +
                " XXXXXX   \n" +
                " X     X  \n" +
                " XXXXXX   \n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main()
        {
            Keyboard keyboard = new Keyboard();
            Console.WriteLine("Введите [ a | b ]\nДля выхода нажмите [ Esc ]");

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case (ConsoleKey.A):
                        {
                            Console.Clear();
                            Console.WriteLine("Введите [ a | b ]\nДля выхода нажмите [ Esc ]");
                            keyboard.PressKey += PressKeyA_Handler;
                            keyboard.InvokeKey();
                            keyboard.PressKey -= PressKeyA_Handler;
                            break;
                        }
                    case (ConsoleKey.B):
                        {
                            Console.Clear();
                            Console.WriteLine("Введите [ a | b ]\nДля выхода нажмите [ Esc ]");
                            keyboard.PressKey += PressKeyB_Handler;
                            keyboard.InvokeKey();
                            keyboard.PressKey -= PressKeyB_Handler;
                            break;
                        }
                    case (ConsoleKey.Escape):
                        {
                            return;
                        }
                }
            }
        }
    }
}
