using WebApiBI.Controllers;
using WebApiBI.Models;
namespace WebApiBI.Tests{
    public class HomeControllerTests{
        public static Task2Model InitializationLinkedLists(int[] array1, int[] array2){
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            Task2Model task2Model = new Task2Model();
            foreach(int i in array1){
                list1.AddLast(i);
            }
            foreach(int i in array2){
                list2.AddLast(i);
            }
            task2Model.List1 = list1;
            task2Model.List2 = list2;
            return task2Model;
        }
        public static int SumOfLinkedListNodes(LinkedList<int>? list){
            if(list is not null){
                LinkedListNode<int>? node;
                string result = "";
                for (node = list.First; node != null; node = node.Next)
                    result+= node.Value;  
            return Int32.Parse(result);
            }
            else return 0;
        }
        [Fact]
        public void Can_Find_Sum_Of_Odd_Array(){
            // Arrange
            HomeController homeController = new HomeController();

            // Act 
            int[] array1 = new int[]{1, 2, 5, 3, 12, 5, 9};
            int[] array2 = new int[]{8, 3, 5, -1, 7, 12, 11};
            Task1Model task1Model1 = new Task1Model(){TestArray = array1};
            Task1Model task1Model2 = new Task1Model(){TestArray = array2};
            
            int result1 = homeController.GetSumOfOddArray(task1Model1).Value;
            int result2 = homeController.GetSumOfOddArray(task1Model2).Value;

            // Assert
            Assert.Equal(result1, 10);
            Assert.Equal(result2, 12);
        }
        [Fact]
        public void Can_Sum_LinkedLists()
        {
            // Arrange
            HomeController homeController = new HomeController();
            Task2Model task2Model1 = InitializationLinkedLists(new int[]{3,7,8}, new int[]{5,4,6});
            Task2Model task2Model2 = InitializationLinkedLists(new int[]{3,7,8}, new int[]{5,4});
            // Action
            LinkedList<int>? resultList = homeController.GetSumOfLinkedList(task2Model1).Value;

            // Assert1
            int expectedResult = 1518;
            int result = SumOfLinkedListNodes(resultList);
            Assert.Equal(result, expectedResult);

            // Assert2
            expectedResult = 918;
            resultList = homeController.GetSumOfLinkedList(task2Model2).Value;
            result = SumOfLinkedListNodes(resultList);
            Assert.Equal(result, expectedResult);
        }
        [Fact]
        public void Can_Find_Palindrom(){
            // Arrange
            HomeController homeController = new HomeController();

            // Act 
            string str1 = "Hello world";
            string str2 = "itIsPalindromemordnilapsiti";
            Task3Model task3Model1 = new Task3Model(){TestString = str1};
            Task3Model task3Model2 = new Task3Model(){TestString = str2};
            
            bool result1 = homeController.IsPalindrome(task3Model1).Value;
            bool result2 = homeController.IsPalindrome(task3Model2).Value;

            // Assert
            Assert.Equal(result1, false);
            Assert.Equal(result2, true);
        }
    }
}