using System;
using System.Collections.Generic;
using System.Text;

namespace TweetApp.DAL.Models
{
    public class ChangePasswordModel : UserModel
    {
        public string newPassword { get; set; }
    }
}
