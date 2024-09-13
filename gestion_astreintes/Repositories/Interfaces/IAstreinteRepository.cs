using gestion_astreintes.Models;

namespace gestion_astreintes.Repositories.Interfaces
{
    public interface IAstreinteRepository
    {
        IEnumerable<Astreinte> GetAstreintes();
        Astreinte GetAstreinteByID(int AstreinteId);
        int AddAstreinte(Astreinte astreinte);
        void EditAstreinte(Astreinte astreinte);
        void DeleteAstreinte(int AstreinteId);
        void UpdateStatus(Astreinte astreinte);
        bool CheckIfAstreinteNameExists(string AstreinteName);
        StatutAstreinte GetStatusById(int AstreinteId);
        
    }
}
