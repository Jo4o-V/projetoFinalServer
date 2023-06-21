using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class PartnerModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cnpj { get; set; }
        public string? Partnership { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dateCad { get; set; }
        public int? CityId { get; set; }
        public virtual CityModel? City { get; set; }
    }
}
