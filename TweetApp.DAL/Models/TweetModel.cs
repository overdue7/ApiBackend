using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TweetApp.DAL.Models
{
   public class TweetModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string userId { get; set; }
        public string tweetDescription { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
