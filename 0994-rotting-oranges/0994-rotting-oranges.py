class Solution:
    def orangesRotting(self, grid: list[list[int]]) -> int:
        q = deque()
        seen = set()

        fresh = 0

        for i in range(len(grid)):
            for j in range(len(grid[i])):
                if grid[i][j] == 2:
                    q.append((i, j))
                    seen.add((i, j))
                elif grid[i][j] == 1:
                    fresh += 1

        mins = 0
        while q:
            for _ in range(len(q)):
                (row, col) = q.popleft()
                if row - 1 >= 0 and grid[row - 1][col] == 1 and grid[row - 1][col] not in seen:
                    q.append((row - 1, col))
                    seen.add((row - 1, col))
                    grid[row - 1][col] = 2
                    fresh -= 1
                if row + 1 < len(grid) and grid[row + 1][col] == 1 and grid[row + 1][col] not in seen:
                    q.append((row + 1, col))
                    seen.add((row + 1, col))
                    grid[row + 1][col] = 2
                    fresh -= 1
                if col - 1 >= 0 and grid[row][col - 1] == 1 and grid[row][col - 1] not in seen:
                    q.append((row, col - 1))
                    seen.add((row, col - 1))
                    grid[row][col - 1] = 2
                    fresh -= 1
                if col + 1 < len(grid[row]) and grid[row][col + 1] == 1 and grid[row][col + 1] not in seen:
                    q.append((row, col + 1))
                    seen.add((row, col + 1))
                    grid[row][col + 1] = 2
                    fresh -= 1
            mins += 1
        

        if fresh > 0:
            return -1
        return max(0, mins - 1)