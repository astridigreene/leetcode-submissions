class Solution:
    def merge(self, intervals: list[list[int]]) -> list[list[int]]:
        '''

        iterating through the list:
        keeping track of the previo

            if start_i < start_(i-1): overlapping

            track of our current start and end intervals, and when we find two intervals that don't overlap, then we can append those start/end intervals to our result array

        example 1:
        sort array
        [1,4], [4, 7]

        start, end = 1, 4
        res = []
        iterating through intervals, starting from i = 1:
            if start_i <= end: 
                end = end_i
            else:
                append [start, end] to our res
                reset start, end = start_i, end_i
            if i == len(res) - 1:
                append start, end
         
        end = 7

        res = [1, 6], [8, 10], [15, 18]
        s, e = 15, 18

        '''

        if len(intervals) == 1:
            return intervals

        intervals.sort(key=lambda x:x[0])
        res = []
        start = intervals[0][0]
        end = intervals[0][1]

        for i in range(1, len(intervals)):
            if intervals[i][0] <= end:
                end = max(end, intervals[i][1])
            else:
                res.append([start, end])
                start = intervals[i][0]
                end = intervals[i][1]
            if i == len(intervals) - 1:
                res.append([start, end])
        
        return res

