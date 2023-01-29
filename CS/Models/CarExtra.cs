using System.ComponentModel.DataAnnotations;

namespace CS.Models
{
    public class CarExtra
    {
        [Key]
        public int ExtraID { get; set; }
        public string ExtraName{ get; set; }
        public decimal Price { get; set; }
        
        
    }
}
