using Microsoft.EntityFrameworkCore;
using StudentsApi.Data;
using StudentsApi.Models;

namespace StudentsApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentsContext _context;

        public StudentService(StudentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Surname = s.Surname
                })
                .ToListAsync();
        }

        public async Task<StudentResponseDto?> GetByIdAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname
            };
        }

        public async Task<StudentResponseDto> AddAsync(string name, string surname)
        {
            var student = new Student
            {
                Name = name,
                Surname = surname
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname
            };
        }

        public async Task<StudentResponseDto?> UpdateAsync(Guid id, string? name, string? surname)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            if (name != null) student.Name = name;
            if (surname != null) student.Surname = surname;

            await _context.SaveChangesAsync();

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
