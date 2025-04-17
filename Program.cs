using Microsoft.VisualBasic;
using Qwerty;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
    namespace StudentManagementApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\n--- Student Management System ---");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View All Students");
                    Console.WriteLine("3. Search Student by ID");
                    Console.WriteLine("4. Delete Student");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(students);
                            break;
                        case "2":
                            ViewStudents(students);
                            break;
                        case "3":
                            SearchStudent(students);
                            break;
                        case "4":
                            DeleteStudent(students);
                            break;
                        case "5":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }

                Console.WriteLine("Goodbye!");
            }

            static void AddStudent(List<Student> students)
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine();

                students.Add(new Student { Id = id, Name = name, Age = age, Grade = grade });
                Console.WriteLine("Student added successfully!");
            }

            static void ViewStudents(List<Student> students)
            {
                Console.WriteLine("\n--- Student List ---");
                if (students.Count == 0)
                {
                    Console.WriteLine("No students available.");
                    return;
                }

                foreach (var s in students)
                {
                    Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}, Grade: {s.Grade}");
                }
            }

            static void SearchStudent(List<Student> students)
            {
                Console.Write("Enter Student ID to search: ");
                int id = int.Parse(Console.ReadLine());

                var student = students.Find(s => s.Id == id);
                if (student != null)
                {
                    Console.WriteLine($"Found -> ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }

            static void DeleteStudent(List<Student> students)
            {
                Console.Write("Enter Student ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var student = students.Find(s => s.Id == id);
                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Grade { get; set; }
        }
    }

}



















