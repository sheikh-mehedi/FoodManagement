using System.ComponentModel.DataAnnotations;

namespace FoodManagement2.Models
{
    public class User
    {
        [Key]
        public int U_ID { get; set; }
        public string U_NAME { get; set; }
        public string U_PASSWORD { get; set;}
    }
}
