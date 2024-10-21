using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLeave.Application.Leaves;
using MyLeave.Application.Leaves.Dtos;

namespace MyLeave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAPIController : ControllerBase
    {
        private readonly ILeaveAppService _leaveAppService;
        public LeaveAPIController(ILeaveAppService leaveAppService)
        {
            _leaveAppService = leaveAppService;
        }


        [HttpGet]
        public ActionResult GetAllLeaves()
        {
            IEnumerable<LeaveResponse>leaveResponses = _leaveAppService.GetAllLeaves();
            return Ok(leaveResponses);
        }

        [HttpPost]
        public ActionResult CreateLeave(LeaveAddRequest leaveAddRequest)
        {

            if (leaveAddRequest.StartDate.Date <= DateTime.UtcNow.Date || leaveAddRequest.StartDate>leaveAddRequest.EndDate)
            {
                return BadRequest();
            }

            LeaveResponse leaveResponse =  _leaveAppService.CreateLeave(leaveAddRequest);
            return Ok(leaveResponse);
        }



        [HttpPut("Id")]
        public ActionResult UpdateLeave(Guid Id, LeaveUpdateRequest leaveUpdateRequest)
        {
            if (leaveUpdateRequest.StartDate.Date <= DateTime.UtcNow.Date || leaveUpdateRequest.StartDate > leaveUpdateRequest.EndDate || Id != leaveUpdateRequest.Id)
            {
                return BadRequest();
            }


            LeaveResponse leaveResponse = _leaveAppService.GetLeaveById(Id);
            if (leaveResponse == null || leaveResponse.Status=="Accepted") return BadRequest();

            LeaveResponse response = _leaveAppService.UpdateLeave(leaveUpdateRequest);
            return Ok(response);
        }

        [HttpDelete("Id")]
        public ActionResult DeleteLeave(Guid Id)
        {
            LeaveResponse leaveResponse = _leaveAppService.GetLeaveById(Id);

            if (leaveResponse == null || leaveResponse.Status == "Accepted") return BadRequest();

            _leaveAppService.DeleteLeave(Id);
            return Ok();
        }




    }
}
