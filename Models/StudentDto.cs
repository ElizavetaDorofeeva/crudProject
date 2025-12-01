using System.ComponentModel.DataAnnotations;
namespace StudentsApi.Models
{
    public class StudentDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;
    }
}
