using BookClassLib;
using FigureClassLib;
using PersonClassLib;
using StudentClassLib;
using StudentWithAdvisorClassLib;
using TeacherClassLib;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        WriteLine("0 - тест иерархии Person-Student-Teacher;\n1 - тест иерархии классов Книг;" +
            "\n2 - тест иерархии классов Фигур.");
        switch (ReadLine())
        {
            case "0": // Иерархия Person-Student-Teacher
                // Тест функций RandomPerson, RandomStudent, RandomTeacher
                WriteColor("Тест функций Random, ToSring");
                Person randPerson = Person.RandomPerson();
                StudentWithAdvisor randStudent = StudentWithAdvisor.RandomStudent();
                Teacher randTeacher = Teacher.RandomTeacher();
                WriteLine(randPerson);
                WriteLine(randStudent);
                WriteLine(randTeacher);

                // Массив экземпляров класса Person
                Person[] personArr = new Person[]
                {
                    new Teacher("Сидоров Сергей","T000000","Кандидат_наук", "Доцент", 41),
                    new StudentWithAdvisor("Конопатченко Андрей", "S000000","Бакалавр",18,1,null),
                    new StudentWithAdvisor("Семашко Светлана","S000001","Магистр",22,1,null),
                    new Teacher("Мещанов Федор","T000001","Доктор_наук","Старший_преподаватель",49),
                    new Person(null,"Акелов Дмитрий",19),
                    new StudentWithAdvisor("Левцова Татьяна","S000002","Аспирант",24,1,null)
                };
                ((StudentWithAdvisor)personArr[1]).StudentTeacher = personArr[0];
                ((Teacher)personArr[0]).AddStudents(personArr[0]);
                ((StudentWithAdvisor)personArr[2]).StudentTeacher = personArr[3];
                ((Teacher)personArr[3]).AddStudents(personArr[1], personArr[2], personArr[5]);

                // Использование is, as, GetType, перевод студентов на следующий курс,
                // тестирование метода Print
                WriteColor("\nПеревод студентов на следующий курс, тест Print");
                WriteColor("Старый массив персон:", ConsoleColor.Green);
                int personCtr = 0, studentCtr = 0, teacherCtr = 0;
                foreach (Person person in personArr)
                {
                    person.Print();
                    WriteLine();

                    if (person is StudentWithAdvisor)
                    {
                        (person as StudentWithAdvisor)!.Year++;
                        studentCtr++;
                    }
                    if (person.GetType() == typeof(Person))
                    {
                        personCtr++;
                    }
                    if (person is Teacher)
                    {
                        teacherCtr++;
                    }
                }
                WriteLine($"{personCtr} персон, {teacherCtr} преподавателей и {studentCtr} студентов.");
                // Вывод результатов перевода студентов на следующий курс
                WriteColor("Новый массив персон:", ConsoleColor.Green);
                foreach (Person person in personArr)
                {
                    WriteLine(person);
                }

                // Вывод всех предков класса Student
                WriteColor("\nТест FamilyTree (вывод истории наследования класса Student)");
                WriteColor("Наследование класса Student:", ConsoleColor.Green);
                WriteLine(Student.FamilyTree());

                // Проверка методов Equals, GetHashCode
                WriteColor("Тест Equals, GetHashCode");
                Teacher tmpTeacher = new Teacher("Сидоров Сергей", "T000000", "Кандидат_наук", "Доцент", 41);
                WriteColor("Сравнение двух персон и их хэш-кодов", ConsoleColor.Green);
                WriteLine($"tmpTeacher == personArr[0]:  {tmpTeacher.Equals(personArr[0])}");
                WriteLine($"Хэш-коды совпадают: {tmpTeacher.GetHashCode() == personArr[0].GetHashCode()}");
                WriteLine($"tmpTeacher == personArr[1]:  {tmpTeacher.Equals(personArr[1])}");
                WriteLine($"Хэш-коды совпадают: {tmpTeacher.GetHashCode() == personArr[1].GetHashCode()}");

                // Тестирование метода Clone
                WriteColor("\nРабота метода Clone");
                Person[] personArrClone = new Person[6];
                int index = 0;
                WriteColor("Старый массив персон:", ConsoleColor.Green);
                foreach (Person person in personArr)
                {
                    WriteLine(person);
                    personArrClone[index++] = person.Clone();
                }
                WriteColor("Новый массив персон:", ConsoleColor.Green);
                foreach (Person person in personArrClone)
                {
                    WriteLine(person);
                }

                break;
            case "1": // Иерархия Book
                WriteColor("\nСоздание и печать экземпляров классов");
                Book bookBasic = new("Идиот", "Достоевский Федор", 290);
                bookBasic.Print();
                WriteLine();
                BookGenre bookWithGenre = new("Ваш покорный слуга кот", "Роман", "Сосэки Нацумэ", 340);
                bookWithGenre.Print();
                WriteLine();
                BookGenrePubl bookWithGenrePubl = new("Игры в которые играют люди", "Популярная психология",
                    "Эрик Берн", "Эксмо", 360);
                bookWithGenrePubl.Print();
                WriteLine();
                break;
            case "2": // Иерархия Figure
                WriteColor("\nСоздание и печать экземпляров классов");
                Triangle triangle = new("Треугольник", 3, 4, 5);
                triangle.Print();
                WriteLine();
                TriangleColor triangleColor = new("Треугольник", "Синий", 6, 8, 10);
                triangleColor.Print();
                WriteLine();
                break;
            default:
                WriteColor("Cringe bruv", ConsoleColor.Red);
                break;
        }
    }

    static void WriteColor(string text, ConsoleColor color = ConsoleColor.Yellow)
    {
        Console.ForegroundColor = color;
        WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }
}