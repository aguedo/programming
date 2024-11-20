namespace Programming;

public class LRUCache
{
    private int _capacity;
    private Dictionary<int, LinkedListNode<KeyValue>> _cache = new Dictionary<int, LinkedListNode<KeyValue>>();
    private LinkedList<KeyValue> _usedList = new LinkedList<KeyValue>();

    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        LinkedListNode<KeyValue> node = _cache.GetValueOrDefault(key, null);
        if (node == null)
        {
            return -1;
        }

        MoveToFront(node);
        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        LinkedListNode<KeyValue> node = _cache.GetValueOrDefault(key, null);
        if (node == null)
        {
            if (_cache.Count == _capacity)
            {
                LinkedListNode<KeyValue> last = _usedList.Last;
                _cache.Remove(last.Value.Key);
                _usedList.RemoveLast();
            }

            var kv = new KeyValue(key, value);
            var newNode = new LinkedListNode<KeyValue>(kv);
            _cache[key] = newNode;
            _usedList.AddFirst(newNode);
        }
        else
        {
            node.Value.Value = value;
            MoveToFront(node);
        }
    }

    private void MoveToFront(LinkedListNode<KeyValue> node)
    {
        _usedList.Remove(node);
        _usedList.AddFirst(node);
    }

    public class KeyValue
    {
        public int Key { get; }
        public int Value { get; set; }

        public KeyValue(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}