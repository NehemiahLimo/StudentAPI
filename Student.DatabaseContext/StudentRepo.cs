using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Services;

namespace Students.DatabaseContext
{
    public class StudentRepo : IStudent
    {
        private readonly StudentDbContext _db;

        public StudentRepo(StudentDbContext db)
        {
            _db = db;
        }
        public IQueryable<Student> GetStudents => _db.Students;

        public void Delete(int? Id)
        {
            Student student = _db.Students.Find(Id);
            _db.Students.Remove(student);
            _db.SaveChanges();

        }

        public Student GetStudent(int? Id)
        {
            Student student = _db.Students.Find(Id);
            return student;
        }

        public void Save(Student student)
        {
            if(student.Id == 0)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
            } 
            else if(student.Id != 0) 
            {
                Student student1 = _db.Students.Find(student.Id);
                student1.FirstName = student.FirstName;
                student1.LastName = student.LastName;
                student1.Gender = student.Gender;

                _db.SaveChanges();

            }
        }
    }
}
