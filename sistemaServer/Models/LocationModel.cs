using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? StockType { get; set; }
        public string? QtdTotal { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dateCad { get; set; }
    }
}
