using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class StateModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Acronym { get; set; }
        public string? Description { get; set; }
        public DateTime? dateCad { get; set; }
        public string? Status { get; set; }
        public int? CountryId { get; set; }
        public virtual CountryModel? Country { get; set; }
    }
}
