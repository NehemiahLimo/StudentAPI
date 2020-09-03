using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services
{
    public interface IStudent
    {
        Task<Student> GetStudent(int? Id);

        IQueryable<Student> GetStudents {get;}
         Task<POJO> Save(Student student);
        
        Task<POJO> DeleteAsync(int? Id);
    }
} 
