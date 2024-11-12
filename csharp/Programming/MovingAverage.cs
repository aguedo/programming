namespace Programming;

public class MovingAverage
{
    private Queue<int> _queue;
    private int _size;
    private int _sum;

    public MovingAverage(int size)
    {
        _queue = new Queue<int>();
        _size = size;
    }

    public double Next(int val)
    {
        if (_queue.Count == _size)
        {
            int remove = _queue.Dequeue();
            _sum -= remove;
        }

        _queue.Enqueue(val);
        _sum += val;
        return _sum / (double)_queue.Count;
    }
}
