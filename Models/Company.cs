namespace ELETRICTEL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Razao { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string StreetCep { get; set; }
        public string StreetState { get; set; }
        public string StreetCity { get; set; }
        public UserClients UserClients { get; set; }
        public int? UserClientsId { get; set; }
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }

    }
}
