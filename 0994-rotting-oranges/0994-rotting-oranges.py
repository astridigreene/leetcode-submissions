class Solution:
    def orangesRotting(self, grid: list[list[int]]) -> int:
        '''

        iterate and calculate #rotten, #fresh
        track total rotten oranges, total fresh oranges
        # mins = 0
        while no fresh oranges or if nothing changes
            iterating through the grid
                - whether there is a fresh orange adjacent to a rotten orange
                - bool that shows whether we turned any oranges rotten
                    - if its false, we return -1
                - if we see a rotten orange:
                    - look at the adjacent oranges
                    - if theyre fresh, ++rotten oranges, --fresh oranges, and make them rotten
            ++mins
        return 0

        '''

        rotten = 0
        fresh = 0
        minutes = 0
        for row in grid:
            for col in row:
                if col == 1:
                    fresh += 1
                if col == 2:
                    rotten += 1
        # 6 fresh, 1 rotten
        # 5 fresh, 2 rotten
        # 4 fresh, 3 rotten

        # [[2,2,1],[2,1,0],[0,1,1]]
        change_made = True
        while change_made and fresh > 0:
            change_made = False
            seen = set()
            for i in range(len(grid)):
                for j in range(len(grid[i])):
                    if grid[i][j] != 2 or (i,j) in seen:
                        continue
                    if (i - 1) >= 0:
                        if grid[i-1][j] == 1:
                            rotten += 1
                            fresh -= 1
                            change_made = True
                            grid[i-1][j] = 2
                            seen.add((i-1, j))
                    if (i + 1) < len(grid):
                        if grid[i+1][j] == 1:
                            rotten += 1
                            fresh -= 1
                            change_made = True
                            grid[i+1][j] = 2
                            seen.add((i+1, j))
                    if (j - 1) >= 0:
                        if grid[i][j-1] == 1:
                            rotten += 1
                            fresh -= 1
                            change_made = True
                            grid[i][j-1] = 2
                            seen.add((i, j-1))
                    if (j + 1) < len(grid[i]):
                        if grid[i][j+1] == 1:
                            rotten += 1
                            fresh -= 1
                            change_made = True
                            grid[i][j+1] = 2
                            seen.add((i, j+1))
            minutes += 1
        
        if not change_made:
            return -1
        return minutes
