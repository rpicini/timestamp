using System;
using System.Collections.Generic;
using System.Text;

namespace Timestamp.CrossCutting.Interface
{
    public interface IMongoDbConfig
    {
        string GetConnectionBase { get; }
    }
}
