class Solution:
    def majorityElement(self, nums: list[int]) -> int:
        lst = defaultdict(int)
        for i, num in enumerate(nums):
            lst[num] += 1
            if lst[num] > len(nums)/2:
                return num
        return 0