using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Service.Interface
{
   public interface IUserService
    {
        bool RegisterUser(UserModel userModel);
        List<UserModel> Login(UserModel userModel);
        bool ResetPassword(ChangePasswordModel changePassword);
        bool ForgotPassword(UserModel userModel);
        List<UserModel> GetAllUsers();
        List<UserModel> GetUserById(string id);
        List<UserModel> GetUserByUsername(string username);
        
    }
}
