using System;
using System.Collections.Generic;
using System.Text;
using HomeWork.Week1.E1;

namespace HomeWork.Week1.E1
{
    public class StudentService
    {
        public static void AddStudent(List<Student> students)
        {
            Console.WriteLine("===== THEM SINH VIEN =====");
            Student st = new Student();
            Console.WriteLine("Nhap thong tin sinh vien:");

            Console.Write("Nhap ID: ");
            st.ID = Console.ReadLine();
            if (StudentValidator.IsIdDuplicate(st.ID, students))
            {
                Console.WriteLine("Ma sinh vien da ton tai!");
                return;
            }

            Console.Write("Nhap Ho va Ten: ");
            string fullName = Console.ReadLine();
            if (!StudentValidator.IsFullNameValid(fullName))
            {
                Console.WriteLine("Ho va ten rong vui long nhap lai!");
                return;
            }
            else st.FullName = fullName;

            DateTime dob;
            Console.Write("Nhap Ngay sinh (yyyy-MM-dd): ");

            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Dinh dang ngay khong hop le, vui long nhap lai!");
                Console.Write("Nhap Ngay sinh (yyyy-MM-dd): ");
            }

            st.DateOfBirth = dob;

            Console.Write("Nhap Gioi tinh(1-Nam, 0-Nu): ");
            string genderInput = Console.ReadLine();
            st.Gender = genderInput == "1";

            Console.Write("Nhap Email: ");
            string email = Console.ReadLine();
            if (!StudentValidator.IsEmailValid(email))
            {
                Console.WriteLine("Email khong hop le, vui long nhap lai");
                return;
            }
            st.Email = email;

            Console.Write("Nhap So dien thoai: ");
            st.PhoneNumber = Console.ReadLine();

            Console.Write("Nhap Nganh hoc: ");
            st.Major = Console.ReadLine();

            Console.Write("Nhap Diem GPA (0-10): ");
            double gpa = Convert.ToDouble(Console.ReadLine());

            if (!StudentValidator.IsGpaValid(gpa))
            {
                Console.WriteLine("Diem GPA khong hop le, vui long nhap tu 0 den 10!");
                return;
            }
            else st.Gpa = gpa;

            Console.WriteLine("Chon Trang thai sinh vien:");
            Console.WriteLine("1. Studying (Dang hoc)");
            Console.WriteLine("2. On Leave (Bao luu)");
            Console.WriteLine("3. Graduated (Da tot nghiep)");
            Console.WriteLine("4. Expelled (Bi duoi hoc)");
            Console.WriteLine("5. Dropped Out (Tu bo hoc)");

            Status status;
            while (true)
            {
                Console.Write("Nhap lua chon (1-5): ");
                string statusChoice = Console.ReadLine();

                if (statusChoice == "1")
                {
                    status = Status.Studying;
                    break;
                }
                else if (statusChoice == "2")
                {
                    status = Status.OnLeave;
                    break;
                }
                else if (statusChoice == "3")
                {
                    status = Status.Graduated;
                    break;
                }
                else if (statusChoice == "4")
                {
                    status = Status.Expelled;
                    break;
                }
                else if (statusChoice == "5")
                {
                    status = Status.DroppedOut;
                    break;
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le, vui long chon tu 1 den 5!");
                }
            }

            st.StudentStatus = status;

            students.Add(st);

        }

