namespace BookClassLib;

using static System.Console;

public class Book
{
    private string? _title; // название
    private string? _author; // автор
    private decimal _price; // цена

    /// <summary>
    /// Конструктор класса Book с параметрами.
    /// </summary>
    /// <param name="title">Название книги.</param>
    /// <param name="author">Автор книги.</param>
    /// <param name="price">Цена книги.</param>
    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    // Свойства
    /// <summary>
    /// Свойство названия книги.
    /// </summary>
    public string? Title 
    {
        get
        {
            return _title;
        }
        set
        {
            _title = (value == null) ? string.Empty : value;
        }
    }
    /// <summary>
    /// Свойство автора книги.
    /// </summary>
    public string? Author
    {
        get
        {
            return _author;
        }
        set
        {
            _author = (value == null) ? string.Empty : value;
        }
    }
    /// <summary>
    /// Свойство стоимости книги.
    /// </summary>
    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            _price = (value < 0) ? 0 : value;
        }
    }

    // Методы печати
    /// <summary>
    /// Печать данных об экземпляре класса Book.
    /// </summary>
    public void Print()
    {
        Print(this);
    }
    /// <summary>
    /// Статичкский метод печати данных об экземпляре класса Book.
    /// </summary>
    /// <param name="book">Экземпляр класса Book.</param>
    public static void Print(Book book)
    {
        Write($"Книга \"{book.Title}\"; Автор {book.Author}; Стоимость {book.Price:C}");
    }
}