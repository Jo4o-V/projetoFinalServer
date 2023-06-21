using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dateCad { get; set; }
    }
}
