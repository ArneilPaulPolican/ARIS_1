using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ARIS_1.Entities;

namespace ARIS_1.API_Controller
{
    public class SubjectController : ApiController
    {
        private Data.ArisDBDataContext db = new Data.ArisDBDataContext();

        [HttpGet,Route("api/Subjects/List")]
        public List<Subject> listSubject()
        {
            var SubjectList = from d in db.MstSubjects
                              select new Subject
                              {
                                  ID = d.ID,
                                  SubCode=d.SubCode,
                                  SubjectName=d.Subject,
                                  AmountPerUnit=d.AmountPerUnit

                              };

            return SubjectList.ToList();
        }
    }
}
