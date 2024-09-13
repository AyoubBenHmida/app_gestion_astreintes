using gestion_astreintes.Models;

namespace gestion_astreintes.Dtos
{
    public class AstreinteForEditStatusDto
    {
        public string Name { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Description { get; set; }
        public int StatutId { get; set; }
    }
}
