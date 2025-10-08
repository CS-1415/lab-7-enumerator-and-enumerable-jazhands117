using NUnit.Framework;
using ClassLibrary;
namespace ClassLibrary.Tests;

public class LinkedListReversesOrder
//reverse reverses the order of the list//
{
    private DoublyLinkedList<int> listReverse;

    [SetUp]
    public void Setup()
    {
        listReverse = new DoublyLinkedList<int>();
        listReverse.AddLast(1);
        listReverse.AddLast(2);
        listReverse.AddLast(3);
    }

    [Test]
    public void ReverseReversesOrder()
    {
        listReverse.ReverseList();
        Assert.That(listReverse.Length, Is.EqualTo(3));
        Assert.That(listReverse.First, Is.EqualTo(3)); //first becomes last//
        Assert.That(listReverse.Last, Is.EqualTo(1)); //last becomes first//
    }
}