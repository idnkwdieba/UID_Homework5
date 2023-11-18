
namespace BookClassLib;

using static System.Console;
public sealed class BookGenrePubl : BookGenre
{
    private string? _publisher; // издатель

    /// <summary>
    /// Конструктор класса BookGenrePubl с параметрами.
    /// </summary>
    /// <param name="title">Название книги.</param>
    /// <param name="genre">Жанр книги.</param>
    /// <param name="author">Автор книги.</param>
    /// <param name="publisher">Издатель книги.</param>
    /// <param name="price">Цена книги.</param>
    public BookGenrePubl(string title, string genre, string author, string publisher, decimal price)
        : base(title, genre, author, price)
    {
        Publisher = publisher;
    }

    /// <summary>
    /// Свойство издателя книги.
    /// </summary>
    public string? Publisher
    {
        get
        {
            return _publisher;
        }
        set
        {
            _publisher = (value == null ? string.Empty : value);
        }
    }

    // Методы печати
    /// <summary>
    /// Печать данных об экземпляре класса BookGenrePubl.
    /// </summary>
    public new void Print()
    {
        base.Print();
        Write($"; Издательство - {Publisher}");
    }
    /// <summary>
    /// Статичкский метод печати данных об экземпляре класса BookGenrePubl.
    /// </summary>
    /// <param name="bookGenrePubl">Экземпляр класса BookGenrePubl.</param>
    public static void Print(BookGenrePubl bookGenrePubl)
    {
        bookGenrePubl.Print();
    }
}
