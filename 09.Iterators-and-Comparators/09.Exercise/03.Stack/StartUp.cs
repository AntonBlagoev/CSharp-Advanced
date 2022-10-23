using System;

namespace _03.Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries); //

                if (tokens[0] == "Push")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        myStack.Push(tokens[i]);
                    }
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

