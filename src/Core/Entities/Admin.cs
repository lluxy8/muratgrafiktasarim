namespace Core.Entities
{
    public class Admin
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
