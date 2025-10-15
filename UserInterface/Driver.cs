//Created by Jay Johnson 10/14/25//

using ClassLibrary;
using System;

class program
{
    public static void Main()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        var list = new DoublyLinkedList<int>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please choose an option:\n1. Add First\t\t2. Add Last\n3. Remove First\t\t4. Remove Last");
            Console.WriteLine("5. Reverse List\t\t6. Insert after a value\n7. Remove by a value\tq = Quit"); 
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter a value to add to the FRONT of the list:");
                    int valueFront = int.Parse(Console.ReadLine()!);
                    list.AddFirst(valueFront);
                    break;
                case "2":
                    Console.WriteLine("Enter a value to add to the END of the list:");
                    int valueEnd = int.Parse(Console.ReadLine()!);
                    list.AddLast(valueEnd);
                    break;
                case "3":
                    list.RemoveFirst();
                    break;
                case "4":
                    list.RemoveLast();
                    break;
                case "5":
                    list.ReverseList();
                    break;
                case "6":
                    Console.WriteLine("Enter which value you want to insert something after:");
                    int afterValue = int.Parse(Console.ReadLine()!);
                    var node = list.FindNode(afterValue);
                    if (node != null)
                    {
                        Console.WriteLine("Enter the value you want to insert:");
                        int insertValue = int.Parse(Console.ReadLine()!);
                        list.InsertAfter(node, insertValue);
                    }
                    else
                    {
                        Console.WriteLine("That value isn't in the list. Please use a value IN the list!");
                    }
                    break;
                case "7":
                    Console.WriteLine("Enter which value you want to remove:");
                    int removeValue = int.Parse(Console.ReadLine()!);
                    list.RemoveByValue(removeValue);
                    break;
                case "q":
                    running = false;
                    Console.WriteLine("Exiting program. Goodbye! :D");
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again :(");
                    break;
            }
            if (running)
            {
                list.Display();
            }
        }
    }
}       