public class LRUCache {
    public int cap;
    public LinkedList<(int key, int val)> list;
    public Dictionary<int, LinkedListNode<(int key, int val)>> cache;
    public LRUCache(int capacity) {
        cap = capacity;
        list = new LinkedList<(int key, int val)>();
        cache = new Dictionary<int, LinkedListNode<(int key, int val)>>();
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) {
            return -1;
        }
        list.Remove(cache[key]);
        list.AddLast(cache[key]);
        return cache[key].Value.val;
    }
    
    public void Put(int key, int value) {
        if (cache.ContainsKey(key)) {
            list.Remove(cache[key]);
            cache[key].Value = (key, value);
            list.AddLast(cache[key]);
            return;
        }
        if (cache.Count == cap) {
            cache.Remove(list.First.Value.key);
            list.RemoveFirst();
            LinkedListNode<(int key, int val)> node = list.AddLast((key, value));
            cache.Add(key, node);
            return;
        }
        LinkedListNode<(int key, int val)> node2 = list.AddLast((key, value));;
        cache.Add(key, node2);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */