using System;
using System.Collections.Generic;

namespace _08.Threeuple
{
    public class Tuple
    {
        public object Item1  { get; set; }
        public object Item2 { get; set; }
        public object Item3 { get; set; }

        public Tuple(object item1, object item2, object item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public static bool IsDrunk(object item)
        {
            if (item.Equals("drunk"))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            
            return $"{Item1} -> {Item2} -> {Item3}";
        }

    }
}
