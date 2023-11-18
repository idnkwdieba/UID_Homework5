
namespace StudentWithAdvisorClassLib;

using static System.Console;
using StudentClassLib;
using TeacherClassLib;
using PersonClassLib;

public class StudentWithAdvisor : Student
{
    private static StudentWithAdvisor[] STUDENTWITHADVMASS = new StudentWithAdvisor[5]
{
        new StudentWithAdvisor("Ященко Дмитрий", null, "Бакалавр", 18, 1, null),
        new StudentWithAdvisor("Макарова Анастасия", null, "Магистр", 23, 2, null),
        new StudentWithAdvisor("Маркелов Евгений", null, "Бакалавр", 20, 3, null),
        new StudentWithAdvisor("Коротченко Антон", null, "Аспирант", 24, 1, null),
        new StudentWithAdvisor("Керченко Ольга", null, "Бакалавр", 19, 2, null)
};

    private Teacher? _studentTeacher; // преподаватель студента

    /// <summary>
    /// Констуктор класса StudentWithAdvisor с параметрами.
    /// </summary>
    /// <param name="name">Имя студента.</param>
    /// <param name="id">Идентификационный номер студента.</param>
    /// <param name="academicDegree">Академическая степень студента.</param>
    /// <param name="age">Возраст студента.</param>
    /// <param name="year">Курс студента.</param>
    /// <param name="teacher">Преподаватель студента.</param>
    public StudentWithAdvisor(string? name, string? id, string? academicDegree, 
        int age, int year, Person? teacher)
        : base(name, id, academicDegree, age, year)
    {
        StudentTeacher = teacher!;
    }

    /// <summary>
    /// Свойство преподавателя студента.
    /// </summary>
    public Person? StudentTeacher 
    { 
        get
        {
            return _studentTeacher;
        }
        set
        {
            if (value != null && value is Teacher)
            {
                _studentTeacher = value as Teacher;
            }
        }
    }
    /// <summary>
    /// Проверка равенства экземпляра класса StudentWithAdvisor и некоего другого объекта.
    /// </summary>
    /// <param name="obj">Экземпляр объекта для сравнения.</param>
    /// <returns>True, если экземпляры объектов совпадают;<br/>
    /// False, в противном случае.</returns>
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is StudentWithAdvisor)
        {
            if (((StudentWithAdvisor)obj).Id == this.Id && ((StudentWithAdvisor)obj).Name == this.Name
                && ((StudentWithAdvisor)obj).Age == this.Age 
                && ((StudentWithAdvisor)obj).AcademicDegree == this.AcademicDegree)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Получить хэш-код экземпляра класса StudentWithAdvisor.
    /// </summary>
    /// <returns>32-битное числовое представление хэш-кода.</returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    /// <summary>
    /// Получить случайный экземпляр класса StudentWithAdvisor из статического массива.
    /// </summary>
    /// <returns>Случайный экземпляр класса StudentWithAdvisor из статического массива.</returns>
    public static new StudentWithAdvisor RandomStudent()
    {
        Random rand = new Random();
        return STUDENTWITHADVMASS[rand.Next(0, 5)];
    }
    /// <summary>
    /// Клонировать экземпляр класса StudentWithAdvisor.
    /// </summary>
    /// <returns>Копию экземпляра класса StudentWithAdvisor.</returns>
    public override Person Clone()
    {
        return new StudentWithAdvisor(this.Name, this.Id, this.AcademicDegree, this.Age, 
            this.Year, this.StudentTeacher);
    }
}