List<Student> Students = new List<Student>();
List<Course> Courses = new List<Course>();
List <Teacher> Teachers = new List<Teacher>();

string input = " ";
while (input != "7")
{
    Console.WriteLine("\n/_____________________/");
    Console.WriteLine("1. Добавить новых студентов.");
    Console.WriteLine("2. Добавить нового преподавателя.");
    Console.WriteLine("3. Создать курс.");
    Console.WriteLine("4. Добавить студента на курс.");
    Console.WriteLine("5. Сменить преподавателя курса.");
    Console.WriteLine("6. Просмотр информации.");
    Console.WriteLine("7. Выход.");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            break;
        case "2":
            break;
        case"3":
            break;
        case "4":
            break;
        case "5":
            break;
        case "6":
            break;
        case "7":
            break;
        default:
            Console.WriteLine("Неправильная команда!");
            break;
    }

}


enum Gender
{
    Male,
    Female
}

class Person
{
    private string FIO;
    private DateOnly Birth;
    private Gender Gender;

    public Person(string fio, DateOnly birth, Gender gender)
    {
        FIO = fio;
        Birth = birth;
        Gender = gender;
    }

    public virtual void Print()
    {
        Console.WriteLine($"ФИО: {FIO}\n" +
            $"Дата рождения: {Birth}\n" +
            $"Пол: {Gender}");
    }
}

class Student : Person
{
    private static int StudentID = 1;
    private bool PCExp;
    private int CourseNumber;
    private string HealthGroup;

    public Student(string fio, DateOnly birth, Gender gender, int studentID, bool pcexp, int courseNumber, string healthGroup)
        :base (fio, birth, gender) 
    {
        StudentID = studentID;
        CourseNumber = courseNumber;
        HealthGroup = healthGroup;
    }

    public override void Print()
    {
        Console.WriteLine("Student");
        base.Print();
        Console.WriteLine($"ID студента: {StudentID}\nPCExperience: {PCExp}\nTheHealthGroup: {HealthGroup}\nCourseNumber: {CourseNumber}\n");
    }
}

class Teacher : Person
{
    private string Subject;
    private int ExperienceYears;

    public Teacher(string fio, DateOnly birthday, Gender gender, string subject, int PCExperience)
        : base(fio, birthday, gender)
    {
        Subject = subject;
        ExperienceYears = PCExperience;
    }

    public override void Print()
    {
        Console.WriteLine("Teacher");
        base.Print();
        Console.WriteLine($"Subject: {Subject}\nExperienceYears: {ExperienceYears}\n");
    }
}

class Course
{
    private string CourseName;
    public List<Student> students {  get; private set; }
    public Teacher Teacher {  get; private set; }

    public Course(string coursename, List<Student> students, Teacher teacher)
    {
        CourseName = coursename;
        this.students = students;
        Teacher = teacher;
    }

    public void CourseStudentAdd(Student student)
    {
        students.Add(student);
    }

    public void CourseTeacherChange(Teacher teacher)
    {
        Teacher = teacher;
    }
    
}