        public static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("===== DANH SACH SINH VIEN =====");
            foreach (Student s in students)
            {
                Console.WriteLine(s.ToString()); 
            }
        }

        public static void FindById(List<Student> students)
        {
            Console.Write("Nhap ID can tim: ");
            string id = Console.ReadLine();
            List<Student> result = StudentValidator.StudentFoundByID(students, id);

            if (result.Count > 0)
            {
                Console.WriteLine("Sinh vien can tim: " + result[0].ToString());
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien voi ma nay!");
            }
            
        }

        public static void FindByFullName(List<Student> students)
        {
            Console.Write("Nhap ten (hoac mot phan ten) can tim: ");
            string name = (Console.ReadLine() ?? "").ToLower();
            List<Student> studentsFound = StudentValidator.StudentFoundByName(students, name);
            if (studentsFound.Count == 0) Console.WriteLine("Khong co ket qua");
            else
            {
                foreach (Student s in studentsFound) Console.WriteLine(s.ToString());
            }
        }

        public static void UpdateStudent(List<Student> students)
        {
            Console.Write("Nhap ID can cap nhat: ");
            string id = Console.ReadLine();
            List<Student> studentsFound = StudentValidator.StudentFoundByID(students, id);
            if (StudentValidator.StudentFoundByID(students, id).Count == 0)
            {
                Console.WriteLine("khong tim thay sinh vien");
                return;
            }
            Student s = studentsFound[0];
            Console.Write($"Ho va Ten ({s.FullName}): ");
            string v = Console.ReadLine(); if (!string.IsNullOrEmpty(v)) s.FullName = v;
            Console.Write($"Email ({s.Email}): "); v = Console.ReadLine(); if (!string.IsNullOrEmpty(v)) s.Email = v;
            Console.Write($"So dien thoai ({s.PhoneNumber}): "); v = Console.ReadLine(); if (!string.IsNullOrEmpty(v)) s.PhoneNumber = v;
            Console.Write($"Nganh ({s.Major}): "); v = Console.ReadLine(); if (!string.IsNullOrEmpty(v)) s.Major = v;
            Console.Write($"GPA ({s.Gpa}): "); v = Console.ReadLine(); if (double.TryParse(v, out double g)) s.Gpa = g;
            Console.WriteLine("Cap nhat xong");
        }

        public static void DeleteStudent(List<Student> students)
        {
            Console.Write("Nhap ID can xoa: ");
            string id = Console.ReadLine();
            List<Student> studentsFound = StudentValidator.StudentFoundByID(students, id);
            if (studentsFound.Count == 0) { Console.WriteLine("Khong tim thay"); return; }
            Student s = studentsFound[0];
            students.Remove(s);
            Console.WriteLine("Da xoa");
        }

        public static void SortByName(List<Student> students)
        {
            students.Sort((a, b) => string.Compare(a.FullName, b.FullName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Da sap xep theo ho ten.");
            DisplayStudents(students);
        }

        public static void SortByGpa(List<Student> students)
        {
            students.Sort((a, b) => b.Gpa.CompareTo(a.Gpa));
            Console.WriteLine("Da sap xep theo diem gpa (giam dan).");
            DisplayStudents(students);
        }

        public static void ShowStudentsWithGPAHigherThan8(List<Student> students)
        {
            double threshold = 8.0;
            List<Student> list = students.FindAll(s => s.Gpa >= threshold);
            if (list.Count == 0) Console.WriteLine("Khong co sinh vien thoa man");
            else foreach (Student s in list) Console.WriteLine(s.ToString());
        }

        public static void ShowTopGpaStudents(List<Student> students)
        {
            if (students.Count == 0) { Console.WriteLine("Danh sach rong."); return; }
            double max = double.MinValue;
            foreach (Student s in students) if (s.Gpa > max) max = s.Gpa;
            List<Student> tops = new List<Student>();
            foreach (Student s in students) if (s.Gpa == max) tops.Add(s);
            Console.WriteLine($"Diem cao nhat: {max}");
            foreach (Student s in tops) Console.WriteLine(s.ToString());
        }

        public static void ShowAverageGpa(List<Student> students)
        {
            if (students.Count == 0) { Console.WriteLine("Danh sach rong."); return; }
            double sum = 0; 
            foreach (Student s in students)
            {
                sum += s.Gpa;
            }
            Console.WriteLine($"Diem trung binh toan bo sinh vien: {sum / students.Count}");
        }

        public static void CountByMajor(List<Student> students)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (Student s in students)
            {
                string m = s.Major ?? "Unknown";
                if (!dict.ContainsKey(m)) dict[m] = 0;
                dict[m]++;
            }
            foreach (var kv in dict) Console.WriteLine($"{kv.Key}: {kv.Value}");
        }

        public static void CountByStatus(List<Student> students)
        {
            Dictionary<Status, int> dict = new Dictionary<Status, int>();
            foreach (Student s in students)
            {
                Status st = s.StudentStatus;
                if (!dict.ContainsKey(st)) dict[st] = 0;
                dict[st]++;
            }
            foreach (var kv in dict) Console.WriteLine($"{kv.Key}: {kv.Value}");
        }
    }
}
