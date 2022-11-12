public class MedianFinder {
    private SortedSet<(int Value, int Counter)> _small;
    private SortedSet<(int Value, int Counter)> _large;
    private int _counter;

    public MedianFinder() {
        _small = new(Comparer<(int Value, int Counter)>.Create( (a,b)=> a.Value == b.Value ? a.Counter-b.Counter : a.Value-b.Value ));
        _large = new(Comparer<(int Value, int Counter)>.Create((a,b)=> a.Value == b.Value ? a.Counter - b.Counter : a.Value-b.Value));    
        _counter=0;
    }
    
    public void AddNum(int num) {
        _small.Add((-1*num,  _counter++));

        //Check if _small Heap Max Value > _large Heap Min Value
        if(_small.Count > 0 && _large.Count > 0 && (-1 * _small.First().Value) > _large.First().Value)
        {
            var element = _small.First();
            _small.Remove(_small.First());
            _large.Add((-1* element.Value, element.Counter));
        }

        //Check if Uneven array
        if(_small.Count > _large.Count +1)
        {
            var element = _small.First();
            _small.Remove(_small.First());
            _large.Add(( -1* element.Value, element.Counter));
        }

        if(_large.Count > _small.Count +1)
        {
            var element = _large.First();
            _large.Remove(_large.First());
            _small.Add((-1 * element.Value, element.Counter));
        }
    }
    
    public double FindMedian() {
        if(_small.Count > _large.Count)
        {
            return -1 * _small.First().Value;
        }
        else if(_large.Count > _small.Count)
        {
            return _large.First().Value;
        }
        else
        {
            return ((-1 * _small.First().Value) + _large.First().Value)/2.00;
        }
        return 0.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */