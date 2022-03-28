using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Repository.Interface
{
    public interface IUserRepository
    {
        List<UserModel> FindAll();
        UserModel FindByCondtion(Expression<Func<UserModel, bool>> expression);
        List<UserModel> FindAllByCondtion(Expression<Func<UserModel,bool>> expression);
        bool Create(UserModel data);
        bool Update(UserModel data);
        bool Delete(UserModel data);
    }
}
