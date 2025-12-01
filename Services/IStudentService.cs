using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> GetAllAsync();
        Task<StudentResponseDto?> GetByIdAsync(Guid id);
        Task<StudentResponseDto> AddAsync(string name, string surname);
        Task<StudentResponseDto?> UpdateAsync(Guid id, string? name, string? surname);
        Task<bool> DeleteAsync(Guid id);
    }
}
