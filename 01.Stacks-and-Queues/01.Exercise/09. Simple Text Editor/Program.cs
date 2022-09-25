using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;

            Stack<string> undoStack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "1":
                        undoStack.Push(text);
                        text += commands[1];
                        break;

                    case "2":
                        undoStack.Push(text);
                        int count = int.Parse(commands[1]);
                        text = text.Remove(text.Length - count, count);
                        break;

                    case "3":
                        int index = int.Parse(commands[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;

                    case "4":
                        text = undoStack.Pop();
                        break;
                }


            }
        }
    }
}
