using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class RentModel
    {
        public int Id { get; set; }
        public string? rentCode { get; set; }
        public int? customerCodeId { get; set; }
        public virtual CustomerModel? customerCode { get; set; }
        public string? customerName { get; set; }
        public int? CodeId { get; set; }
        public virtual ProductModel? Code { get; set; }
        public string? prodCode2 { get; set; }
        public string? prodCode3 { get; set; }
        public string? prodCode4 { get; set; }
        public string? prodCode5 { get; set; }
        public string? Amount { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? dateEvent { get; set; }
        public DateTime? dateExped { get; set; }
        public DateTime? dateReturn { get; set; }
        public DateTime? dateCad { get; set; }
    }
}
