namespace PersonClassLib;

using System;
using System.ComponentModel;
using static System.Console;

public class Person
{
    // Константы
    private static int DEFID = 0;
    private static int IDLEN = 6;
    private static Person[] PERSONMASS = new Person[5]
    {
        new Person(null,"Иванов Иван",22),
        new Person(null, "Смирнов Антон", 21),
        new Person(null,"Сметанина Екатерина",21),
        new Person(null, "Конопацкий Сергей", 23),
        new Person(null,"Матросова Ольга",20)
    };

    // Поля
    private string _name; // имя человека
    private int _age; // возраст человека
    private string _id; // идентификационный номер человека

    public event EventHandler? Disposed;

    /// <summary>
    /// Констуктор класса Person с параметрами.
    /// </summary>
    /// <param name="id">Идентификационный номер человека.</param>
    /// <param name="name">Имя человека.</param>
    /// <param name="age">Возраст человека.</param>
    public Person(string? id, string? name, int age)
    {
        Id = id!;
        Name = name!;
        Age = age;
    }

    // Свойства
    /// <summary>
    /// Свойство имени человека.
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = (value == null ? "Неизвестен" : value);
        }
    }
    /// <summary>
    /// Свойство идентификационного номера человека.
    /// </summary>
    public string Id
    {
        get
        {
            return _id;
        }
        set
        {
            if (value != null && value.Length == IDLEN+1 && !char.IsDigit(value[0])) 
            {
                int ctr = 0;
                for (int i = 1; i < IDLEN + 1; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        ctr++;
                    }
                }
                if (ctr == IDLEN)
                {
                    _id = value;
                    return;
                }
            }
            _id = "U" + DEFID.ToString().PadLeft(IDLEN,'0');
            DEFID++;
        }
    }
    /// <summary>
    /// Свойство возраста человека.
    /// </summary>
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = (value < 0 ? 0 : value);
        }
    }

    // Методы
    /// <summary>
    /// Конвертация экземпляра класса Person в строку.
    /// </summary>
    /// <returns>Строку-представление данных экземпляра класса Person.</returns>
    public override string ToString()
    {
        return $"{Name}, {Age} лет, id: {Id}";
    }
    /// <summary>
    /// Печать данных об экземпляре класса Person.
    /// </summary>
    public virtual void Print()
    {
        Print(this);
    }
    /// <summary>
    /// Печать данных об экземпляре класса Person.
    /// </summary>
    /// <param name="person">Экземпляр класса Person для вывода данных.</param>
    public static void Print(Person person)
    {
        Write(person.ToString());
    }
    /// <summary>
    /// Проверка равенства экземпляра класса Person и некоего другого объекта.
    /// </summary>
    /// <param name="obj">Экземпляр объекта для сравнения.</param>
    /// <returns>True, если экземпляры объектов совпадают;<br/>
    /// False, в противном случае.</returns>
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Person)
        {
            if (((Person)obj).Id == this.Id && ((Person)obj).Name == this.Name
                && ((Person)obj).Age == this.Age)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Получить хэш-код экземпляра класса Person.
    /// </summary>
    /// <returns>32-битное числовое представление хэш-кода.</returns>
    public override int GetHashCode()
    {
        int hashcode = Name.GetHashCode();
        hashcode = 31 * hashcode + Age.GetHashCode();
        hashcode = 31 * hashcode + Id.GetHashCode();
        return hashcode;
    }
    /// <summary>
    /// Получить случайный экземпляр класса Person из статического массива.
    /// </summary>
    /// <returns>Случайный экземпляр класса Person из статического массива.</returns>
    public static Person RandomPerson()
    {
        Random rand = new Random();
        return PERSONMASS[rand.Next(0, 5)];
    }
    /// <summary>
    /// Клонировать экземпляр класса Person.
    /// </summary>
    /// <returns>Копию экземпляра класса Person.</returns>
    public virtual Person Clone()
    {
        return new Person(this.Id, this.Name, this.Age);
    }
}