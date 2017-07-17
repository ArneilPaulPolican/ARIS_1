using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARIS_1.Entities
{
    public class Subject
    {
        public Int32 ID { get; set; }
        public string SubCode { get; set; }
        public string SubjectName { get; set; }
        public Int32? AmountPerUnit { get; set; }
    }
}