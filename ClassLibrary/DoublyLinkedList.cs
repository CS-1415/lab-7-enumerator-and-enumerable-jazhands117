using System.Collections;
using System.Collections.Generic;
namespace ClassLibrary;

public class DoublyLinkedList<T> : IDoubleEndedCollection<T>, IEnumerable<T>
{
    private DNode<T>? _head = null;
    private DNode<T>? _tail = null;
    public int Length { get; private set; } = 0;

    //first and last implementation//
    public T? First
    {
        get
        {
            if (_head != null)
                return _head.Value;
            else
                return default;
            //returns default value of T if list is empty//
        }
    }

    public T? Last
    {
        get
        {
            if (_tail != null)
                return _tail.Value;
            else
                return default;
            //default depends on what value T is//
        }
    }

    //following pseudocode in lab//
    public void AddLast(T value)
    {
        var newNode = new DNode<T>(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
        Length++;
    }

    public void AddFirst(T value)
    {
        var newNode = new DNode<T>(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        Length++;
    }

    public void RemoveFirst()
    {
        if (_head == null) return; //list is empty, can't remove//

        if (_head == _tail) //only one element, returns empty//
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head!.Previous = null;
        }
        Length--; //decrement length//
    }

    public void RemoveLast()
    {
        if (_tail == null) return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail!.Next = null;
        }
        Length--;
    }

    //inserts into the middle of the list somewhere//
    public void InsertAfter(DNode<T> node, T value)
    {
        var newNode = new DNode<T>(value);
        if (node == null) return; //node is null, can't insert//

        if (node == _tail) //if node is tail, add to end//
        {
            AddLast(value);
        }
        else
        {
            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next!.Previous = newNode;
            node.Next = newNode;
            Length++;
        }
    }

    //helper method to find a node by value for above//
    public DNode<T>? FindNode(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
            {
                return current; //value found//
            }
            current = current.Next;
        }
        return null; //value not found//
    }

    public void RemoveByValue(T value)
    {
        if (_head == null) return; //list is empty, can't remove//

        var current = _head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
            {
                if (current == _head) //if it's the head//
                {
                    RemoveFirst();
                }
                else if (current == _tail) //if it's the tail//
                {
                    RemoveLast();
                }
                else //if it's in the middle//
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                    Length--;
                }
                return; //value found and removed, exit//
            }
            current = current.Next;
        }
        //value not found, nothing removed//
    }

    public void ReverseList()
    {
        if (_head == null || _head == _tail) return; //empty or single element, nothing to reverse//

        var current = _head;
        DNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous; //move to next node (which is previous before swap)//
        }

        //swap head and tail//
        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    //display method for User Interface//
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("List contents:");
        foreach (var item in this)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine(); //for newline after displaying list//
        Console.ForegroundColor = ConsoleColor.White;
    }

    //enumerator implementation//
    public IEnumerator<T> GetEnumerator()
    {
        return new LinkedListEnumerator<T>(_head);
    }
    //non-generic enumerator implementation//
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}