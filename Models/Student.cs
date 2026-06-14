
namespace Modles
{
    public class Student
    {
        public int StudentId {get; set;}

        public string Name {get; set;}

        public int Level {get; set;}

        public ICollection<Course> Courses { get; set; }    
    }
    
}