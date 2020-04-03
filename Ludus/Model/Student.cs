using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;


namespace Ludus_web.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int KNumber { get; set; }
        public int Cpr { get; set; }
        public string Grade { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}  