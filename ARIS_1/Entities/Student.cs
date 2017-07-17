using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARIS_1.Entities
{
    public class Father
    {
        public Int32 Id { get; set; }
        public String Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
    }

    public class Student
    {
        public Int32 ID { get; set; }
        public String Fname { get; set; }
        public String Mname { get; set; }
        public String Lname { get; set; }
        public Int32? Age { get; set; }
        public String Gender { get; set; }
        public String Religion { get; set; }
        public String Citizinship { get; set; }
        public DateTime? Bithdate { get; set; }
        public String Birthplace { get; set; }
        public String Address { get; set; }
        public List<Father> ListFather { get; set; }
    }
}