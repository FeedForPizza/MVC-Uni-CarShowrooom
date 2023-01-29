using System.ComponentModel.DataAnnotations;

namespace CS.Models
{
    public class Storage
    {
        [Key]
        
        public int StorageID { get; set; }
        [Display(Name = "Година на производство")]
        public DateTime YearOfManufacture { get; set; }
        [Display(Name = "Модел")]
        public String Model { get; set; }
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "Наличност")]
        public String Availability { get; set; }

        public ICollection<Cars> cars { get; set; }

        


    }
}
