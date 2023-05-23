namespace ABC.Models
{
    public class A
    {
        public int Id { get; set; }

        public string? One { get; set; }

        public string? Two { get; set; }

        public string? Three { get; set; }

        // _______________________________________

        public IEnumerable<C>? C { get; set; }
    }
}
