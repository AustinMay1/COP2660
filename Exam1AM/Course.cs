namespace Exam1AM;

public class Course
{
    private string? _courseCode;
    private int _courseNumber;
    private int _courseCredit;
    
    public Course(string? courseCode, int courseNumber, int courseCredit)
    {
        CourseCode = courseCode;
        CourseNumber = courseNumber;
        CourseCredit = courseCredit;
    }

    public string? CourseCode
    {
        get => _courseCode;
        set => _courseCode = value?.ToUpper() ?? string.Empty;
    }

    public int CourseNumber
    {
        get => _courseNumber;
        set
        {
            if(value is < 1000 or > 4999)
            {
                _courseNumber = 1000;
            }
            else
            {
                _courseNumber = value;
            }
        }
    }

    public int CourseCredit
    {
        get => _courseCredit;
        set
        {
            if (value is < 1 or > 4)
            {
                _courseCredit = 3;
            }
            else
            {
                _courseCredit = value;
            }
        }
    }

    public override string ToString()
    {
        return $"{CourseCode} {CourseNumber} {CourseCredit}";
    }
}