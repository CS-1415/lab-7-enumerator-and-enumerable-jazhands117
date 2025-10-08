public class DNode<T>
{
    public T? Value { get; set; }
    public DNode<T>? Previous { get; set; }
    public DNode<T>? Next { get; set; }

    //constructors, takes care of null value//
    public DNode() { }
    public DNode(T value)
    {
        Value = value;
        Previous = null;
        Next = null;
    }
}