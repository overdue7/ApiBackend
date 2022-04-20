using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TweetApp.DAL.Models;
using TweetApp.Repository.Interface;

namespace TweetApp.Repository.Implementation
{
    public class TweetRepository : ITweetRepository
    {
        private readonly IMongoCollection<TweetModel> _tweetData;
        private readonly IMongoCollection<LikeModel> _likeData;

        public TweetRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tweetData = database.GetCollection<TweetModel>("TweetData");
            _likeData = database.GetCollection<LikeModel>("LikeData");
        }
        public bool Create(TweetModel data)
        {
            bool status = false;
            try
            {
                data.createdAt = DateTime.Now;
                data.updatedAt = DateTime.Now;
                _tweetData.InsertOne(data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public bool Delete(string id)
        {
            bool status = false;
            try
            {
                _tweetData.DeleteOne(x=>x.Id.Equals(id));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public List<TweetModel> FindAll()
        {
             List<TweetModel> twe= new List<TweetModel>();
            twe = _tweetData.Find(TweetModel => true).ToList();
            twe.Reverse();
            return twe;
        }

        public List<TweetModel> FindAllByCondtion(Expression<Func<TweetModel, bool>> expression)
        {
            List<TweetModel> twe = new List<TweetModel>();
            twe = _tweetData.Find(expression => true).ToList();
            twe.Reverse();
            return twe;
        }

        public TweetModel FindByCondtion(Expression<Func<TweetModel, bool>> expression)
        {
            return _tweetData.Find(expression => true).FirstOrDefault();
        }

        public List<LikeModel> GetAllLikes(Expression<Func<LikeModel, bool>> expression)
        {
            return _likeData.Find(expression).ToList();
        }

        public bool LikeTweet(LikeModel likeModel)
        {
            bool status = false;
            try
            {
              
                _likeData.InsertOne(likeModel);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public bool Update(TweetModel data)
        {
            try
            {
                _tweetData.ReplaceOne(x => x.userId.Equals(data.userId), data);
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
