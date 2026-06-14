namespace Modles
{
    public class Doctor
    {
        public int DoctorId {get;set;}    

        public string DoctorName{get;set;}

        public ICollection<Course> Courses { get; set; }

        public Double Salary {get;set;}

    }
}