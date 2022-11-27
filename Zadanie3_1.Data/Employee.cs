using System.ComponentModel.DataAnnotations;

namespace Zadanie3_1.Models
{
    public class Employee
    {
       public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
