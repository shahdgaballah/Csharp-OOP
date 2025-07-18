namespace OnlineBookReader
{
    public class Book
    {
        public const int MAX_BOOKS = 100;
        public static Book[] books = new Book[MAX_BOOKS];
        public static int books_count = 0;
        public string? Title { get; set; }
    
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author}\n";
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            
        }
    }
}
