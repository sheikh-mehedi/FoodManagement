using System.ComponentModel.DataAnnotations;

namespace FoodManagement2.Models
{
    public class Customer
    {
        [Key]
        public int C_ID { get; set; }
        public string C_NAME { get; set;}
        public int MOBILE { get; set;}
    }
}
