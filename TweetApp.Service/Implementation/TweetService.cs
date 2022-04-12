using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;
using TweetApp.Repository.Interface;
using TweetApp.Service.Interface;

namespace TweetApp.Service.Implementation
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _userRepository;
        public TweetService(ITweetRepository tweetRepository,IUserRepository userRepository)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
        }
        public bool DeleteTweet(string id)
        {
            throw new NotImplementedException();
        }

        public List<TweetAndUser> getAllTweets()
        {
            List<TweetModel> twe = new List<TweetModel>();
            List<TweetAndUser> userAndTweet = new List<TweetAndUser>();
            UserModel user;
            twe= _tweetRepository.FindAll();
            foreach(var item in twe)
            {
               user= _userRepository.FindByCondtion(x => x.Id.Equals(item.userId));
                userAndTweet.Add(new TweetAndUser
                {
                    Id=item.Id,
                    userId=item.userId,
                    tweetDescription=item.tweetDescription,
                    createdAt=item.createdAt,
                    updatedAt=item.updatedAt,
                    first_name=user.first_name,
                    last_name=user.last_name
                });
            }
            return userAndTweet;
        }

        public List<TweetModel> getAllTweetsOfUser(string username)
        {
            var tweeters=new List<TweetModel>();
            List<TweetModel> tweetModels = new List<TweetModel>();
            UserModel user = new UserModel();
            user=_userRepository.FindByCondtion(x => x.username.Equals(username));
            if(user!=null)
            {
                tweetModels = _tweetRepository.FindAllByCondtion(x => x.userId.Equals(user.Id));
                tweeters = tweetModels.FindAll(x => x.userId.Equals(user.Id));
            }
            return tweeters;
        }

        public bool LikeTweet(string id)
        {
            throw new NotImplementedException();
        }

        public bool postTweet(TweetModel tweetModel)
        {
           return _tweetRepository.Create(tweetModel);
        }

        public bool ReplyTweet(string id, TweetModel tweetModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTweet(TweetModel tweetModel) 
        {
            try
            {
                _tweetRepository.Update(tweetModel);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}
