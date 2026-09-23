namespace Depi_Session10
{
    // Q5) List with a fixed capacity that gives clear error messages.
    public class FixedSizeList<T>
    {
        private readonly T[] _items;
        private int _count;

        // How many elements the list can hold at most
        public int Capacity => _items.Length;

        // How many elements are stored right now
        public int Count => _count;

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

            _items = new T[capacity];
        }

        // Adds an element, throws if the list is already full
        public void Add(T item)
        {
            if (_count == _items.Length)
                throw new InvalidOperationException(
                    $"Cannot add '{item}': the list is full (capacity = {Capacity}).");

            _items[_count] = item;
            _count++;
        }

        // Gets the element at an index, throws for an invalid index
        public T Get(int index)
        {
            if (_count == 0)
                throw new InvalidOperationException("The list is empty, there is nothing to get.");

            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Invalid index {index}. Valid indices are from 0 to {_count - 1}.");

            return _items[index];
        }
    }
}
