using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeave.Domain.Leaves
{
    public class Leave
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string? SubmittedTo { get; set; }
        public string?  LeaveType { get; set; }
        public int TotalOffInDays { get; set; }
        public string? Status { get; set; }

    }
}
