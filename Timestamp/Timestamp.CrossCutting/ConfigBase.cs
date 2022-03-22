using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timestamp.CrossCutting
{
    public abstract class ConfigBase
    {
        protected readonly IConfiguration _configuration = null;

        protected ConfigBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration GetConfiguration => _configuration;

        public IConfigurationSection GetSection(string section) => _configuration.GetSection(section);

        public string GetSectionValue(string section) => GetSection(section).Value;
    }
}
