namespace Exam1AM;

public class Student
{
    private Course[] _courses;
    private int _totalCredits;
    private const int _maxCourses = 6;
    private int _currentCoursesTotal;
    private string _studentName;
    
    public Student(string name, int numCourses)
    {
        StudentName = name;
        _totalCredits = 0;
        _currentCoursesTotal = 0;

        if (numCourses <= 0)
        {
            _courses = new Course[3];
        }
        else if (numCourses > _maxCourses)
        {
            _courses = new Course[_maxCourses];
        }
        else
        {
            _courses = new Course[numCourses];
        }
    }
    
    public string StudentName
    {
        get => _studentName;
        set
        {
            if(value is null)
            {
                _studentName = "Unknown";
            }
            else
            {
                _studentName = value;
            }
        }
    }

    public int CurrentNumOfCourses
    {
        get => _currentCoursesTotal;
    }

    public ref Course[] GetAllCourses()
    {
        return ref _courses;
    }

    public bool AddCourse(Course course)
    {
        if (CurrentNumOfCourses >= _maxCourses || course == null ||
            FindCourseIndex(course.CourseCode, course.CourseNumber) != -1) return false;
        
        _courses[CurrentNumOfCourses] = course;
        _currentCoursesTotal++;
        return true;

    }

    public Course RemoveCourse(string courseCode, int courseNumber)
    {
        var courseIndex = FindCourseIndex(courseCode, courseNumber);

        if (courseIndex != -1)
        {
            Course course = _courses[courseIndex];
            _courses[courseIndex] = null;
            _currentCoursesTotal--;
            return course;
        }

        return null;
    }

    public Course FindCourse(string courseCode, int courseNumber)
    {
        var courseIndex = FindCourseIndex(courseCode, courseNumber);

        if (courseIndex != -1)
        {
            Course course = _courses[courseIndex];
            return course;
        }

        return null;
    }
    
    private int FindCourseIndex(string courseCode, int courseNumber)
    {
        for (var i = 0; i < _courses.Length; i++)
        {
            if (_courses[i].CourseCode == courseCode && _courses[i].CourseNumber == courseNumber)
            {
                return i;
            }
        }

        return -1;
    }

    public int CalcTotalCredits()
    {
        var totalCredits = 0;

        for (var i = 0; i < _courses.Length; i++)
        {
            totalCredits += _courses[i].CourseCredit;
        }

        return totalCredits;
    }
}