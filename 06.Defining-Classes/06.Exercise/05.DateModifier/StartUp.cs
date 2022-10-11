using System;


namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            DateModifier days = new DateModifier(dateOne, dateTwo);
            Console.WriteLine(days.DaysCalc());

        }
    }
}
