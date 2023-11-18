
namespace BookClassLib;

using static System.Console;
public class BookGenre:Book
{
    private string? _genre; // Жанр

    /// <summary>
    /// Конструктор класса BookGenre с параметрами.
    /// </summary>
    /// <param name="title">Название книги.</param>
    /// <param name="genre">Жанр книги.</param>
    /// <param name="author">Автор книги.</param>
    /// <param name="price">Цена книги.</param>
    public BookGenre(string title, string genre, string author, decimal price)
        :base(title, author, price)
    {
        Genre = genre;
    }

    /// <summary>
    /// Свойство жанра книги.
    /// </summary>
    public string? Genre
    {
        get
        {
            return _genre;
        }
        set
        {
            _genre = (value == null ? string.Empty : value);
        }
    }

    // Методы печати
    /// <summary>
    /// Печать данных об экземпляре класса BookGenre.
    /// </summary>
    public new void Print()
    {
        base.Print();
        Write($"; Жанр книги - {this.Genre}");
    }
    /// <summary>
    /// Статичкский метод печати данных об экземпляре класса BookGenre.
    /// </summary>
    /// <param name="bookGenre">Экземпляр класса BookGenre.</param>
    public static void Print(BookGenre bookGenre)
    {
        bookGenre.Print();
    }
}
