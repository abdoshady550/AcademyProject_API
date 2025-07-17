namespace Movie_Api.Services
{
    using AcademyProject_API.Model.Data;
    using AcademyProject_API.Model.Dtos;
    using AcademyProject_API.Model.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.OrderBy(e => e.FName).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            var item = await _context.Students.FindAsync(id);
            if (item == null)
                return null;

            return item;
        }

        public async Task<Student> Add(Student Student)
        {

            await _context.Students.AddAsync(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public Student Delete(Student Student)
        {

            _context.Students.Remove(Student);
            _context.SaveChanges();
            return Student;
        }

        public Student Update(Student Student)
        {
            _context.Update(Student);
            _context.SaveChanges();
            return Student;
        }
    }
}
