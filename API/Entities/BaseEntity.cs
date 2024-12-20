﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewsAPI.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool Deleted { get; set; }
    }
}
