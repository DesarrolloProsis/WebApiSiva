namespace WebApiSiva.Models
{
    public class User
    {
        public string Id { get; set; }
        public string NumeroCliente {get; set;} 
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}