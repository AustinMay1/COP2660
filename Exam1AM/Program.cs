using System.Text.RegularExpressions;

namespace Exam1AM;

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("Bugs Bunny", 4);
        uint choice;

        do
        {
            
            choice = Menu();
            ProcessChoice(choice, student);
            
        } while (choice != 99);
        
        Console.Write("Press any key to quit: ");
        Console.ReadKey();

        static uint Menu()
        {
            uint choice;
            
            Console.WriteLine("Enter 1 to add a course");
            Console.WriteLine("Enter 2 to find a course");
            Console.WriteLine("Enter 3 to remove a course");
            Console.WriteLine("Enter 4 to list all courses");
            Console.WriteLine("Enter 99 to quit");
            Console.Write("Please enter a choice: ");

            try
            { 
                choice = Convert.ToUInt16(Console.ReadLine());
            }
            catch (FormatException)
            { 
                choice = 0;
            }

            return choice;
        }

        static void ProcessChoice(uint choice, Student student)
        {
            switch (choice)
            {
                case 1: AddCourse(student);
                    break;
                case 2: FindCourse(student);
                    break;
                case 3: RemoveCourse(student);
                    break;
                case 4: ListCourses(student);
                    break;
                case 99: Console.WriteLine("Exiting...");
                    break;
                default: Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        static string GetValidInput(string prompt, string pattern)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!Regex.IsMatch(input, pattern));

            return input;
        }

        static void AddCourse(Student student)
        {
            string courseCode = GetValidInput("Please enter the 3 letter course code: ", @"\b[a-zA-Z]{3}\b");
            string courseNumber = GetValidInput("Enter the 4 digit course number: ", @"\b[0-9]{4}\b");
            string courseCredit = GetValidInput("Enter the 1 digit course credit amount: ", @"\b[0-9]{1}\b");
            
            Course course = new Course(courseCode, Convert.ToInt32(courseNumber), Convert.ToInt32(courseCredit));

            try
            {
                if (student.AddCourse(course))
                {
                    Console.WriteLine($"\n{course} added\n");
                }
                else
                {
                    Console.WriteLine($"\n{course} already exists in this list.\n");
                    
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"\nUnable to add {course}.\nList is full.");
            }
        }

        static void FindCourse(Student student)
        {
            string courseCode = GetValidInput("Enter the 3 letter course code: ", @"\b[a-zA-Z]{3}\b");
            string courseNumber = GetValidInput("Enter the 4 digit course number: ", @"\b[0-9]{4}\b");

            Course? course = student.FindCourse(courseCode, Convert.ToInt32(courseNumber));

            if (course is not null) Console.WriteLine($"\nFound course: {course}\n");
            else Console.WriteLine($"\nNo course found matching: {courseCode} {courseNumber}\n");
        }

        static void RemoveCourse(Student student)
        {
            string courseCode = GetValidInput("Enter the 3 letter course code: ", @"\b[a-zA-Z]{3}\b");
            string courseNumber = GetValidInput("Enter the 4 digit course number: ", @"\b[0-9]{4}\b");

            Course? course = student.RemoveCourse(courseCode, Convert.ToInt32(courseNumber));
            
            if(course is not null) Console.WriteLine($"\nRemoved course: {course}\n");
            else Console.WriteLine($"\nNo course to remove matching: {courseCode} {courseNumber}\n");
        }

        static void ListCourses(Student student)
        {
            if(student.CurrentNumOfCourses > 0) 
            {
                var courses = student.GetAllCourses();
                Console.WriteLine($"\nFound {student.CurrentNumOfCourses} courses for {student.StudentName}:");
                
                foreach(var course in courses)
                {
                    if(course is not null) Console.WriteLine($"{course}");
                }

                Console.WriteLine($"Total credits: {student.CalcTotalCredits()}\n");
            }
            else 
            {
                Console.WriteLine("\nNo courses found.\n");
            }
        }
    }
}
