namespace BookStore.Contracts.Commands
{
    public class UpdateBookCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
