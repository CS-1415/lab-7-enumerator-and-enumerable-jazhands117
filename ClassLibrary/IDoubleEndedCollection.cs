public interface IDoubleEndedCollection<T>
{

    T? First { get; }
    T? Last { get; }
    int Length { get; }

    void AddLast(T value);  
    void AddFirst(T value);
    void RemoveFirst();     
    void RemoveLast();                
    void InsertAfter(DNode<T> node, T value);
    void RemoveByValue(T value);
    void ReverseList();
}