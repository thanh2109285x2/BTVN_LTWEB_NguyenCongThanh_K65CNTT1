using HomeWork.Week1.E1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeWork.Week1.E1
{
    internal class StudentValidator
    {
        public static bool IsIdDuplicate(string id, List<Student> students)
        {
            if (students == null) return false;
            return students.Any(s => s.ID != null && s.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsFullNameValid(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName);
        }

        public static bool IsGpaValid(double gpa)
        {
            return gpa >= 0.0 && gpa <= 10.0;
        }

        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsIdDuplicate(List<Student> students, string id)
        {
            foreach (Student s in students)
            {
                if (s.ID != null && s.ID.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Student> StudentFoundByID(List<Student> students, string id)
        {
            List<Student> found = new List<Student>();
            foreach (Student s in students)
            {
                if (s.ID != null && s.ID.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    found.Add(s);
                }
            }
            return found;
        }

        public static List<Student> StudentFoundByName(List<Student> students, string name)
        {
            List<Student> found = new List<Student>();
            foreach (Student s in students)
            {
                if (s.FullName != null && s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    found.Add(s);
                }
            }
            return found;
        }
    }
}
