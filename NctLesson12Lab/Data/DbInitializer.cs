using Microsoft.EntityFrameworkCore;
using NctK65Lesson10Lab1.Models;

namespace NctK65Lesson10Lab1.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Majors.Any())
                {
                    return;
                }

                var majors = new Major[]
                {
                    new Major { MajorName = "IT" },
                    new Major { MajorName = "Economics" },
                    new Major { MajorName = "Mathematics" },
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                var students = new Student[]
                {
                    new Student
                    {
                        Name = "Carson Alexander",
                        Email = "carson@gmail.com",
                        Password = "Abc@12345",
                        Branch = Branch.IT,
                        Gender = Gender.Male,
                        IsRegular = true,
                        Address = "Ha Noi",
                        DateOfBirth = DateTime.Parse("2000-09-01"),
                        Diem = 8,
                        MajorID = majors[0].MajorID
                    },
                    new Student
                    {
                        Name = "Meredith Alonso",
                        Email = "meredith@gmail.com",
                        Password = "Abc@12345",
                        Branch = Branch.IT,
                        Gender = Gender.Female,
                        IsRegular = true,
                        Address = "Hai Phong",
                        DateOfBirth = DateTime.Parse("2002-09-01"),
                        Diem = 7.5,
                        MajorID = majors[1].MajorID
                    },
                };
                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment { StudentID = students[0].Id, CourseID = 1050, Grade = 5.5f },
                    new Enrollment { StudentID = students[0].Id, CourseID = 4022, Grade = 7.5f },
                    new Enrollment { StudentID = students[1].Id, CourseID = 1050, Grade = 3.5f },
                    new Enrollment { StudentID = students[1].Id, CourseID = 4041, Grade = 7f }
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}