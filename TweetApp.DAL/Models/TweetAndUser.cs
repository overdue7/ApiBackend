using System;
using System.Collections.Generic;
using System.Text;

namespace TweetApp.DAL.Models
{
   public class TweetAndUser: TweetModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int likes { get; set; }
    }
}
