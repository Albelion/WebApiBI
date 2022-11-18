using System.ComponentModel.DataAnnotations;
namespace WebApiBI.Models{
    public class Task2Model{
        [Required(ErrorMessage ="Передайте 1 связанный список!")]
        public LinkedList<int>? List1 {get; set;}
        [Required(ErrorMessage ="Передайте 2 связанный список!")]
        public LinkedList<int>? List2 {get; set;}
    }
}