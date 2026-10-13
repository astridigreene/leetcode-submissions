class CustomStack:

    def __init__(self, maxSize: int):
        self.size = 0
        self.max_size = maxSize
        self.stack = [-1] * maxSize

    def push(self, x: int) -> None:
        if self.size == self.max_size:
            # print(f"not pushing {x} to {self.stack} with a size of {self.size}")
            return
        self.size += 1
        self.stack[self.size - 1] = x
        # print(f"pushed {x} to {self.stack} with a size of {self.size}")

    def pop(self) -> int:
        if self.size == 0:
            # print(f"not popping from {self.stack} with a size of {self.size}")
            return -1
        temp = self.stack[self.size - 1]
        self.stack[self.size - 1] = -1
        self.size -= 1
        # print(f"popped {temp} from {self.stack} with a size of {self.size}")
        return temp

    def increment(self, k: int, val: int) -> None:
        end = min(k, self.size)
        for i in range(end):
            self.stack[i] += val
        # print(f"incremented {k} vals, ended at {end} from {self.stack} with a size of {self.size}")


# Your CustomStack object will be instantiated and called as such:
# obj = CustomStack(maxSize)
# obj.push(x)
# param_2 = obj.pop()
# obj.increment(k,val)