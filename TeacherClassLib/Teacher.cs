
namespace TeacherClassLib;

using PersonClassLib;
using StudentClassLib;
using System.ComponentModel;
using static System.Console;

public class Teacher : Person
{
    private static Teacher[] TEACHERMASS = new Teacher[5]
{
        new Teacher("Ященко Дмитрий", null, "Кандидат_наук", "Старший_преподаватель", 27),
        new Teacher("Макарова Анастасия", null, "Доктор_наук", "Доцент", 33),
        new Teacher("Маркелов Евгений", null, "Кандидат_наук", "Старший_преподаватель", 35),
        new Teacher("Коротченко Антон", null, "Кандидат_наук", "Зав_Кафедрой", 42),
        new Teacher("Керченко Ольга", null, "Доктор_наук", "Профессор", 29)
};

    private enum ScientificDegrees
    {
        Кандидат_наук, Доктор_наук
    }
    private enum Occupations
    {
        Старший_преподаватель, Доцент, Профессор, Зав_Кафедрой
    }

    private ScientificDegrees _scientificDegree; // ученая степень
    private Occupations _occupation; // должность
    private List<Student>? _studentsList; // список студентов преподавателя

    /// <summary>
    /// Констуктор класса Teacher с параметрами.
    /// </summary>
    /// <param name="name">Имя преподавателя.</param>
    /// <param name="id">Идентификационный номер преподавателя.</param>
    /// <param name="scientificDegree">Ученая степень преподавателя.</param>
    /// <param name="occupation">Должность преподавателя.</param>
    /// <param name="age">Возраст преподавателя.</param>
    public Teacher(string? name, string? id, string? scientificDegree,
        string? occupation, int age, params Person[] students)
        : base(id, name, age)
    {
        ScientificDegree = scientificDegree!;
        Occupation = occupation!;
        _studentsList = new();
        if (students != null)
        {
            foreach (var student in students)
            {
                this.AddStudents(student);
            }
        }
    }

    // Свойства
    public Person? this[int index]
    {
        get
        {
            if (_studentsList == null || _studentsList.Count == 0
                || index < _studentsList.Count || _studentsList.Count <= index)
            {
                return null;
            }
            return _studentsList[index];
        }
        set
        {
            if (value == null || _studentsList == null || index < _studentsList.Count 
                || _studentsList.Count < index || !(value is Student))
            {
                return;
            }
            if (_studentsList.Count == index)
            {
                this.AddStudents(value);
            }
            _studentsList[index] = value as Student;
        }
    }
    /// <summary>
    /// Свойство ученой степени преподавателя.
    /// </summary>
    public string ScientificDegree
    {
        get
        {
            string tmp = _scientificDegree.ToString();
            tmp = tmp.Replace('_', ' ');
            return tmp;
        }
        set
        {
            if (value == null || !Enum.TryParse(value.Replace(' ', '_'), out _scientificDegree))
            {
                _scientificDegree = 0;
            }
        }
    }
    /// <summary>
    /// Свойство должности преподавателя.
    /// </summary>
    public string Occupation
    {
        get
        {
            string tmp = _occupation.ToString();
            tmp = tmp.Replace('_', ' ');
            return tmp;
        }
        set
        {
            if (value == null || !Enum.TryParse(value.Replace(' ', '_'), out _occupation))
            {
                _occupation = 0;
            }
        }
    }

    // Методы
    /// <summary>
    /// Конвертация экземпляра класса Teacher в строку.
    /// </summary>
    /// <returns>Строку-представление данных экземпляра класса Teacher.</returns>
    public override string ToString()
    {
        return $"Преподаватель в должности {Occupation}" +
            $", ученой степени {ScientificDegree}; " + base.ToString();
    }
    /// <summary>
    /// Печать данных об экземпляре класса Teacher.
    /// </summary>
    public override void Print()
    {
        Print(this);
    }
    /// <summary>
    /// Печать данных об экземпляре класса Teacher.
    /// </summary>
    /// <param name="teacher">Экземпляр класса Teacher для вывода данных.</param>
    public static void Print(Teacher teacher)
    {
        Write(teacher.ToString());
    }
    /// <summary>
    /// Проверка равенства экземпляра класса Teacher и некоего другого объекта.
    /// </summary>
    /// <param name="obj">Экземпляр объекта для сравнения.</param>
    /// <returns>True, если экземпляры объектов совпадают;<br/>
    /// False, в противном случае.</returns>
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Teacher)
        {
            if (((Teacher)obj).Id == this.Id && ((Teacher)obj).Name == this.Name
                && ((Teacher)obj).Age == this.Age && ((Teacher)obj).ScientificDegree == this.ScientificDegree
                && ((Teacher)obj).Occupation == this.Occupation)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Получить хэш-код экземпляра класса Teacher.
    /// </summary>
    /// <returns>32-битное числовое представление хэш-кода.</returns>
    public override int GetHashCode()
    {
        int hashcode = Name.GetHashCode();
        hashcode = 31 * hashcode + Age.GetHashCode();
        hashcode = 31 * hashcode + Id.GetHashCode();
        hashcode = 31 * hashcode + ScientificDegree.GetHashCode();
        hashcode = 31 * hashcode + Occupation.GetHashCode();
        return hashcode;
    }
    /// <summary>
    /// Получить случайный экземпляр класса Teacher из статического массива.
    /// </summary>
    /// <returns>Случайный экземпляр класса Teacher из статического массива.</returns>
    public static Teacher RandomTeacher()
    {
        Random rand = new Random();
        return TEACHERMASS[rand.Next(0, 5)];
    }
    /// <summary>
    /// Добавление студента в список студентов преподавателя.
    /// </summary>
    /// <param name="persons">Персона для добавления.</param>
    public void AddStudents(params Person[] persons)
    {

        if (_studentsList == null || persons == null)
        {
            return;
        }
        foreach (Person p in persons)
        {
            if (p is Student)
            {
                _studentsList.Add((p as Student)!);
            }
        }
    }
    /// <summary>
    /// Клонировать экземпляр класса Teacher.
    /// </summary>
    /// <returns>Копию экземпляра класса Teacher.</returns>
    public override Person Clone()
    {
        Teacher tmpTeacher = new(this.Name, this.Id, this.ScientificDegree, this.Occupation, this.Age);
        if (this._studentsList != null)
        {
            foreach (Student student in this._studentsList)
            {
                tmpTeacher.AddStudents(student);
            }
        }
        return tmpTeacher;
    }
}