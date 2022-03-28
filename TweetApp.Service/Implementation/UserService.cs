using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.DAL.Models;
using TweetApp.Service.Interface;
using TweetApp.Repository.Interface;
using System.Linq;

namespace TweetApp.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool ResetPassword(ChangePasswordModel changePassword)
        {
            bool status = false;
            try
            {
                UserModel userModel = new UserModel();
                userModel = _userRepository.FindByCondtion(x => x.email.Equals(changePassword.email) &&
                              x.password.Equals(changePassword.password));
                if(userModel!=null)
                {
                    userModel.password = changePassword.newPassword;
                    userModel.updatedAt = DateTime.Now;
                    status= _userRepository.Update(userModel);
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
        public List<UserModel> GetAllUsers()
        {
            return _userRepository.FindAll().ToList();
        }
        public List<UserModel> GetUserById(string id)
        {
            List<UserModel> userData = new List<UserModel>();
            try
            {
                userData.Add(_userRepository.FindByCondtion(x => x.Id.Equals(id)));
            }
            catch (Exception)
            {

                throw;
            }

            return userData;
        }
        public List<UserModel> GetUserByUsername(string username)
        {
            List<UserModel> userModels = new List<UserModel>();
            userModels=_userRepository.FindAllByCondtion(x => x.username.Contains(username));
            return userModels;
        }
        public List<UserModel> Login(UserModel userModel)
        {
            List<UserModel> validUser = new List<UserModel>();
            try
            {
                validUser.Add(_userRepository.FindByCondtion(x => x.email.Equals(userModel.email) 
                || x.username.Equals(userModel.username)
                && x.password.Equals(userModel.password)));
                           
            }
            catch (Exception)
            {

                throw;
            }
            return validUser;
        }
        public bool RegisterUser(UserModel userModel)
        {
            bool status = false;
            try
            {
                UserModel checkExist = new UserModel();
                checkExist = _userRepository.FindByCondtion(x => x.email==userModel.email 
                              || x.username==userModel.username);
                if(checkExist==null)
                {
                    userModel.createdAt = DateTime.Now;
                    userModel.updatedAt = DateTime.Now;
                    status = _userRepository.Create(userModel);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }
        public bool ForgotPassword(UserModel userModel)
        {
            bool status = false;
            try
            {
                UserModel updatePassword = new UserModel();
                updatePassword = _userRepository.FindByCondtion(x => x.Equals(userModel.email));
                if(userModel.dob.ToString("MM/dd/yyyy")==updatePassword.dob.ToString("MM/dd/yyyy") && updatePassword!=null)
                {
                    updatePassword.password = userModel.password;
                    updatePassword.updatedAt = DateTime.Now;
                   status= _userRepository.Update(updatePassword);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
    }
}
