class MyHashMap:

    def __init__(self):
        self.size = 1000
        self.buckets = [[] for _ in range(self.size)]

    def hash(self, key: int):
        return key % self.size

    def put(self, key: int, value: int) -> None:
        hash_val = self.hash(key)
        for i, (k, v) in enumerate(self.buckets[hash_val]):
            if k == key:
                self.buckets[hash_val][i] = (key, value)
                return
        self.buckets[hash_val].append((key, value))

    def get(self, key: int) -> int:
        hash_val = self.hash(key)
        for k, v in self.buckets[hash_val]:
            if k == key:
                return v
        return -1

    def remove(self, key: int) -> None:
        hash_val = self.hash(key)
        for i, (k, v) in enumerate(self.buckets[hash_val]):
            if k == key:
                self.buckets[hash_val].pop(i)
                return
        


# Your MyHashMap object will be instantiated and called as such:
# obj = MyHashMap()
# obj.put(key,value)
# param_2 = obj.get(key)
# obj.remove(key)