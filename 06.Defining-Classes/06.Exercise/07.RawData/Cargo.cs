﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}

