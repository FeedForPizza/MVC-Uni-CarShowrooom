

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Models
{
    public class Cars
    {
        [Key]
        public int CarsID { get; set; }
        [Display(Name = "Модел")]
        public String Model { get; set; }
        [Display(Name = "HP")]

        [RegularExpression("([1-9][0-9]*)")]
        public int HP { get; set; }
        
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "Максимална скорост")]
        public int MaxSpeed { get; set; }
        [Display(Name = "Минимална скорост")]
        public int MinSpeed { get; set; }
        [Display(Name = "Гориво")]
        public String TypeFuel { get; set; }
        
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "Капацитет на резервоара")]
        public int Capacity { get; set; }
        [Display(Name = "Двигател")]

        public String TypeEngine { get; set; }
        [Display(Name = "Брой места")]
        [RegularExpression("([1-9][0-9]*)")]
        public int NumberOfSeats { get; set; }
        [Display(Name = "Дължина")]
        public int Height { get; set; }
        [Display(Name = "Тегло")]
        public int Weight { get; set; }
        [Display(Name = "Разход градско")]
        public decimal AverageExpenseTOWN { get; set; }
        [Display(Name = "Разход извънградско")]
        public decimal AverageExpenseONROAD { get; set; }
        [Display(Name = "Разход комбинирано")]
        public decimal AverageExpenseCOMBINED { get; set; }
        [Display(Name = "Година на производство")]
        [DataType(DataType.Date)]
        public DateTime YearOfManufacture { get; set; }
        [Display(Name = "Врати")]
        [RegularExpression("([1-9][0-9]*)")]
        public int Doors { get; set; }
        [Display(Name = "Каросерия")]
        public String TypeCompartment { get; set; }
        [Display(Name = "Цена")]
        
        public decimal OriginalPrice { get; set; }
        [Display(Name = "Снимка")]
        public string PictureURL { get; set; }
        public Orders orders { get; set; }

        public Storage storage { get; set; }
        public TestDrive testDrive { get; set; }
        
       
       

    }
}
