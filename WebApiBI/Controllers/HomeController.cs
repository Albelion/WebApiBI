using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiBI.Models;

namespace WebApiBI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController:ControllerBase{
    [HttpGet("task1")]
    public ActionResult<int> GetSumOfOddArray([FromBody] Task1Model array){
        if(!ModelState.IsValid){
          return BadRequest(ModelState);
         }
        // Get odd numbers
        int[] oddArray = array.TestArray!.Where(number=>number%2!=0).ToArray();
        // Take every second number
        oddArray = oddArray.Where((num, index) => index%2!=0).ToArray();
        // Sum modulo
        int result = oddArray.Sum(num=>Math.Abs(num));
        return result;
    }
    [HttpGet("task2")]
    public ActionResult<LinkedList<int>> GetSumOfLinkedList([FromBody] Task2Model lists){
        if(!ModelState.IsValid){
          return BadRequest(ModelState);
        }
        LinkedListNode<int>? node1, node2;
        bool isBiggerThan10 = false;
        LinkedList<int> result = new LinkedList<int>();
        for(node1 = lists.List1!.First, node2 = lists.List2!.First; node1!=null||node2!=null; node1 = node1?.Next, node2 = node2?.Next){
            int value = (node1==null?0:node1.Value)+(node2==null?0:node2.Value);
            if(isBiggerThan10){
                value +=1;
            }
            if(value>=10){
                value -=10;
                isBiggerThan10 = true;
            }
            else{
                isBiggerThan10 = false;
            }
            result.AddFirst(value);
        }
        result.First!.Value = isBiggerThan10?result.First.Value+10:result.First.Value;
        return result;

    }
    [HttpGet("task3")]
    public ActionResult<Boolean> IsPalindrome([FromBody] Task3Model text){
        if(!ModelState.IsValid){
          return BadRequest(ModelState);
         }
        string reversedString = String.Concat(text.TestString!.Reverse());
        return reversedString.Equals(text.TestString, StringComparison.InvariantCultureIgnoreCase);
    }
}