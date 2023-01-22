namespace Testing.Models
{
    public class Review
    {
        public Review()
        {

        }
        public int ReviewID { get; set; }
        
        public int ProductId { get; set; }
        public string Reviewer { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } 
           
    }
}
