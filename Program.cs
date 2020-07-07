using System;
using ConsoleLibrary.Models;

namespace ConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Book whereTheSidewalkEnds = new Book("Where The Sidewalk Ends", "Shel Silverstein");
            Console.WriteLine(whereTheSidewalkEnds.Title);
            Library.PrintBooks();
        }
    }
}
