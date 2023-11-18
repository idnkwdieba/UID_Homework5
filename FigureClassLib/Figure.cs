namespace FigureClassLib;

using static System.Console;
public abstract class Figure
{
    private string? _name; // название фигуры

    /// <summary>
    /// Конструктор экземпляра класса Figure с параметром.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    public Figure(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Свойство названия фигуры.
    /// </summary>
    public string? Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = (value == null? string.Empty : value);
        }
    }
    /// <summary>
    /// Свойство площади фигуры.
    /// </summary>
    public abstract double Area2 { get;}

    /// <summary>
    /// Метод для получения площади фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    public abstract double Area();
    /// <summary>
    /// Печать данных о фигуре.
    /// </summary>
    public virtual void Print()
    {
        Write($"Название фигуры - {Name}");
    }
}