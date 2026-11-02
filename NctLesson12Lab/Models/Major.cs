namespace NctK65Lesson10Lab1.Models
{
    public class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }
        public int MajorID { get; set; }
        public string MajorName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}