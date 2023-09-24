namespace Exam1AM;

public class Student
{
    private Course[] _courses;
    private int _totalCredits;
    private const int _maxCourses = 6;
    private int _currentCoursesTotal;
    private string? _studentName;
    
    public Student(string? name, int numCourses)
    {
        StudentName = name;
        _totalCredits = 0;
        _currentCoursesTotal = 0;
        _courses = numCourses switch
        {
            <= 0 => new Course[3],
            > _maxCourses => new Course[_maxCourses],
            _ => new Course[numCourses]
        };
    }
    
    public string? StudentName
    {
        get => _studentName;
        set => _studentName = value ?? "Unknown";
    }

    public int CurrentNumOfCourses => _currentCoursesTotal;

    public ref Course[] GetAllCourses()
    {
        return ref _courses;
    }

    public bool AddCourse(Course? course)
    {
        if (CurrentNumOfCourses >= _maxCourses || course == null ||
            FindCourseIndex(course.CourseCode, course.CourseNumber) != -1) return false;
        
        _courses[CurrentNumOfCourses] = course;
        _currentCoursesTotal++;
        return true;

    }

    public Course? RemoveCourse(string? courseCode, int courseNumber)
    {
        var courseIndex = FindCourseIndex(courseCode, courseNumber);

        if (courseIndex != -1)
        {
            Course course = _courses[courseIndex];
            _courses[courseIndex] = null!;
            _currentCoursesTotal--;
            return course;
        }

        return null;
    }

    public Course? FindCourse(string? courseCode, int courseNumber)
    {
        var courseIndex = FindCourseIndex(courseCode, courseNumber);

        if (courseIndex == -1) return null;
        Course course = _courses[courseIndex];
        return course;
    }
    
    private int FindCourseIndex(string? courseCode, int courseNumber)
    {
        const int notFound = -1;
        
        try
        {
            for (var i = 0; i < _courses.Length; i++)
            {
                if (string.Equals(_courses[i].CourseCode, courseCode, StringComparison.OrdinalIgnoreCase) 
                    && _courses[i].CourseNumber == courseNumber)
                {
                    return i;
                }
            }
        }
        catch (NullReferenceException)
        {
            return notFound;
        }

        return notFound;
    }

    public int CalcTotalCredits()
    {
        int total = 0;
        
        foreach(var course in _courses) 
        {
            if(course is not null)
            {
                total += course.CourseCredit;
            }
        }

        _totalCredits = total;
        return _totalCredits;
    }
}