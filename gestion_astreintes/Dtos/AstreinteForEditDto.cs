namespace gestion_astreintes.Dtos
{
    public class AstreinteForEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Description { get; set; }
    }
}
