using System.ComponentModel.DataAnnotations;

namespace NctK65Lesson10Lab1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ten phai duoc nhap")]
        [Display(Name = "Ho va ten")]
        [StringLength(100, MinimumLength = 4, ErrorMessage ="Ten phai co tu 4 den 100 ki tu")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email phai duoc nhap")]
        [Display(Name= "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail\.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mat khau phai duoc nhap")]
        [Display(Name="Password")]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@*#$%^&+=!_\\-]).{8,}$")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Nganh phai duoc chon")]
        [Display(Name = "Nganh")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Gioi tinh phai duoc chon")]
        [Display(Name = "Gioi tinh")]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Dia chi")]
        [Required]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1/1/1963", "12/31/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngay sinh phai duoc chon")]
        [Display(Name = "Ngay sinh")]
        public DateTime DateOfBirth { get; set; }

        [Range(0.0, 10.0, ErrorMessage ="Diem phai nam trong khoang 0 den 10")]
        [Required]
        [Display(Name="Diem")]
        public double Diem { get; set; }

        public int? MajorID { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }
}
