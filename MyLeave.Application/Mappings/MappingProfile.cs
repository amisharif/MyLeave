using AutoMapper;
using MyLeave.Application.Leaves.Dtos;
using MyLeave.Domain.Leaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeave.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveAddRequest, Leave>().ReverseMap();
            CreateMap<Leave,LeaveResponse>().ReverseMap();
        }
    }
}
