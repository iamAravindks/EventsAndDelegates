using StudentList;

var students = new List<Student>
{
    new Student { Id =   100, Name = "Ram", Age =   15, Score =   99 },
    new Student { Id =   121, Name = "Arjun", Age =   19, Score =   89.8 },
    new Student { Id =   101, Name = "Rahul", Age =   15, Score =   99.9 },
    new Student { Id =   102, Name = "Riya", Age =   16, Score =   78.5 }
};


Console.WriteLine("Before sorting :Score");

foreach (Student student in students)
{
    Console.WriteLine($"Id : {student.Id} Name : {student.Name} Age : {student.Age} Score : {student.Score} ");
}

Console.WriteLine("Before sorting :Age");

foreach (Student student in students)
{
    Console.WriteLine($"Id : {student.Id} Name : {student.Name} Age : {student.Age} Score : {student.Score} ");
}




SortService<Student>.Sort(students, (Student s1, Student s2) =>
{

    if (s1.Score > s2.Score)
        return 1;
    else if (s1.Score < s2.Score)
        return -1;
    else
        return 0;

});

Console.WriteLine("After sorting :Score ");

foreach (Student student in students)
{
    Console.WriteLine($"Id : {student.Id} Name : {student.Name} Age : {student.Age} Score : {student.Score} ");
}


SortService<Student>.Sort(students, (Student s1, Student s2) =>
{

    if (s1.Age > s2.Age)
        return 1;
    else if (s1.Age < s2.Age)
        return -1;
    else
        return 0;

});

Console.WriteLine("After sorting :Score ");

foreach (Student student in students)
{
    Console.WriteLine($"Id : {student.Id} Name : {student.Name} Age : {student.Age} Score : {student.Score} ");
}