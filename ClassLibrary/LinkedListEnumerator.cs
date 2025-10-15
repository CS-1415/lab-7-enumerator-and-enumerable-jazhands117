using System.Collections;
using System.Collections.Generic;
namespace ClassLibrary;

public class LinkedListEnumerator<T> : IEnumerator<T>
{
    private DNode<T>? firstNode;
    private DNode<T>? currentNode;

    public LinkedListEnumerator(DNode<T>? head)
    {
        firstNode = head;
        currentNode = null;
    }
    public T? Current
    {
        get
        {
            if (currentNode == null)
            {
                return default; //nothing there to return//
            }
            return currentNode.Value;
        }
    }

    object IEnumerator.Current => Current!; //non-generic implementation//

    public bool MoveNext()
    {
        if (currentNode == null)
        {
            currentNode = firstNode;
            return currentNode != null; //not empty//
        }
        else if (currentNode.Next != null)
        {
            currentNode = currentNode.Next;
            return true;
        }
        else
        {
            return false; //end of list//
        }
    }

    public void Reset()
    {
        currentNode = null;
    }

    public void Dispose()
    {
        //left empty like the lab says :)//
    }
}
