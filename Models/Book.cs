namespace ConsoleLibrary.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            Available = true;
        }
    }
}