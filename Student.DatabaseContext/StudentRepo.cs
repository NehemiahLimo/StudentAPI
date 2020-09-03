using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Services;
using System.Threading.Tasks;

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

        public async Task<POJO> DeleteAsync(int? Id)
        {
            POJO model = new POJO();

            Student student = await GetStudent(Id);
            if(student != null)
            {
                try
                {
                    _db.Students.Remove(student);
                    await _db.SaveChangesAsync();
                    model.Flag = true;
                    model.Message = "Has been Created";

                }
                catch (Exception ex)
                {
                    model.Flag = false;
                    model.Message = ex.ToString();
                }

            }
            else
            {
                model.Flag = false;
                model.Message = "Student does not exist";
            }

            return model;

        }

        

        public async  Task<Student> GetStudent(int? Id)
        {
            Student student = _db.Students.Find(Id);
            if(Id != null)
            {
                student = await _db.Students.FindAsync(Id);
            }
            return student;
        }

        public async Task<POJO> Save(Student student)
        {
            POJO model = new POJO();
            if(student.Id == 0)
            {
                try
                {
                    await _db.AddAsync(student);
                    await _db.SaveChangesAsync();

                    model.Id = student.Id;
                    model.Flag = true;
                    model.Message = "Has been added";
                }
                catch(Exception ex)
                {
                    model.Flag = false;
                    model.Message = ex.ToString();
                }
               
            } 
            else if(student.Id != 0) 
            {
                Student student1 = await GetStudent(student.Id);
                student1.Id = student.Id;
                student1.FirstName = student.FirstName;
                student1.LastName = student.LastName;
                student1.Gender = student.Gender;
                try
                {
                    await _db.SaveChangesAsync();
                    model.Id = student.Id;
                    model.Flag = true;
                    model.Message = "Has been Updated";
                }
                catch(Exception ex)
                {
                    model.Flag = false;
                    model.Message = ex.ToString();
                }

                

            }
            return model;
        }

        
    }
}
