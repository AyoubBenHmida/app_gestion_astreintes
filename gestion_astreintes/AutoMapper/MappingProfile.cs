using AutoMapper;
using gestion_astreintes.AutoMapper.Converters;
using gestion_astreintes.Dtos;
using gestion_astreintes.Models;

namespace gestion_astreintes.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<TeamForCreationDto, TeamDto>();
            CreateMap<TeamForCreationDto, Team>();

            CreateMap<TeamMember, TeamMemberDto>()
            .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Team.Id))
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
            .ForMember(dest => dest.MemberTypeId, opt => opt.MapFrom(src => src.MemberType.Id))
            .ForMember(dest => dest.MemberTypeName, opt => opt.MapFrom(src => src.MemberType.Name));


            CreateMap<TeamMemberForEditDto, TeamMember>()
            .ForMember(dest => dest.MemberType,
                       opt => opt.MapFrom(src => new TeamMemberType { Id = src.MemberTypeId }))
            .ForMember(dest => dest.Team,
                       opt => opt.MapFrom(src => new Team { Id = src.TeamId }));

            CreateMap<TeamMemberForCreationDto, TeamMember>()
            .ForMember(dest => dest.MemberType,
               opt => opt.MapFrom(src => new TeamMemberType { Id = src.MemberTypeId }))
            .ForMember(dest => dest.Team,
               opt => opt.MapFrom(src => new Team { Id = src.teamId }));

            CreateMap<Team, TeamDetailsDto>()
                .ConvertUsing<TeamToTeamDetailsDtoConverter>();

            CreateMap<TeamMember, TeamMemberForTeamDetailsDto>();

            CreateMap<Astreinte, AstreinteDto>();

            CreateMap<AstreinteDto, Astreinte>()
            .ForMember(dest => dest.Statut,
               opt => opt.MapFrom(src => new StatutAstreinte { Id = src.StatutId , Name = src.StatutName }));

            CreateMap<AstreinteForCreationDto, Astreinte>()
            .ForMember(dest => dest.Employee,
               opt => opt.MapFrom(src => new TeamMember { Id = src.EmployeeId }));


            CreateMap<AstreinteForEditDto, Astreinte>();

            CreateMap<TeamMember, EmpAstreintesDto>()
                .ConvertUsing<TeamMemberToEmpAstreintesDtoConverter>();

            CreateMap<Astreinte, AstreinteForEmployeeDetailsDto>()
                .ForMember(dest => dest.StatutId ,
                    opt => opt.MapFrom(src => src.Statut.Id)
                );

        }
    }
}
