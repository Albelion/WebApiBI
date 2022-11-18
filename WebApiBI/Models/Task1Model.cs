using System.ComponentModel.DataAnnotations;
namespace WebApiBI.Models{
    public class Task1Model{
        [Required(ErrorMessage ="Передайте массив данных!")]
        public int[]? TestArray {get; set;}
    }
}