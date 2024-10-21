using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeave.Application.Leaves.Dtos
{
    public class LeaveAddRequest
    {

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string? SubmittedTo { get; set; }
        public string? LeaveType { get; set; }
    }
}
