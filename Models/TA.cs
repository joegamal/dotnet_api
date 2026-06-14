namespace Modles
{
    public class TA
    {
        public int TAId {get;set;}    

        public string TaName{get;set;}

        public ICollection<Course> Courses { get; set; }

        public Double Salary {get;set;}
    }
}