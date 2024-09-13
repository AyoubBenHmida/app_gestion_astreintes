using AutoMapper;
using gestion_astreintes.Dtos;
using gestion_astreintes.Models;

namespace gestion_astreintes.AutoMapper.Converters
{
    public class TeamMemberToEmpAstreintesDtoConverter : ITypeConverter<TeamMember, EmpAstreintesDto>
    {
        private readonly IMapper _mapper;
        public TeamMemberToEmpAstreintesDtoConverter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public EmpAstreintesDto Convert(TeamMember employee, EmpAstreintesDto empAstreintesDto, ResolutionContext context)
        {
            return new EmpAstreintesDto
            {
                EmployeeId = employee.Id,
                EmployeeName = employee.Name,
                astreintes = _mapper.Map<List<AstreinteForEmployeeDetailsDto>>(employee.astreintes.Where(t => t.Employee.Id == employee.Id))
            };
        }
    }
}
