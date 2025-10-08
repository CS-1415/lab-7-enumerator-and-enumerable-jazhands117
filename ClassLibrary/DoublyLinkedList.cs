public class DoublyLinkedList<T> : IDoubleEndedCollection<T>
{
    private DoublyLinkedListNode<T>? _head = null;
    private DoublyLinkedListNode<T>? _tail = null;
    public int Length { get; } = 0;

    /*TODO: implement the methods of the interface
    void AddLast(T value);  
    void AddFirst(T value);
    void RemoveFirst();     
    void RemoveLast();                
    void InsertAfter(DNode<T>, T value);
    void RemoveByValue(T value);
    void ReverseList();*/

    //following pseudocode in lab//
    void AddLast(T value)
    {
        var newNode = new DoublyLinkedListNode<T>(value);
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

    void AddFirst(T value)
    {
        var newNode = new DoublyLinkedListNode<T>(value);
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

    void RemoveFirst()
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

    void RemoveLast()
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
    void InsertAfter(DNode<T> node, T value)
    {
        var newNode = new DoublyLinkedListNode<T>(value);
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

    void RemoveByValue(T value)
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

    void ReverseList()
    {
        if (_head == null || _head == _tail) return; //empty or single element, nothing to reverse//

        var current = _head;
        DoublyLinkedListNode<T>? temp = null;

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
}