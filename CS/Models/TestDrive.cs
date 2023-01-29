using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Models
{
    public class TestDrive
    {
        [Key]
        
        public int TestDriveID { get; set; }
        [Display(Name = "Име")]
        public String ClientFirstName { get; set; }
        [Display(Name = "Презиме")]
        public String ClientMiddleName { get; set; }
        [Display(Name = "Фамилия")]
        public String ClientLastName { get; set; }

        [Display(Name = "Телефон")]
        public String Phone { get; set; }
        [Display(Name = "Дата на тест драйв")]
        public DateTime DateOTestDrive { get; set; }
        
        [Display(Name = "Модел")]
        public String Model { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CModels { get; set; }
        public int CarsID { get; set; }
        public ICollection<Cars> cars { get; set; }
    }
}
