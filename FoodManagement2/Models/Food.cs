using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement2.Models
{
    public class Food
    {
        [Key]
        public int F_ID { get; set; }
        public string NAME { get; set; }
        public int PRICE { get; set;}
        public int QTY { get; set;}
        public string IMAGE { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
