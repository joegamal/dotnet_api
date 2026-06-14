namespace Modles
{
    public class Admin
    {
        public int AdminId {get;set;}

        public string AdminName {get;set;}

        public ICollection<Course> Courses {get;set;}

        public ICollection<Student> Students {get;set;}

        public ICollection<Doctor> Doctors {get;set;}

        public ICollection<TA> TAs {get;set;}
    }
}