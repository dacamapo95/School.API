using System.ComponentModel.DataAnnotations;

namespace School.Infrastructure.DataTransferObjects
{
    public record TeacherDTO
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
