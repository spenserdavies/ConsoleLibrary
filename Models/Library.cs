using System.Collections.Generic;
using System;

namespace ConsoleLibrary.Models
{
    public class Library
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        
        public void ViewBooks(bool available)
        {
            ConsoleColor foreColor = Console.ForegroundColor;
            Console.Clear();
            Console.WriteLine(" ----------------------------------------------------------------------------");
            Console.WriteLine("|     B O O K S    A V A I L A B L E    I N    T H I S     L I B R A R Y     |");
            Console.WriteLine(" ----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n             RED INDICATES THAT THE BOOK HAS BEEN CHECKED OUT");
            Console.WriteLine("");
            Console.ForegroundColor = foreColor;

            for(int i = 0; i < Books.Count; i++)
            {
                var book = Books[i];
                if(book.Available == available)
                {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i+1}.  {book.Title} by {book.Author}");
                    Console.ForegroundColor = foreColor;
                }
                else
                {
                    Console.WriteLine($"{i+1}.  {book.Title} by {book.Author}");
                }
            }
        }
        public void ViewCheckedOut()
        {
            Console.Clear();
            Console.WriteLine(" ----------------------------------------------------------------------------");
            Console.WriteLine("|         W H I C H    B O O K    W I L L    Y O U    R E T U R N ?          |");
            Console.WriteLine(" ----------------------------------------------------------------------------");
            Console.WriteLine("");

            for(int i = 0; i < Books.Count; i++)
            {
                var book = Books[i];
                if(book.Available == false)
                {
                    Console.WriteLine($"{i+1}.  {book.Title} by {book.Author}");
                }
            }
        }
        
        
        
        
        public Library(string location, string name)
        {
            Location = location;
            Name = name;
            Books.Add(new Book("Teh Bibul", "Jeebus"));
            Books.Add(new Book("Who Touched Me Thermostat?", "Mr. Krabbs"));
            Books.Add(new Book("The Hobbit", "J.R.R. Tolkien"));
            Books.Add(new Book("The Cat In The Sombrero", "Senior Suess"));

        }

        internal Book checkBookAvailability(string selection)
        {
            int index;
            bool valid = Int32.TryParse(selection, out index);
            if(!valid || index < 1 || index > Books.Count)
            {
                return null;
            }
            return Books[index - 1];
        }
    }
}