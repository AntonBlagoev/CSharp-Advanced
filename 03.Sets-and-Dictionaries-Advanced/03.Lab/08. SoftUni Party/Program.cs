using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            bool isParty = false;
            string guest = string.Empty;
            while ((guest = Console.ReadLine()) != "END")
            {
                if (guest == "PARTY")
                {
                    isParty = true;
                }
                if (!isParty)
                {
                    if (Char.IsDigit(guest[0]))
                    {
                        vipGuests.Add(guest);
                    }
                    else
                    {
                        regularGuests.Add(guest);
                    }
                }
                else
                {
                    if (vipGuests.Contains(guest))
                    {
                        vipGuests.Remove(guest);
                    }
                    else if (regularGuests.Contains(guest))
                    {
                        regularGuests.Remove(guest);
                    }
                }
            }
            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            if (vipGuests.Count > 0)
            {
                foreach (var vipGuest in vipGuests)
                {
                    Console.WriteLine(vipGuest);
                }
                foreach (var regularGuest in regularGuests)
                {
                    Console.WriteLine(regularGuest);
                }
            }
            else
            {
                foreach (var regularGuest in regularGuests)
                {
                    Console.WriteLine(regularGuest);
                }
            }
        }
    }
}
