class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        '''

        left pointer: left index, incrementing everytime a duplicate is found

        right pointer: incrementing everytime

        left = 0
        right = 0
        longest = 0
        set, holds seen chars in this window, resets everytime we reset left
        iterate while left < len(s):
            if s[right] in set:
                reset set
                left++ 
                right = left
            else:
                ++right
                add this char to our seen
                max(longest, right-left+1)
            

        '''

        left = 0
        right = 0
        longest = 0
        seen = set()

        while left < len(s) and right < len(s):
            if s[right] in seen:
                seen = set()
                left += 1
                right = left
            else:
                longest = max(longest, right-left+1)
                seen.add(s[right])
                right += 1
        return longest
