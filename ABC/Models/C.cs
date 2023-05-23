namespace ABC.Models
{
    public class C
    {
        public int Id { get; set; }

        public int AId { get; set; }

        public int BId { get; set; }

        // _______________________________________

        public A? A { get; set; }
        public B? B { get; set; }
    }
}
