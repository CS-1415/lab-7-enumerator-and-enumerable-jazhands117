using NUnit.Framework;
using ClassLibrary;
namespace ClassLibrary.Tests;

public class LinkedListStartingWithTwoTests
//removing first from the front, then remove from the back, results in empty list//
{
    private DoublyLinkedList<int> listTwo;

    [SetUp]
    public void Setup()
    {
        listTwo = new DoublyLinkedList<int>();
        listTwo.AddFirst(1);
        listTwo.AddLast(2);
    }

    [Test]
    public void RemoveFirstThenRemoveLastResultsInEmptyList()
    {
        listTwo.RemoveFirst(); //removes 1//
        listTwo.RemoveLast(); //removes 2//
        Assert.That(listTwo.Length, Is.EqualTo(0));
        Assert.That(listTwo.First, Is.EqualTo(default(int)));
        Assert.That(listTwo.Last, Is.EqualTo(default(int)));
    }
}