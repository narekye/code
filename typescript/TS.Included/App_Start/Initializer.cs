using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.Included.Models;

namespace TS.Included.App_Start
{
    public class Initializer
    {
        public static List<User> Init()
        {
            return new List<User>()
            {
                new User
                    { Id = 1,Age = 18,Name = "Alice"},
                new User
                    { Id=2,Age = 45, Name = "Bob"}
            };
        }
    }
}