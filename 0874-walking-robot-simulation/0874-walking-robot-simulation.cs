public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        var blocked = new HashSet<(int, int)>();
        foreach (var o in obstacles) {
            blocked.Add((o[0], o[1]));
        }

        int[] dx = { 0, 1, 0, -1 };   // north, east, south, west
        int[] dy = { 1, 0, -1, 0 };
        int dir = 0, x = 0, y = 0, best = 0;

        foreach (int c in commands) {
            if (c == -1) {
                dir = (dir + 1) % 4;      // turn right
            } else if (c == -2) {
                dir = (dir + 3) % 4;      // turn left
            } else {
                for (int i = 0; i < c; i++) {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];
                    if (blocked.Contains((nx, ny))) break;
                    x = nx;
                    y = ny;
                    best = Math.Max(best, x * x + y * y);
                }
            }
        }
        return best;
    }
}