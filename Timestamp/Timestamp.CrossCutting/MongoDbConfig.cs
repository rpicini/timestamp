using Microsoft.Extensions.Configuration;
using System;
using Timestamp.CrossCutting.Interface;

namespace Timestamp.CrossCutting
{
    public class MongoDbConfig : ConfigBase, IMongoDbConfig
    {
        public MongoDbConfig(IConfiguration configuration) : base(configuration)
        {

        }

        public string GetConnectionBase => GetSectionValue("ConnectionString");
    }
}
