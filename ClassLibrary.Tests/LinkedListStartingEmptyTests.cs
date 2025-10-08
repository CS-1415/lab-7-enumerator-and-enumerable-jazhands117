using NUnit.Framework;
using ClassLibrary;  //so it can see DoublyLinkedList!//
//note, chatgpt suggested adding this using statement//

namespace ClassLibrary.Tests;

public class LinkedListStartingEmptyTests
{
    private DoublyLinkedList<int> listEmpty;

    [SetUp]
    public void Setup()
    {
        listEmpty = new DoublyLinkedList<int>();
    }

    [Test]
    public void CorrectLength()
    {
        Assert.That(listEmpty.Length, Is.EqualTo(0));
    }

    [Test]
    public void AddLastWorks()
    {
        listEmpty.AddLast(5);
        Assert.That(listEmpty.Length, Is.EqualTo(1));
        Assert.That(listEmpty.First, Is.EqualTo(5));
        Assert.That(listEmpty.Last, Is.EqualTo(5));
    }

    [Test]
    public void AddFirstWorks()
    {
        listEmpty.AddFirst(10);
        Assert.That(listEmpty.Length, Is.EqualTo(1));
        Assert.That(listEmpty.First, Is.EqualTo(10));
        Assert.That(listEmpty.Last, Is.EqualTo(10));
    }
    
}