using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("[]{}()"));
        }

        public static bool IsValid(string s)
        {
            bool result = false;
            bool match = true;
            for (int i = 0; i < s.Length - 1; i += 2)
            {
                var temp = s.Substring(i, 2);

                var x = Convert.ToInt16(temp[0]);
                var y = Convert.ToInt16(temp[1]);

                if (temp[0] == '(')
                {
                    if (x + 1 == y)
                    {
                        match = true;
                    }
                    else
                    {
                        match = false;
                    }

                    if (temp[1] == ')')
                    {
                        match = true;
                    }
                    else
                    {
                        match = false;
                    }
                }
                else
                {
                    if (x + 2 == y)
                        match = true;
                    else
                        match = false;
                }
                result = match;
            }
            return result && match;
        }
    }
}
