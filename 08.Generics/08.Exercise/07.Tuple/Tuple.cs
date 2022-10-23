using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class Tuple
    {
        public object Item1  { get; set; }
        public object Item2 { get; set; }
        public Tuple(object item1, object item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }

    }
}
