class Solution:
    def twoSum(self, nums: list[int], target: int) -> list[int]:
        dict = {}
        for i, num in enumerate(nums):
            if num in dict:
                return [i, dict[num]]
            dict[target - num] = i
        return []