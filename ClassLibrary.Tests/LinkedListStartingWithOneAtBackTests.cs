using NUnit.Framework;
using ClassLibrary;
namespace ClassLibrary.Tests;

public class LinkedListStartingWIthOneAtBackTests
{
    private DoublyLinkedList<int> listBack;

    [SetUp]
    public void Setup()
    {
        listBack = new DoublyLinkedList<int>();
        listBack.AddLast(1);
    }

    [Test]
    public void AddLastWorks()
    {
        listBack.AddLast(5);
        Assert.That(listBack.Length, Is.EqualTo(2));
        Assert.That(listBack.First, Is.EqualTo(1)); //first stays same///
        Assert.That(listBack.Last, Is.EqualTo(5)); //last becomes addlast//
    }

    public void AddFirstWorks()
    {
        listBack.AddFirst(10);
        Assert.That(listBack.Length, Is.EqualTo(2));
        Assert.That(listBack.First, Is.EqualTo(10)); //first becomes addfirst//
        Assert.That(listBack.Last, Is.EqualTo(1));
    }

    public void RemoveFirstWorks()
    {
        listBack.RemoveFirst();
        Assert.That(listBack.Length, Is.EqualTo(0));
        Assert.That(listBack.First, Is.EqualTo(default(int))); //using default bc removing from list of ints//
        Assert.That(listBack.Last, Is.EqualTo(default(int)));
    }

    public void RemoveLastWorks()
    {
        listBack.RemoveLast();
        Assert.That(listBack.Length, Is.EqualTo(0));
        Assert.That(listBack.First, Is.EqualTo(default(int)));
        Assert.That(listBack.Last, Is.EqualTo(default(int)));
    }
}