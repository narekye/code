using System;
using System.Collections.Generic;
using System.Linq;

namespace Creational.Prototype
{
    public class Employee : IEmployee
    {
        public List<string> Countries { get; private set; }

        public void AddData()
        {
            Countries = new List<string>();
            Random random = new Random();
            string alphabet = "abcdefghijklmnopqrtuvwxyz";
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(alphabet.Take(random.Next(0, 24)).ToString());
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
