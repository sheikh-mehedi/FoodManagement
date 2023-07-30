using System.ComponentModel.DataAnnotations;

namespace FoodManagement2.Models
{
    public class Order
    {
        [Key]
        public int O_ID { get; set; }
        public int F_ID { get; set;}
        public int C_ID { get; set;}
        public int ORDER_QTY { get; set;}
        public int PRICE { get; set; }
        public string STATUS { get; set; }
    }
}
