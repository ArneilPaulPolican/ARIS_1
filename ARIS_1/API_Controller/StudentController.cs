using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ARIS_1.Entities;
using System.Diagnostics;

namespace ARIS_1.API_Controller
{
    public class StudentController : ApiController
    {
        private Data.ArisDBDataContext db = new Data.ArisDBDataContext();
        //===============
        //List of Students
        //===============
        [HttpGet, Route("api/Student/list")]
        public List<Student> ListStudent()
        {
            var fatherList = from d in db.MstFathers
                             select d;

            var StudentList = from d in db.MstStudents
                              select new Entities.Student
                              {
                                  ID = d.ID,
                                  Fname = d.Fname,
                                  Mname = d.Mname,
                                  Lname = d.Lname,
                                  Age = d.Age,
                                  Gender = d.Gender,
                                  Religion = d.Religion,
                                  Citizinship = d.Citizinship,
                                  Bithdate = d.BirthDate,
                                  Birthplace = d.BirthPlace,
                                  Address = d.Address
                              };

            return StudentList.ToList();
        }
        //============
        //Get Student ID
        //============
        [HttpGet, Route("api/Student/list/{id}")]
        public List<Student> getStudent(string id)
        {
            var student = from d in db.MstStudents
                          where d.ID == Convert.ToInt32(id)
                          select new Entities.Student
                          {
                              ID = d.ID,
                              Fname = d.Fname,
                              Mname = d.Mname,
                              Lname = d.Lname,
                              Age = d.Age,
                              Gender = d.Gender,
                              Religion = d.Religion,
                              Citizinship = d.Citizinship,
                              Bithdate = d.BirthDate,
                              Birthplace = d.BirthPlace,
                              Address = d.Address
                          };
            return student.ToList();
        }

        //==================
        //Update Student Detail
        //==================
        [HttpPut]
        [ Route("api/Student/Update/{id}")]
        public HttpResponseMessage update(string id, Entities.Student item)
        {
            try
            {
                var StudentId = Convert.ToInt32(id);
                var StudID = from d in db.MstStudents where d.ID == StudentId select d;

                if (StudID.Any())
                {
                    var UpdateStud = StudID.FirstOrDefault();

                    UpdateStud.Fname = item.Fname;
                    UpdateStud.Mname = item.Mname;
                    UpdateStud.Lname = item.Lname;
                    UpdateStud.Age = item.Age;
                    UpdateStud.Gender = item.Gender;
                    UpdateStud.Religion = item.Religion;
                    UpdateStud.Citizinship = item.Citizinship;
                    UpdateStud.BirthDate = item.Bithdate;
                    UpdateStud.BirthPlace = item.Birthplace;
                    UpdateStud.Address = item.Address;

                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        //==============
        //Add Students
        //==============
        [HttpPost, Route("api/students/add")]
        public HttpResponseMessage postStudent(Entities.Student addStudent)
        {
            try
            {
                Data.MstStudent newStudent = new Data.MstStudent();
                newStudent.Fname = addStudent.Fname != null ? addStudent.Fname : "NA";
                newStudent.Mname = addStudent.Mname != null ? addStudent.Mname : "NA";
                newStudent.Lname = addStudent.Lname != null ? addStudent.Lname : "NA";
                newStudent.Age = addStudent.Age;
                newStudent.Gender = addStudent.Gender != null ? addStudent.Gender : " ";
                newStudent.Religion = addStudent.Religion != null ? addStudent.Religion : " ";
                newStudent.Citizinship = addStudent.Citizinship != null ? addStudent.Citizinship : " ";
                newStudent.BirthDate = addStudent.Bithdate;
                newStudent.BirthPlace = addStudent.Birthplace != null ? addStudent.Birthplace : "NA";
                newStudent.Address = addStudent.Address != null ? addStudent.Address : "NA";

                db.MstStudents.InsertOnSubmit(newStudent);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete, Route("api/Student/delete/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                var Student = from d in db.MstStudents where d.ID == Convert.ToInt32(id) select d;

                if (Student.Any())
                {
                    db.MstStudents.DeleteOnSubmit(Student.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
