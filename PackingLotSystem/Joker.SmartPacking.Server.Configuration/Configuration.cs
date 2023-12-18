using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Joker.SmartPacking.Server.Configuration
{
    public class Configuration : IConfiguration.IConfiguration
    {
        private static IConfigurationRoot configurationRoot;

        static Configuration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configurationRoot = builder.Build();

        }

        /// <summary>
        /// 获取数据库连接的Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Read(string key)
        {
            return configurationRoot[key];
        }
    }
}
