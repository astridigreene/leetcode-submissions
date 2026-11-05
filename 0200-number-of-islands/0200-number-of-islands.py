class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        def dfs(x, y):
            if x < 0 or y < 0 or x >= len(grid[0]) or y >= len(grid):
                return
            if grid[y][x] == '0':
                return
            grid[y][x] = '0'
            dfs(x + 1, y)
            dfs(x - 1, y)
            dfs(x, y + 1)
            dfs(x, y - 1)
        
        total = 0
        for y in range(len(grid)):
            for x in range(len(grid[0])):
                if grid[y][x] == '1':
                    total += 1
                    dfs(x, y)
        return total