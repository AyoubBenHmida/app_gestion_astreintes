using AutoMapper;
using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Repositories.Implementation;
using gestion_astreintes.Repositories.Interfaces;
using gestion_astreintes.Services.Interfaces;

namespace gestion_astreintes.Services.Implementation
{
    public class AstreinteService : IAstreinteService
    {
        private IAstreinteRepository _Repository;
        private ITeamMemberRepository _MemberRepository;
        private readonly IMapper _mapper;
        public AstreinteService(IAstreinteRepository repository, IMapper mapper, ITeamMemberRepository memberRepository)
        {
            this._Repository = repository;
            _mapper = mapper;
            _MemberRepository = memberRepository;
        }

        public IEnumerable<AstreinteDto> GetAstreintes()
        {
            List<Astreinte> astreintes = _Repository.GetAstreintes().ToList();
            return astreintes.Select(t => _mapper.Map<Astreinte, AstreinteDto>(t));
        }

        public AstreinteDto GetAstreinteByID(int AstreinteId)
        {
            Astreinte astreinte = _Repository.GetAstreinteByID(AstreinteId);
            if (astreinte == null)
            {
                throw new EntityNotFoundException($"Could not find Entity with id {AstreinteId}");
            }
            else
            {
                AstreinteDto astreinteDto = _mapper.Map<Astreinte, AstreinteDto>(astreinte);
                return astreinteDto;
            }
        }

        public AstreinteDto AddAstreinte(AstreinteForCreationDto astreinteForCreDto)
        {
            if ((_MemberRepository.GetTeamMemberByID(astreinteForCreDto.EmployeeId) == null)||
                (_MemberRepository.GetTeamMemberByID(astreinteForCreDto.EmployeeId).MemberType.Id != 2 ))
            {
                throw new EntityNotFoundException($"Could not find employee with id {astreinteForCreDto.EmployeeId} ");
            }
            if (_Repository.CheckIfAstreinteNameExists(astreinteForCreDto.Name))
            {
                throw new AstreinteExistsException("cette astreinte existe, tu ne peux pas l'ajouter");
            }
            if ((astreinteForCreDto.DateDebut > astreinteForCreDto.DateFin) || (astreinteForCreDto.DateFin > DateTime.Now) )
            {
                throw new NonValidDatesException("la date de début doit etre inférieure à la date de fin " +
                    "et la date de fin doit etre inférieure à la date actuelle");
            }
            Astreinte astreinte = _mapper.Map<AstreinteForCreationDto, Astreinte>(astreinteForCreDto);
            int id = _Repository.AddAstreinte(astreinte);
            AstreinteDto astreinteDto = _mapper.Map<Astreinte, AstreinteDto>(astreinte);
            astreinteDto.Id = id;
            return astreinteDto;
        }

        public void EditAstreinte(AstreinteForEditDto astreinteForEdit)
        {
            if (_Repository.GetAstreinteByID(astreinteForEdit.Id) != null)
            {
                Astreinte astreinte = _mapper.Map<AstreinteForEditDto, Astreinte>(astreinteForEdit);
                _Repository.EditAstreinte(astreinte);
            }
            else
            {
                throw new AstreinteIdExistsException("this astreinte don't exists");
            }
        }

        public void DeleteAstreinte(int AstreinteId)
        {
            if (_Repository.GetAstreinteByID(AstreinteId) != null)
            {
                _Repository.DeleteAstreinte(AstreinteId);
            }
            else
            {
                throw new AstreinteIdExistsException("this astreinte don't exists");
            }
        }

        public void UpdateStatus(AstreinteDto astreinteDto)
        {
            astreinteDto.StatutName = _Repository.GetStatusById(astreinteDto.StatutId).Name;
            Astreinte astreinte = _mapper.Map<AstreinteDto, Astreinte>(astreinteDto);
            _Repository.UpdateStatus(astreinte);
        }

    }
}
