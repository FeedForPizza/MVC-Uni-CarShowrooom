using System.ComponentModel.DataAnnotations;

namespace CS.Models
{
    public class Orders
    {
        [Key]
        
        public int OrderID { get; set; }
        [Display(Name = "Модел")]
        public String Extra { get; set; }

        
        public Decimal OriginalPrice { get; set; }
        
        
        public Decimal SumOfOrder { get; set; }
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "Име")]
        public String ClientFirstName { get; set; }
        [Display(Name = "Презиме")]
        public String ClientMiddleName { get; set; }
        [Display(Name = "Фамилия")]
        public String ClientLastName { get; set; }

        [Display(Name = "Телефон")]
        public String Phone { get; set; }
        [Display(Name = "Адрес")]
        public String Address { get; set; }

        
        public ICollection<Cars> cars { get; set; }
        
    }
}
