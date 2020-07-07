using System.Collections.Generic;
using System;

namespace ConsoleLibrary.Models
{
    public class Library
    {
        public string Location { get; set; }
        public string Name { get; set; }
        private List<Book> Books { get; set; } = new List<Book>();
        
        public void PrintBooks()
        {
            for(int i = 0; i < Books.Count; i++)
            {
                var book = Books[i];
                Console.WriteLine($"{i+1}. {book.Title} by {book.Author}");
            }
        }
        
        
        
        
        public Library()
        {
            
        }
    }
}