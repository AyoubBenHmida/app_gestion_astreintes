using gestion_astreintes.Dtos;

namespace gestion_astreintes.Services.Interfaces
{
    public interface IAstreinteService
    {
        IEnumerable<AstreinteDto> GetAstreintes();
        AstreinteDto GetAstreinteByID(int AstreinteId);
        AstreinteDto AddAstreinte(AstreinteForCreationDto astreinteForCreDto);
        void EditAstreinte(AstreinteForEditDto astreinteForEdit);
        void UpdateStatus(AstreinteDto astreinteDto);
        void DeleteAstreinte(int astreinteId);
    }
}
