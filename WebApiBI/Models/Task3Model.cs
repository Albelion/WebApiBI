using System.ComponentModel.DataAnnotations;
namespace WebApiBI.Models{
    public class Task3Model{
        [Required(ErrorMessage ="Передайте строку!")]
        public string? TestString {get; set;}
    }
}