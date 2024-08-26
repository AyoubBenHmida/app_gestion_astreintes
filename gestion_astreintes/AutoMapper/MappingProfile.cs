using AutoMapper;
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

            CreateMap<Team, TeamDetailsDto>();

            CreateMap<TeamMember, TeamMemberForTeamDetailsDto>();

        }
    }
}
