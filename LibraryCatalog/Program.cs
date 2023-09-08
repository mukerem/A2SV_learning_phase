using System;
using System.Collections.Generic;

public class Book
{
    public string Title, Author, ISBN;
    public int PublicationYear;
    public Book(string title, string author, string isbn, int publication_year)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publication_year;
    }
}

public class MediaItem
{
    public string Title, MediaType;
    public int Duration;

    public MediaItem(string title, string media_type, int duration)
    {
        Title = title;
        MediaType = media_type;
        Duration = duration;
    }
}

public class Library
{
    string Name, Address;
    List<Book> Books;
    List<MediaItem> MediaItems;

    public Library(string name, string address)
    {
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }
    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine($"Library Name: {Name}");
        Console.WriteLine($"Library Address: {Address}");
        Console.WriteLine();
        foreach (Book book in Books)
        {
            Console.WriteLine(
                $"Book Title: {book.Title}    Book Author: {book.Author}  Book ISBN: {book.ISBN}   Book PublicationYear: {book.PublicationYear}"
            );
        }
        Console.WriteLine();
        foreach (MediaItem item in MediaItems)
        {
            Console.WriteLine($"Item Title: {item.Title}    Media Type: {item.MediaType}  Item Duration: {item.Duration}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Library Name");
        string library_name = Console.ReadLine();

        Console.WriteLine("Enter Library Address");
        string library_address = Console.ReadLine();

        Library library = new Library(library_name, library_address);

        Console.WriteLine("Enter the number of books");
        int books_count = Convert.ToInt32(Console.ReadLine());

        string title, author, isbn;
        int publication_year;

        for (int i = 0; i < books_count; i++)
        {
            Console.WriteLine($"Enter the title of book {i + 1}");
            title = Console.ReadLine();

            Console.WriteLine($"Enter the author of {title}");
            author = Console.ReadLine();

            Console.WriteLine($"Enter the ISBN of {title}");
            isbn = Console.ReadLine();

            do
            {
            Console.WriteLine($"Enter the publication year of {title}");
            publication_year = Convert.ToInt32(Console.ReadLine());
            } while(publication_year > 2023);

            // create Book instance
            Book book = new Book(title, author, isbn, publication_year);
            library.AddBook(book);    
        }

        Console.WriteLine("Enter the number of media item");
        int items_count = Convert.ToInt32(Console.ReadLine());

        string media_type;
        int duration;

        for (int i = 0; i < items_count; i++)
        {
            Console.WriteLine($"Enter the title of item {i + 1}");
            title = Console.ReadLine();

            Console.WriteLine($"Enter the media type of {title}");
            media_type = Console.ReadLine();

            do
            {
            Console.WriteLine($"Enter the duration of {title}");
            duration = Convert.ToInt32(Console.ReadLine());
            } while(duration < 0);

            // create MediaItem instance
            MediaItem item = new MediaItem(title, media_type, duration);
            library.AddMediaItem(item);    
        }

        library.PrintCatalog();
    }
}