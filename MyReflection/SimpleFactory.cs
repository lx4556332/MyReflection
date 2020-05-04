using DB.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyReflection
{
    public class SimpleFactory
    {
        public static string assemblyConfig = CustomConfigManager.GetConfig("dbHelperRefliction");
        public static IDBHelper CreateInstance()
        {
            Assembly assembly = Assembly.Load(assemblyConfig.Split(",")[1]);
            Type type = assembly.GetType(assemblyConfig.Split(",")[0]);
            object oSqlserverHelper = Activator.CreateInstance(type);
            IDBHelper dBHelper = oSqlserverHelper as IDBHelper;
            return dBHelper;
        }

        /// <summary>
        /// 读取配置文件
        /// 需要引用 Microsoft.Extensions.Configuration.Json 包
        /// </summary>
        public static class CustomConfigManager
        {
            public static string GetConfig(string key)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                IConfigurationRoot configuration = builder.Build();

                string configVaule = configuration.GetSection(key).Value;
                return configVaule;
            }
        }
    }
}
