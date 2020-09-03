using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Students.Services
{
    public interface IStudent
    {
        Student GetStudent(int? Id);

        IQueryable<Student> GetStudents {get;}
        void Save(Student student);
        void Delete(int? Id);
    }
} 
