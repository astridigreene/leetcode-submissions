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
        public int user_id;
    }
    Dictionary<int, HashSet<int>> following = new Dictionary<int, HashSet<int>>();
    List<Tweet> tweets = new List<Tweet>();
    public Twitter() {
        
    }
    
    public void PostTweet(int userId, int tweetId) {
        Tweet tweet = new Tweet();
        tweet.user_id = userId;
        tweet.tweet_id = tweetId;
        tweets.Add(tweet);
    }
    
    public IList<int> GetNewsFeed(int userId) {
        if (!following.ContainsKey(userId)) {
            HashSet<int> follows = new HashSet<int>();
            following.Add(userId, follows);
        }

        List<int> feed = new List<int>();
        int total = 0;
        int i = tweets.Count - 1;
        while (i >= 0 && total < 10) {
            if (tweets[i].user_id == userId || following[userId].Contains(tweets[i].user_id)) {
                feed.Add(tweets[i].tweet_id);
                total++;
            }
            --i;
        }
        return feed;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!following.ContainsKey(followerId)) {
            HashSet<int> follows = new HashSet<int>();
            following.Add(followerId, follows);
        }
        following[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (!following.ContainsKey(followerId)) {
            HashSet<int> follows = new HashSet<int>();
            following.Add(followerId, follows);
        }
        following[followerId].Remove(followeeId);
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