using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dateCad { get; set; }
        public int? StateId { get; set; }
        public virtual StateModel? State { get; set; }
    }
}
