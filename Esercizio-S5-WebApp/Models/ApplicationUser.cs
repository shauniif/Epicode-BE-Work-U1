namespace Esercizio_S5_WebApp.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public List<string> Ruoli { get; set; } = [];
    }
}
