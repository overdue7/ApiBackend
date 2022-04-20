using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TweetApp.DAL.Models
{
   public class LikeModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string userId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string tweetId { get; set; }
    }
}
