class Solution:
    def twoSum(self, nums: list[int], target: int) -> list[int]:
        ids_remainders = {}
        for i, num in enumerate(nums):
            if target - num in ids_remainders:
                return [i, ids_remainders[target - num]]
            ids_remainders[num] = i
        return []