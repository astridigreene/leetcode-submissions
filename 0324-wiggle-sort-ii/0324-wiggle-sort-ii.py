class Solution:
    def wiggleSort(self, nums: list[int]) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        
        '''

        [4, 5, 5, 6] -> [5, 6, 4, 5]

        [4, 5], [5, 6] -> left = mid - 1, right = len(nums) - 1

        [1, 1, 1], [4, 5, 6] -> [1, 1, 1], [6, 5, 4]
        [1, 6, 1, 5, 1, 4]

        [1, 1, 2], [2, 3, 3] -> [2, 1, 1], [3, 3, 2]
        [2, 3, 1, 3, 1, 2]

        [2, 2, 1, 1], [4, 3, 3] -> [2, 4, 2, 3, 1, 3, 1]

        if even, mid = len//2
        else: mid = len//2 + 1
        left = 0, right = mid
        while left < mid, right < len:
            add left
            if right < len:
                add right
            ++left, ++right
        [2, 4, 2, 3, 1, 3, 1]

        '''

        if len(nums) % 2 == 0:
            mid = len(nums) // 2
        else:
            mid = len(nums) // 2 + 1

        nums.sort()
        
        left_arr = nums[:mid]
        right_arr = nums[mid:]
        # print(left_arr)
        # print(right_arr)

        left_arr.sort(reverse=True)
        right_arr.sort(reverse=True)

        left = 0
        right = 0

        res = []

        while left < len(left_arr) or right < len(right_arr):
            res.append(left_arr[left])
            if right < len(right_arr):
                res.append(right_arr[right])
            left += 1
            right += 1
        
        for i in range(len(res)):
            nums[i] = res[i]