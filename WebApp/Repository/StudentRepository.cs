using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public class StudentRepository
    {
        private static List<Student> Students { get; set; } = new List<Student>();

        public List<Student> GetStudents()
        {
            return Students;
        }

        public Student GetStudentById(Guid id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

        public void Save(Student student)
        {
            Students.Add(student);
        }

        public Student GetStudentByEmail(string email)
        {
            return Students.FirstOrDefault(s => s.Email == email);
        }

        public void Delete(Guid id)
        {
            var student = this.GetStudentById(id);
            if(student != null)
            {
                Students.Remove(student);
            }
        }
    }
}
