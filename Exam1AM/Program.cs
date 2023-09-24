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
            Console.WriteLine("Enter 1 to add a course");
            Console.WriteLine("Enter 2 to find a course");
            Console.WriteLine("Enter 3 to remove a course");
            Console.WriteLine("Enter 4 to list all courses");
            Console.WriteLine("Enter 99 to quit");
            Console.Write("Please enter a choice: ");

            uint choice = Convert.ToUInt16(Console.ReadLine());

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

        static void AddCourse(Student student)
        {
            Console.Write("Enter the 3 letter course code: ");
            string? courseCode = Console.ReadLine();
            
            Console.Write("Enter the 4 digit course number: ");
            int courseNumber = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter the 1 digit course credit amount: ");
            int courseCredit = Convert.ToInt32(Console.ReadLine());

            Course course = new Course(courseCode, courseNumber, courseCredit);
            
            if(student.AddCourse(course)) Console.WriteLine($"{course} added\n");
            else Console.WriteLine($"Unable to add {course}\n");
        }

        static void FindCourse(Student student)
        {
            Console.Write("Enter the 3 letter course code: ");
            string courseCode = Convert.ToString(Console.ReadLine());
            
            Console.Write("Enter the 4 digit course number: ");
            int courseNumber = Convert.ToInt32(Console.ReadLine());

            Course course = student.FindCourse(courseCode, courseNumber);

            if (course is not null) Console.WriteLine($"Found course: {course}\n");
            else Console.WriteLine($"No course found matching: {courseCode} {courseNumber}\n");
        }

        static void RemoveCourse(Student student)
        {
            Console.Write("Enter the 3 letter course code: ");
            string courseCode = Console.ReadLine();
            
            Console.Write("Enter the 4 digit course number: ");
            int courseNumber = Convert.ToInt32(Console.ReadLine());

            Course course = student.RemoveCourse(courseCode, courseNumber);
            
            if(course is not null) Console.WriteLine($"Removed course: {course}\n");
            else Console.WriteLine($"No course to remove matching: {courseCode} {courseNumber}\n");
        }

        static void ListCourses(Student student)
        {
            if(student.CurrentNumOfCourses > 0) 
            {
                var courses = student.GetAllCourses();
                
                foreach(var course in courses)
                {
                    if(course is not null) 
                    {
                        Console.WriteLine($"{course}");
                    }
                }

                Console.WriteLine($"Total credits: {student.CalcTotalCredits()}\n");
            }
            else 
            {
                Console.WriteLine("No courses found.\n");
            }

        }
    }
}
