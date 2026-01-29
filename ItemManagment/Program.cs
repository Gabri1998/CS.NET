namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cat = new Pet();
            cat.start();
            var music = new Album();
            music.start();
            var ticket = new TicketSeller();
            ticket.start();
        }
    }
}