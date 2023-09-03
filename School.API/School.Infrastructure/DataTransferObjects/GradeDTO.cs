using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.DataTransferObjects
{
    public record class GradeDTO
    {
        [Required]
        public string Assigment { get; set; }

        [Required]
        public double GradeValue { get; set; }
    }
}
