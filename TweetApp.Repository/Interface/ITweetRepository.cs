using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Repository.Interface
{
   public interface ITweetRepository
    {
        List<TweetModel> FindAll();
        TweetModel FindByCondtion(Expression<Func<TweetModel, bool>> expression);
        List<TweetModel> FindAllByCondtion(Expression<Func<TweetModel,bool>> expression);
        bool Create(TweetModel data);
        bool Update(TweetModel data);
        bool Delete(string id);

        bool LikeTweet(LikeModel likeModel);

        List<LikeModel> GetAllLikes(Expression<Func<LikeModel, bool>> expression);
    }
}
