namespace gestion_astreintes.Dtos
{
    public class AstreinteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Description { get; set; }
        public int StatutId { get; set; }
        public string StatutName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
