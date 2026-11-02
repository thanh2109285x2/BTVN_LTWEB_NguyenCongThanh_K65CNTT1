using NctK65Lesson10Lab1.Models;

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public float Grade { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Course? Course { get; set; }
}