using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TweetApp.DAL.Models;
using TweetApp.Service.Interface;

namespace TweetAppApi
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TweetsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITweetService _tweetService;
        public TweetsController(IUserService userService,ITweetService tweetService)
        {
            _userService = userService;
            _tweetService = tweetService;
        }

        #region User
        [HttpGet("users/all")]
        public ActionResult<List<UserModel>> Get()
        {
            List<UserModel> allUsers = new List<UserModel>();
            try
            {
               allUsers= _userService.GetAllUsers();
                if(allUsers.Count==0)
                {
                    return NotFound("No data available");
                }
            }
            catch (Exception)
            {
               
            }
            return allUsers;
        }

        [HttpGet("getUsers/{id}")]
        public ActionResult<List<UserModel>> Get(string id)
        {
            List<UserModel> userModels = new List<UserModel>();
            try
            {
                userModels = _userService.GetUserById(id);
                if (userModels.Count() == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                
            }
            
            return userModels;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] UserModel userModel)
        {
            bool status = false;
            try
            {
               status= _userService.RegisterUser(userModel);
                if(status)
                {
                    return Ok("User Register Successfully");
                }
            }
            catch (Exception)
            {
                
            }
           
            return BadRequest("Unable to Register User");
        }
        
        [HttpPost("login")]
        public ActionResult<List<UserModel>> Login([FromBody] UserModel userModel)
        {
            try
            {
                var result = _userService.Login(userModel);
                if(result.Count!=0)
                {
                    return result;
                }
                return NotFound("Invaild login credentials");
            }
            catch (Exception)
            {

                
            }
            return BadRequest();
        }

        [HttpPost("resetPassword")]
        public ActionResult ResetPassword(ChangePasswordModel changePassword)
        {
            try
            {
               var status= _userService.ResetPassword(changePassword);
               if(status)
                {
                    return Ok("Password reset sucessfully");
                }
                return Conflict("Inccorrect current password given");
            }
            catch (Exception)
            {
                
            }
            return BadRequest();
        }
        
        [HttpGet("user/search/{username}")]
        public ActionResult<List<UserModel>> GetByUsername(string username)
        {
            List<UserModel> userModels = new List<UserModel>();
            try
            {
                userModels = _userService.GetUserByUsername(username);
                if(userModels.Count!=0)
                {
                    return userModels;
                }
                return NotFound("No data found");
            }
            catch (Exception)
            {

               
            }

            return BadRequest();
           
        }

        [HttpPost("forgotPassword")]
        public ActionResult ForgotPassword(UserModel userModel)
        { 
            try
            {
               var status= _userService.ForgotPassword(userModel);
                if(status)
                {
                    return Ok("Forgot Password successfully");
                }
                return Conflict("Given detials does not match");
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }
     
        #endregion

        #region Tweets

        [HttpPost("{username}/add")]
        public ActionResult<TweetModel> PostTweet([FromBody] TweetModel tweetModel)
        {
            try
            {
                var status = _tweetService.postTweet(tweetModel);
                if(status)
                {
                    return Ok("Tweet Sent");
                }
                return Conflict("Unable to post tweet");
            }
            catch (Exception)
            {

                
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult<List<TweetAndUser>> getTweet()
        {
            try
            {
                var result= _tweetService.getAllTweets();
                if(result.Count!=0)
                {
                    return result;
                }
                return NotFound("No Tweets found");
            }
            catch (Exception)
            {

                
            }
            return BadRequest();
        }

        [HttpGet("{username}")]
        public ActionResult<List<TweetAndUser>> getUserTweets(string username)
        {
            try
            {
                var result = _tweetService.getAllTweetsOfUser(username);
                if (result.Count != 0)
                {
                    return result;
                }
                return NotFound("No Tweets found");
            }
            catch (Exception)
            {

                
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult<List<TweetModel>> updateTweet([FromBody] TweetModel tweetModel)
        {
           
            try
            {
                var status = _tweetService.UpdateTweet(tweetModel);
                if(status)
                {
                    return Ok("Tweet updated successfully");
                }
                else
                {
                    return Conflict("Unable to update tweet");
                }
            }
            catch (Exception)
            {
                
            }
            return BadRequest();
        }
        [HttpPost("tweet/like")]
        public ActionResult<TweetModel> LikeTweet([FromBody] LikeModel likeModel)
        {
            try
            {
                var status = _tweetService.LikeTweet(likeModel);
                if (status)
                {
                    return Ok("Tweet liked");
                }
                return Conflict("Unable to like tweet");
            }
            catch (Exception)
            {


            }
            return BadRequest();
        }
        #endregion
    }
}
