using NUnit.Framework;
using ClassLibrary;
namespace ClassLibrary.Tests;

public class LinkedListStartingWithOneAtFrontTests
{
    private DoublyLinkedList<int> listFront;

    [SetUp]
    public void Setup()
    {
        listFront = new DoublyLinkedList<int>();
        listFront.AddFirst(1);
    }

    [Test]
    public void AddLastWorks()
    {
        listFront.AddLast(5);
        Assert.That(listFront.Length, Is.EqualTo(2));
        Assert.That(listFront.First, Is.EqualTo(1));
        Assert.That(listFront.Last, Is.EqualTo(5));
    }

    [Test]
    public void AddFirstWorks()
    {
        listFront.AddFirst(10);
        Assert.That(listFront.Length, Is.EqualTo(2));
        Assert.That(listFront.First, Is.EqualTo(10));
        Assert.That(listFront.Last, Is.EqualTo(1));
    }

    [Test]
    public void RemoveFirstWorks()
    {
        listFront.RemoveFirst();
        Assert.That(listFront.Length, Is.EqualTo(0));
        Assert.That(listFront.First, Is.EqualTo(default(int)));
        Assert.That(listFront.Last, Is.EqualTo(default(int)));
    }

    [Test]
    public void RemoveLastWorks()
    {
        listFront.RemoveLast();
        Assert.That(listFront.Length, Is.EqualTo(0));
        Assert.That(listFront.First, Is.EqualTo(default(int)));
        Assert.That(listFront.Last, Is.EqualTo(default(int)));
    }
}