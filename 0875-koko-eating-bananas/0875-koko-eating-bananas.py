class Solution:
    def minEatingSpeed(self, piles: list[int], h: int) -> int:
        '''

        bruteforce:
        - find min piles
        - start from min piles and increment until can complete:
        - while true:
            - index i = 0 (curr hour)
            - curr_pile = piles[0]
            - foreach hour:
                - if curr_pile == 0:
                    - ++i
                    - curr_pile = piles[i]
                - curr_pile -= min_piles
            if i == len(piles) - 1 && curr_pile == 0:
                return min_piles

        sort
        ex1: [3,6,7,11], sum = 27, 27//8 = 3

        '''
        # k = sum(piles)//h
        # while True:
        #     pile = 0
        #     remaining = piles[0]
        #     for hour in range(h):
        #         if pile >= len(piles) - 1 and remaining == 0:
        #             return k
        #         if remaining == 0:
        #             pile += 1
        #             remaining = piles[pile]
        #         remaining -= k
        #         remaining = max(remaining, 0)
        #     if pile >= len(piles) - 1 and remaining == 0:
        #         return k
        #     k += 1

        '''

        check:
        lo = sum(piles)//h
        hi = max(piles)
        mid = (hi-lo)//2
        while True:
            k = mid
            hours = sum(ceil(p / k) for p in piles)
            if hours <= h:
                return True
            if 





        '''

        lo = max(1, sum(piles)//h)
        hi = max(piles)
        while lo < hi:
            mid = (hi+lo)//2
            hours = sum(ceil(p / mid) for p in piles)
            if hours <= h:
                hi = mid
            else:
                lo = mid + 1

        return lo
