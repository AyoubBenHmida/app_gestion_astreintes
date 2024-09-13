namespace gestion_astreintes.Dtos
{
    public class AstreinteForCreationDto
    {
        public string Name { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }

    }
}
