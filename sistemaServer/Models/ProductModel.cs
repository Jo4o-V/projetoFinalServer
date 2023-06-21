using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Gender { get; set; }
        public string? Range { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Value { get; set; }
        public string? waistMeasure { get; set; }
        public string? barMeasure { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dateCad { get; set; }
        public int? TypeId { get; set; }
        public virtual CategoryModel? Type { get; set; }
    }
}
