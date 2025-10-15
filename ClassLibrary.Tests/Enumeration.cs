using NUnit.Framework;
using ClassLibrary;
namespace ClassLibrary.Tests;

public class Enumeration
{
    //setup not needed due to IEnumerator being inherent to the system//
    [Test]
    public void TestEnumeration()
    {
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        var expected = new List<int> { 1, 2, 3 };
        var actual = 0;

        foreach (var item in list)
        {
            actual += item;
        }
        Assert.That(actual, Is.EqualTo(6));
    }
}
