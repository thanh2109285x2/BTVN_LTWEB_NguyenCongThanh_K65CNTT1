using System;

namespace HomeWork.Week1.E1
{

    public enum Status
    {
        Studying,
        OnLeave,
        Graduated,
        Expelled,
        DroppedOut
    }
    public class Student
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; } // true for male, false for female
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public double Gpa { get; set; }
        public Status StudentStatus { get; set; }

        public Student() { }

        public Student(string iD, string fullName, DateTime dateOfBirth, bool gender, string email, string phoneNumber, string major, double gpa, Status status)
        {
            ID = iD;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
            Gpa = gpa;
            StudentStatus = status;
        }

        public override string ToString()
        {
            return $"ID: {ID}, FullName: {FullName}, DateOfBirth: {DateOfBirth.ToShortDateString()}, Gender: {(Gender ? "Nam" : "Nữ")}, Email: {Email}, PhoneNumber: {PhoneNumber}, Major: {Major}, GPA: {Gpa}, Status: {StudentStatus}";
        }
    }
}