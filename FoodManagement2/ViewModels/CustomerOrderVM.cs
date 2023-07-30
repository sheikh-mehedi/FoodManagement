using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodManagement2.ViewModels
{
    public class CustomerOrderVM
    {
        public int O_ID { get; set; }
        public int FID { get; set; }
        public int CID { get; set; }
        public int ORDER_QTY { get; set; }
        public int PRICE { get; set; }
        public string STATUS { get; set; }

        public int F_ID { get; set; }

        [Display(Name = "FOOD NAME")]
        public string NAME { get; set; }
        
        public int QTY { get; set; }
        public string IMAGE { get; set; }

        public int C_ID { get; set; }

        [Display(Name = "CUSTOMER NAME")]
        public string C_NAME { get; set; }
        public int MOBILE { get; set; }
    }
}
