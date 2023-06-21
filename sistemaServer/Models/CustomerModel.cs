using sistemaServer.Enums;

namespace sistemaServer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string? customerCode { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Cpf { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dateCad { get; set; }
        public string? City { get; set; }
        //public virtual CityModel? City { get; set; }
    }
}
