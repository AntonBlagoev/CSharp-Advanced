using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> tmpList = new List<string>();

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Print")
            {
                string[] tokens = commands.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string filterType = tokens[1].ToLower();

                Predicate<string> isStartWith = x => x.StartsWith(tokens[2]);
                Predicate<string> isEndtWith = x => x.EndsWith(tokens[2]);
                Predicate<string> isGivenLenght = x => x.Length == int.Parse(tokens[2]);
                Predicate<string> isContains = x => x.Contains(tokens[2]);

                if (tokens[0].StartsWith("Add"))
                {
                    if (filterType.StartsWith("start"))
                    {
                        AddFilter(peopleList, tmpList, isStartWith);
                    }
                    else if (filterType.StartsWith("end"))
                    {
                        AddFilter(peopleList, tmpList, isEndtWith);
                    }
                    else if (filterType.StartsWith("len"))
                    {
                        AddFilter(peopleList, tmpList, isGivenLenght);
                    }
                    else if (filterType.StartsWith("con"))
                    {
                        AddFilter(peopleList, tmpList, isContains);
                    }
                }
                else if (tokens[0].StartsWith("Remove"))
                {
                    if (filterType.StartsWith("start"))
                    {
                        RemoveFilter(peopleList, tmpList, isStartWith);
                    }
                    else if (filterType.StartsWith("end"))
                    {
                        RemoveFilter(peopleList, tmpList, isEndtWith);
                    }
                    else if (filterType.StartsWith("len"))
                    {
                        RemoveFilter(peopleList, tmpList, isGivenLenght);
                    }
                    else if (filterType.StartsWith("con"))
                    {
                        RemoveFilter(peopleList, tmpList, isContains);
                    }
                }

            }
            Console.Write(string.Join(' ', peopleList));
        }

        private static void AddFilter(List<string> peopleList, List<string> tmpList, Predicate<string> operation)
        {
            for (int i = 0; i < peopleList.Count; i++)
            {
                if (operation(peopleList[i]))
                {
                    tmpList.Add(peopleList[i]);
                    peopleList.RemoveAt(i);
                    i--;
                }
            }
        }
        private static void RemoveFilter(List<string> peopleList, List<string> tmpList, Predicate<string> operation)
        {
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (operation(tmpList[i]))
                {
                    peopleList.Insert(peopleList.Count - 1, tmpList[i]);
                    tmpList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
