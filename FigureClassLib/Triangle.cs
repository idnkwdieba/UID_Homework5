
namespace FigureClassLib;

using static System.Console;
public class Triangle : Figure
{
    private double _a, _b, _c; // стороны треугольника

    /// <summary>
    /// Конструктор экземпляра класса Triangle с четырьмя параметрами.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="a">Первая сторона треугольника.</param>
    /// <param name="b">Вторая сторона треугольника.</param>
    /// <param name="c">Третья сторона треугольника.</param>
    public Triangle(string name, double a, double b, double c) : base(name)
    {
        SetABC(a, b, c);
    }

    /// <summary>
    /// Свойство площади фигуры.
    /// </summary>
    public override double Area2
    {
        get
        {
            double p = 0.5*(_a + _b + _c);
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }
    }

    /// <summary>
    /// Метод для получения площади фигуры.
    /// </summary>
    /// <returns>Площадь фигуры.</returns>
    public override double Area()
    {
        return Area2;
    }
    public override void Print()
    {
        base.Print();
        Write($"; Стороны фигуры: a = {_a}, b = {_b}, c = {_c}; Площадь = {Area()}");
    }
    /// <summary>
    /// Задание сторон треугольника.
    /// </summary>
    /// <param name="a">Первая сторона треугольника.</param>
    /// <param name="b">Вторая сторона треугольника.</param>
    /// <param name="c">Третья сторона треугольника.</param>
    public void SetABC(double a, double b, double c)
    {
        _a = (a < 0 ? 0 : a);
        _b = (b < 0 ? 0 : b);
        _c = (c < 0 ? 0 : c);
    }
    /// <summary>
    /// Получение сторон треугольника.
    /// </summary>
    /// <param name="a">Первая сторона треугольника.</param>
    /// <param name="b">Вторая сторона треугольника.</param>
    /// <param name="c">Третья сторона треугольника.</param>
    public void GetABC(out double a, out double b, out double c)
    {
        a = _a;
        b = _b;
        c = _c;
    }
}
