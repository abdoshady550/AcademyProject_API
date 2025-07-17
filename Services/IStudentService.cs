using AcademyProject_API.Model.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Movie_Api.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task<Student> GetById(int id);
        public Task<Student> Add(Student Student);
        public Student Update(Student Student);
        public Student Delete(Student Student);
    }
}
