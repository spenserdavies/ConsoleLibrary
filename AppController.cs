using System;
using ConsoleLibrary.Models;
using System.Collections.Generic;


namespace ConsoleLibrary
{
    public class App
    {
        public Library Library { get; set; }

        public bool Running { get; private set; }
        public void Run()
        {
            Console.Clear();
            Library = new Library("Jakes Moms House", "JMNL");
            Console.WriteLine($"Welcome to {Library.Name}, located at {Library.Location}!");
            Running = true;
            while(Running)
            {
                
                Console.WriteLine("Would you like to BROWSE, ADD, CHECKIN, or QUIT?");
                Console.WriteLine("");
                string response = Console.ReadLine().ToLower();
                switch(response)
                {
                    case "browse":
                    case "b":
                    case "brow":
                    case "br":
                    case "1":
                        CheckOutBooks();
                        break;
                    case "add":
                    case "a":
                    case "2":
                        AddBook();
                        break;
                    case "checkin":
                    case "c":
                    case "3":
                        CheckInBook();
                        break;
                    case "quit":
                    case "q":
                    case "4":
                        Running=false;
                        Console.WriteLine("bye buddy, hope u find ur dad");
                        break;
                    default:
                        Console.WriteLine("Learn How To Type..Try Again");
                        break;
                }
            }

        }

        public void ViewBooks()
        {
            Console.Clear();
            Library.ViewBooks(false);
        }
        public void CheckOutBooks()
        {
            ViewBooks();
            Console.WriteLine("\nWhich Book Would You Like To Checkout?");
            Console.WriteLine("");
            string selection = Console.ReadLine();
            Book selectedBook = Library.checkBookAvailability(selection);
            if(selectedBook == null || selectedBook.Available == false)
            {
                Console.WriteLine("Invalid Selection");
                return;
            }
            Console.WriteLine($"\nYou Would Like To Check-out '{selectedBook.Title}'? ( Y / N )");
            char confirmation = Console.ReadKey().KeyChar;
            Console.Clear();
            Console.WriteLine($"\nThank you For Checking Out {selectedBook.Title}!");
            selectedBook.Available = false;
            return;
        }
        public void AddBook()
        {
            Console.Clear();
            Console.Write("Please Enter The Title Of The Book You'd Like To Add:  ");
            string newTitle = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Please Enter The Author Of The Book:  ");
            string newAuthor = Console.ReadLine();
            Console.WriteLine($"\nAdd '{newTitle}' by {newAuthor}? ( Y / N )");
            char confirmation = Console.ReadKey().KeyChar;
            switch(confirmation)
            {
                case 'y':
                    Console.Clear();
                    Library.Books.Add(new Book($"{newTitle}", $"{newAuthor}"));
                    Console.WriteLine($"\nThank you for adding '{newTitle}' by {newAuthor} to The Library!");
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 'n':
                    return;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public void CheckInBook()
        {
            Console.Clear();
            Library.ViewCheckedOut();
            string selection = Console.ReadLine();
            Book selectedBook = Library.checkBookAvailability(selection);
            if(selectedBook == null)
            {
                Console.WriteLine("\nInvalid Selection!");
                return;
            }
            Console.WriteLine("Would You Like To Return:");
            Console.WriteLine($"'{selectedBook.Title}' by {selectedBook.Author}? ( Y / N )");
            Console.WriteLine("");
            char confirmation = Console.ReadKey().KeyChar;
            switch(confirmation)
            {
                case 'y':
                    selectedBook.Available = true;
                    Console.Clear();
                    Console.WriteLine("Thank you for safely returning our book!");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 'n':
                    return;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
                
        }
    }
}