namespace BookStore.Contracts.Commands
{
    public class CreateBookCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
