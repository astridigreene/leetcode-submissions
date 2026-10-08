public class BrowserHistory {
    int cur_url;
    List<string> history = new List<string>();
    public BrowserHistory(string homepage) {
        history.Add(homepage);
        cur_url = 0;
    }
    
    public void Visit(string url) {
        for (int i = history.Count - 1; i > cur_url; --i) {
            history.RemoveAt(history.Count - 1);
        }
        history.Add(url);
        cur_url = history.Count - 1;
    }
    
    public string Back(int steps) {
        if (cur_url - steps < 0) {
            cur_url = 0;
            return history[cur_url];
        }
        cur_url -= steps;
        return history[cur_url];
    }
    
    public string Forward(int steps) {
        if (cur_url + steps >= history.Count) {
            cur_url = history.Count - 1;
            return history[cur_url];
        }
        cur_url += steps;
        return history[cur_url];
    }
}

// ["BrowserHistory","visit","visit","visit","back","back","forward","visit","forward","back","back"]
// [["leetcode.com"],["google.com"],["facebook.com"],["youtube.com"],[1],[1],[1],["linkedin.com"],[2],[2],[7]]
// [null,null,null,null,"facebook.com","google.com","facebook.com",null,"linkedin.com","google.com","leetcode.com"]

// [leetcode, google, facebook, linkedin, linkedin]
// curr: leetcode, google, facebook, youtube, facebook, google, facebook, linkedin, linkedin, google, leetcode

// starting at the end of the list, pop until we reach our index

// list of strings for the history, and we store our current url as an index
// when visit is called, this would O(n), b/c removing from the end would be O(n)
// 

// stack, enter each url as you visit
// [a, b, c] -- [a, b, c]

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */