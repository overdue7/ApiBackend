using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Service.Interface
{
   public interface ITweetService
    {
        List<TweetAndUser> getAllTweets();
        List<TweetModel> getAllTweetsOfUser(string username);
        bool postTweet(TweetModel tweetModel);
        bool UpdateTweet(TweetModel tweetModel);
        bool DeleteTweet(string id);
        bool LikeTweet(string id);
        bool ReplyTweet(string id, TweetModel tweetModel);


    }
}
