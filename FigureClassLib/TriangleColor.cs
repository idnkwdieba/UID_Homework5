
namespace FigureClassLib;

using static System.Console;
public class TriangleColor : Triangle
{
    private string? _color; // цвет фигуры

    /// <summary>
    /// Конструктор экземпляра класса Triangle с пятью параметрами.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="color">Цвет фигуры.</param>
    /// <param name="a">Первая сторона треугольника.</param>
    /// <param name="b">Вторая сторона треугольника.</param>
    /// <param name="c">Третья сторона треугольника.</param>
    public TriangleColor(string name, string color, double a, double b, double c)
        : base(name,a,b,c)
    {
        Color = color;
    }

    /// <summary>
    /// Свойство цвета фигуры.
    /// </summary>
    public string? Color
    {
        get => _color;
        set => _color = (value == null ? string.Empty : value);
    }
    /// <summary>
    /// Свойство площади фигуры.
    /// </summary>
    public override double Area2 => base.Area2;

    /// <summary>
    /// Метод для получения площади фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    public override double Area() => base.Area();
    public override void Print()
    {
        base.Print();
        Write($"; Цвет фигуры - {Color}");
    }
}
