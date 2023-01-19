using Org.BouncyCastle.Crypto.Prng.Drbg;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Testing.Models
{
    public class Employee //STORING THE DATA OF EMPLOYEES FROM OUR DATABASE
    {
        public Employee()
        {

        }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public string PhoneNumber { get; set; }
        public string Title { get; set; }

        public IEnumerable<Category> Categories { get; set; }




    }
}
