using gestion_astreintes.Models;

namespace gestion_astreintes.Dtos
{
    public class EmpAstreintesDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public ICollection<AstreinteForEmployeeDetailsDto> astreintes { get; set; }
    }
}
