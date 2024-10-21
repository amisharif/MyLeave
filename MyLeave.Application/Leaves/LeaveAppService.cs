using AutoMapper;
using MyLeave.Application.Leaves.Dtos;
using MyLeave.Domain.Leaves;
using MyLeave.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeave.Application.Leaves
{
    public class LeaveAppService : ILeaveAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public LeaveAppService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<LeaveResponse> GetAllLeaves()
        {
            IEnumerable<Leave> leaves = _context.Leaves.ToList();
            return _mapper.Map<List<LeaveResponse>>(leaves);
        }

        public LeaveResponse CreateLeave(LeaveAddRequest leaveAddRequest)
        {
            TimeSpan difference = leaveAddRequest.EndDate - leaveAddRequest.StartDate;


            Leave leave = _mapper.Map<Leave>(leaveAddRequest);

            leave.Status = "Pending";
            leave.StartDate = DateTime.SpecifyKind(leaveAddRequest.StartDate, DateTimeKind.Utc);
            leave.EndDate = DateTime.SpecifyKind(leaveAddRequest.EndDate, DateTimeKind.Utc);
            leave.TotalOffInDays =  difference.Days+1;

            _context.Add(leave);
            _context.SaveChanges();

            return _mapper.Map<LeaveResponse>(leave);

        
        }

     

        public LeaveResponse GetLeaveById(Guid Id)
        {
            Leave? leave = _context.Leaves.FirstOrDefault(lv => lv.Id == Id);
            return _mapper.Map<LeaveResponse>(leave);
        }

        public LeaveResponse UpdateLeave(LeaveUpdateRequest leaveUpdateRequest)
        {

            TimeSpan difference = leaveUpdateRequest.EndDate - leaveUpdateRequest.StartDate;

            Leave? leave = _context.Leaves.FirstOrDefault(lv =>lv.Id == leaveUpdateRequest.Id);
            if(leave!= null)
            {
                leave.StartDate = DateTime.SpecifyKind(leaveUpdateRequest.StartDate, DateTimeKind.Utc);
                leave.EndDate = DateTime.SpecifyKind(leaveUpdateRequest.EndDate, DateTimeKind.Utc);
                leave.SubmittedTo = leaveUpdateRequest.SubmittedTo;
                leave.LeaveType = leaveUpdateRequest.LeaveType;
                leave.TotalOffInDays = difference.Days + 1;

                _context.SaveChanges();
            }

            return _mapper.Map<LeaveResponse>(leave);
        }

        public LeaveResponse DeleteLeave(Guid Id)
        {
            Leave? leave = _context.Leaves.FirstOrDefault( lv => lv.Id == Id);
            if(leave!= null)
            {
                _context.Remove(leave);
                _context.SaveChanges();
            }

            return _mapper.Map<LeaveResponse>(leave);
        }
    }
}
