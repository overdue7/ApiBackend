using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TweetApp.DAL.Models;
using TweetApp.Repository.Interface;

namespace TweetApp.Repository.Implementation
{
    public class UserRepository :IUserRepository
    {
       private readonly IMongoCollection<UserModel> _userData;
      
        public UserRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _userData = database.GetCollection<UserModel>("UserData");
        }

        public bool Create(UserModel data)
        {
            bool status = false;
            try
            {
                _userData.InsertOne(data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public bool Delete(UserModel data)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> FindAll()
        {
           return _userData.Find(UserData => true).ToList();   
        }
        public List<UserModel> FindAllByCondtion(Expression<Func<UserModel, bool>> expression)
        {
            return _userData.Find(expression => true).ToList();
        }

        public UserModel FindByCondtion(Expression<Func<UserModel, bool>> expression)
        {
            return _userData.Find(expression).FirstOrDefault();
        }

        public bool Update(UserModel data)
        {
            try
            {
                _userData.ReplaceOne(x => x.email == data.email, data);
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
