List<Student> Students = new List<Student>();
List<Course> Courses = new List<Course>();
List <Teacher> Teachers = new List<Teacher>();

string input = " ";
while (input != "7")
{
    Console.WriteLine("\n/_____________________/");
    Console.WriteLine("1. Добавить нового студента.");
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
            StudentAdd();
            break;
        case "2":
            TeacherAdd();
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

int IntInput()
{
    if (int.TryParse(Console.ReadLine(), out int output))
    {
        return output;
    }
    else
    {
        Console.WriteLine("Некорректный ввод!");
        Console.Write("Повторный ввод: ");
        return IntInput();
    }
}


DateOnly DateInput()
{
    if (DateOnly.TryParse(Console.ReadLine(), out DateOnly output))
    {
        return output;
    }
    else
    {
        Console.WriteLine("Некорректный ввод!");
        Console.Write("Повторный ввод: ");
        return DateInput();
    }
}

Person NewPerson()
{
    Console.Write("Введите ФИО: ");
    string fio = Console.ReadLine();

    Console.WriteLine("Выберите пол:\n" +
        "1 - Мужской\n" +
        "2 - Женский");
    Console.Write("Ввод: ");
    int genderid = IntInput();
    while (genderid < 1 || genderid > 2)
    {
        Console.WriteLine("Введён неправильный пол!");
        Console.Write("Ввод: ");
        genderid = IntInput();
    }
    Gender gender = (Gender)genderid;

    Console.Write("Введите дату рождения: ");
    DateOnly birth = DateInput();
    while (birth > DateOnly.FromDateTime(DateTime.Now))
    {
        Console.WriteLine("Введена неправлиьная дата рождения!");
        Console.Write("Введите дату рождения: ");
        birth = DateInput();
    }

    return new Person(fio, birth, gender);
}

void StudentAdd()
{
    Person person = NewPerson();
    Console.WriteLine("Есть ли у студента опыт работы с ПК?\n" +
        "0 - Нет.\n" +
        "1 - Да.");
    Console.Write("Ввод: ");
    int pcexpinput = IntInput();
    while (pcexpinput != 0 && pcexpinput != 1)
    {
        Console.WriteLine("Некорректный ввод!");
        Console.Write("Ввод: ");
        pcexpinput = IntInput();
    }
    bool pcexp;
    if (pcexpinput == 0)
    { pcexp = false; }
    else
    { pcexp = true; }


    Console.Write("Введите группу здоровья студента: ");
    string health = Console.ReadLine();

    Student newstudent = new Student(person.FIO, person.Birth, person.Gender, Student.GetID(), pcexp, health);
    Students.Add(newstudent);
    Console.WriteLine("Студент успешно добавлен!\n");
}

void TeacherAdd()
{
    Person person = NewPerson();
    Console.Write("Предмет преподавателя: ");
    string subject = Console.ReadLine();

    Console.Write("Опыт работы (лет): ");
    int exp = IntInput();
    while (exp < 0 || person.Birth.Year + exp > DateOnly.FromDateTime(DateTime.Now).Year) 
    {
        Console.WriteLine("Введен неправильный опыт работы!");
        Console.Write("Опыт работы (лет): ");
        exp = IntInput();
    }

    Teacher newteacher = new Teacher(person.FIO, person.Birth, person.Gender, subject, exp);
    Teachers.Add(newteacher);
    Console.WriteLine("Преподаватель успешно добален!\n");

}


enum Gender
{
    Male = 1,
    Female = 2
}

class Person
{
    public string FIO { get; private set; }
    public DateOnly Birth { get; private set; }
    public Gender Gender { get; private set; }

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
    private string HealthGroup;

    public Student(string fio, DateOnly birth, Gender gender, int studentID, bool pcexp, string healthGroup)
        :base (fio, birth, gender) 
    {
        StudentID = studentID;
        HealthGroup = healthGroup;
    }

    public override void Print()
    {
        Console.WriteLine("Student");
        base.Print();
        Console.WriteLine($"ID студента: {StudentID}\nPCExperience: {PCExp}\nTheHealthGroup: {HealthGroup}\n");
    }

    public static int GetID()
    {
        return StudentID;
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
    public string CourseName { get; private set; }
    public List<Student> students {  get; private set; }
    public Teacher Teacher {  get; private set; }

    public Course(string coursename, List<Student> students, Teacher teacher)
    {
        CourseName = coursename;
        this.students = students;
        Teacher = teacher;
    }

    public void SetCourseName(string coursename)
    {
        CourseName = coursename;
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
