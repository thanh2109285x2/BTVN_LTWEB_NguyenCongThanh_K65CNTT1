using HomeWork.Week1.E1;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Week1.E1
{
    internal class MenuManager
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { ID = "SV001", FullName = "Nguyen Van A", DateOfBirth = new DateTime(2003, 5, 15), Gender = true, Email = "nguyenvana@gmail.com", PhoneNumber = "0912345678", Major = "Cong nghe thong tin", Gpa = 8.6, StudentStatus = Status.Studying },
                new Student { ID = "SV002", FullName = "Tran Thi B", DateOfBirth = new DateTime(2002, 11, 20), Gender = false, Email = "tranthib@gmail.com", PhoneNumber = "0987654321", Major = "Khoa hoc may tinh", Gpa = 1.8, StudentStatus = Status.OnLeave },
                new Student { ID = "SV003", FullName = "Le Hoang C", DateOfBirth = new DateTime(2001, 8, 10), Gender = true, Email = "lehoangc@gmail.com", PhoneNumber = "0901122334", Major = "Ky thuat phan mem", Gpa = 5.9, StudentStatus = Status.Graduated }
            };

            string choice;
            do
            {
                StudentConsoleView();
                Console.Write("Nhap lua chon cua ban: ");
                choice = Console.ReadLine() ?? ""; // null thi tra ve chuoi rong
                switch (choice)
                {
                    case "1":
                        StudentService.AddStudent(students);
                        break;
                    case "2":
                        StudentService.DisplayStudents(students);
                        break;
                    case "3":
                        StudentService.FindById(students);
                        break;
                    case "4":
                        StudentService.FindByFullName(students);
                        break;
                    case "5":
                        StudentService.UpdateStudent(students);
                        break;
                    case "6":
                        StudentService.DeleteStudent(students);
                        break;
                    case "7":
                        StudentService.SortByName(students);
                        break;
                    case "8":
                        StudentService.SortByGpa(students);
                        break;
                    case "9":
                        StudentService.ShowStudentsWithGPAHigherThan8(students);
                        break;
                    case "10":
                        StudentService.ShowTopGpaStudents(students);
                        break;
                    case "11":
                        StudentService.ShowAverageGpa(students);
                        break;
                    case "12":
                        StudentService.CountByMajor(students);
                        break;
                    case "13":
                        StudentService.CountByStatus(students);
                        break;
                    case "0":
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long thu lai.");
                        break;
                }

            } while (choice != "0");
        }

        static void StudentConsoleView()
        {
            Console.WriteLine("");
            Console.WriteLine("===== MENU QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim gan dung theo ho ten");
            Console.WriteLine("5. Cap nhat sinh vien");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo ho ten");
            Console.WriteLine("8. Sap xep theo diem trung binh");
            Console.WriteLine("9. Hien thi sinh vien co diem tu 8 tro len");
            Console.WriteLine("10. Hien thi sinh vien co diem cao nhat");
            Console.WriteLine("11. Tinh diem trung binh toan bo sinh vien");
            Console.WriteLine("12. Thong ke sinh vien theo nganh");
            Console.WriteLine("13. Thong ke sinh vien theo trang thai");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("==================================");
            Console.WriteLine("");
        }
    }
}
