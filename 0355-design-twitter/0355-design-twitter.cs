public class Twitter {
    /*

    dictionary, id->set<following>

    list of tweets, defined by a tweet class and not the id
    tweet class:
        - tweet id
        - user posted
    
    post tweet:
        - add this to tweets list
        O(1)
    get news feed:
        - iterate tweets list from most recent to least recent
            - if follows user or is user, add to feed
        O(posts)
    follow:
        - add followeeId to follower's following list
        O(1)
    unfollow:
        - remove followeeId from follower's following list
        O(1)

    */

    public class Tweet {
        public int tweet_id;
        public int timestamp;
    }
    public class User {
        public HashSet<int> following;
        public List<Tweet> posts;
    }
    Dictionary<int, User> users = new Dictionary<int, User>();
    int count = 0;

    public Twitter() {
        
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!users.ContainsKey(userId)) {
            User user = new User();
            user.following = new HashSet<int>();
            user.posts = new List<Tweet>();
            users.Add(userId, user);
        }
        Tweet tweet = new Tweet();
        tweet.tweet_id = tweetId;
        tweet.timestamp = count;
        users[userId].posts.Add(tweet);
        count++;
    }
    
    public IList<int> GetNewsFeed(int userId) {
        if (!users.ContainsKey(userId)) {
            User user = new User();
            user.following = new HashSet<int>();
            user.posts = new List<Tweet>();
            users.Add(userId, user);
        }

        List<int> feed = new List<int>();
        
        var tweet_by_time = new PriorityQueue<int, int>();
        int total_posts = 0;
        int latest = 1;
        while (total_posts < 10) {
            if (users[userId].posts.Count - latest >= 0) {
                tweet_by_time.Enqueue(users[userId].posts[users[userId].posts.Count-latest].tweet_id, -users[userId].posts[users[userId].posts.Count-latest].timestamp);
            }
            foreach (int user in users[userId].following) {
                if (!users.ContainsKey(user) || users[user].posts.Count - latest < 0) {
                    continue;
                }
                tweet_by_time.Enqueue(users[user].posts[users[user].posts.Count-latest].tweet_id, -users[user].posts[users[user].posts.Count-latest].timestamp);
            }
            if (tweet_by_time.Count > 0) {
                feed.Add(tweet_by_time.Dequeue());
                ++total_posts;
            }
            else {
                break;
            }
            ++latest;
        }

        return feed;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!users.ContainsKey(followerId)) {
            User user = new User();
            user.following = new HashSet<int>();
            user.posts = new List<Tweet>();
            users.Add(followerId, user);
        }
        users[followerId].following.Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (!users.ContainsKey(followerId)) {
            User user = new User();
            user.following = new HashSet<int>();
            user.posts = new List<Tweet>();
            users.Add(followerId, user);
        }
        users[followerId].following.Remove(followeeId);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */