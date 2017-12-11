using sharp.Extensions.ExportFiles;
using System;
using System.Collections.Generic;

namespace sharp.Extensions.Client
{
    class Program
    {
        [STAThread]
        private static void Main()
        {
            User.Init().ToCsv(); //.//Wait();
        }

        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }


            public static List<User> Init()
            {
                var list = new List<User>()
                {
                    new User() { Age = 12, Name = "valodik"},
                    new User() { Age = 12, Name = "valodik"},
                    new User() { Age = 12, Name = "valodik"},
                    new User() { Age = 12, Name = "valodik"},
                    new User() { Age = 12, Name = "valodik"},
                    new User() { Age = 12, Name = "valodik"},

                };
                return list;
            }
        }
    }
}
