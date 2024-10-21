using MyLeave.Application.Leaves.Dtos;
using MyLeave.Domain.Leaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeave.Application.Leaves
{
    public interface ILeaveAppService
    {
        IEnumerable<LeaveResponse> GetAllLeaves();
        public LeaveResponse CreateLeave(LeaveAddRequest leaveAddRequest);
        public LeaveResponse UpdateLeave(LeaveUpdateRequest leaveUpdateRequest);
        public LeaveResponse GetLeaveById(Guid Id);
        public LeaveResponse DeleteLeave(Guid Id);

    }
}
