using System.ComponentModel.DataAnnotations;

namespace School.Infrastructure.DataTransferObjects
{
    public record StudentDTO
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

        public List<GradeDTO> Grades { get; set; }
    }
}
