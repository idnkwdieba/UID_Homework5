
namespace StudentClassLib;

using static System.Console;
using PersonClassLib;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Reflection;

public class Student : Person
{
    private static Student[] STUDENTMASS = new Student[5]
    {
        new Student("Ященко Дмитрий", null, "Бакалавр", 18, 1),
        new Student("Макарова Анастасия", null, "Магистр", 23, 2),
        new Student("Маркелов Евгений", null, "Бакалавр", 20, 3),
        new Student("Коротченко Антон", null, "Аспирант", 24, 1),
        new Student("Керченко Ольга", null, "Бакалавр", 19, 2)
    };

    private enum AcademicDegrees
    {
        Бакалавр, Магистр, Аспирант
    }

    private int _year; // курс обучения
    AcademicDegrees _academicDegree; // академическая степень

    /// <summary>
    /// Констуктор класса Student с параметрами.
    /// </summary>
    /// <param name="name">Имя студента.</param>
    /// <param name="id">Идентификационный номер студента.</param>
    /// <param name="academicDegree">Академическая степень студента.</param>
    /// <param name="age">Возраст студента.</param>
    /// <param name="year">Курс студента.</param>
    public Student(string? name, string? id, string? academicDegree, int age, int year)
        : base(id, name, age)
    {
        AcademicDegree = academicDegree!;
        Year = year;
    }

    // Свойства
    /// <summary>
    /// Свойство курса студента.
    /// </summary>
    public int Year
    {
        get
        {
            return _year;
        }
        set
        {
            if (this.AcademicDegree == AcademicDegrees.Бакалавр.ToString())
            {
                _year = (value < 1 ? 1 : (value > 4 ? 4 : value));
            }
            if (this.AcademicDegree == AcademicDegrees.Магистр.ToString() 
                || this.AcademicDegree == AcademicDegrees.Аспирант.ToString())
            {
                _year = (value < 1 ? 1 : (value > 2 ? 2 : value));
            }
        }
    }
    /// <summary>
    /// Свойство академической степени студента.
    /// </summary>
    public string AcademicDegree
    {
        get
        {
            return _academicDegree.ToString();
        }
        set
        {
            if (value == null || !Enum.TryParse(value, out _academicDegree))
            {
                _academicDegree = 0;
            }
        }
    }

    // Методы
    /// <summary>
    /// Конвертация экземпляра класса Student в строку.
    /// </summary>
    /// <returns>Строку-представление данных экземпляра класса Student.</returns>
    public override string ToString()
    {
        return $"Студент-{AcademicDegree} {Year}-го курса; " + base.ToString();
    }
    /// <summary>
    /// Печать данных об экземпляре класса Student.
    /// </summary>
    public override void Print()
    {
        Print(this);
    }
    /// <summary>
    /// Печать данных об экземпляре класса Student.
    /// </summary>
    /// <param name="student">Экземпляр класса Student для вывода данных.</param>
    public void Print(Student student)
    {
        Write(student.ToString());
    }
    /// <summary>
    /// Проверка равенства экземпляра класса Student и некоего другого объекта.
    /// </summary>
    /// <param name="obj">Экземпляр объекта для сравнения.</param>
    /// <returns>True, если экземпляры объектов совпадают;<br/>
    /// False, в противном случае.</returns>
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Student)
        {
            if (((Student)obj).Id == this.Id && ((Student)obj).Name == this.Name
                && ((Student)obj).Age == this.Age && ((Student)obj).AcademicDegree == this.AcademicDegree)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Получить хэш-код экземпляра класса Student.
    /// </summary>
    /// <returns>32-битное числовое представление хэш-кода.</returns>
    public override int GetHashCode()
    {
        int hashcode = Name.GetHashCode();
        hashcode = 31 * hashcode + Age.GetHashCode();
        hashcode = 31 * hashcode + Id.GetHashCode();
        hashcode = 31 * hashcode + AcademicDegree.GetHashCode();
        hashcode = 31 * hashcode + Year.GetHashCode();
        return hashcode;
    }
    /// <summary>
    /// Получить случайный экземпляр класса Student из статического массива.
    /// </summary>
    /// <returns>Случайный экземпляр класса Student из статического массива.</returns>
    public static Student RandomStudent()
    {
        Random rand = new Random();
        return STUDENTMASS[rand.Next(0, 5)];
    }
    /// <summary>
    /// Вывести "семейное древо" класса Student.
    /// </summary>
    /// <returns>Строку, содержающую имя класса Student и всех 
    /// прешествующих ему родительских классов.</returns>
    public static string FamilyTree()
    {
        List<Type> types = new();
        Type tmpType = typeof(Student);
        string tmpStr = string.Empty;
        types.Add(tmpType);

        while (tmpType.BaseType != null)
        {
            tmpType = tmpType.BaseType;
            types.Add(tmpType);
        }

        foreach(Type type in types) 
        {
            tmpStr += type.Name + "\n";
        }
        return tmpStr;
    }
    /// <summary>
    /// Клонировать экземпляр класса Student.
    /// </summary>
    /// <returns>Копию экземпляра класса Student.</returns>
    public override Person Clone()
    {
        return new Student(this.Name, this.Id, this.AcademicDegree, this.Age, this.Year);
    }
}