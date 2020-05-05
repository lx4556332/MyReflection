using DB.Interface;
using DB.Model;
using DB.SqlServer;
using System;
using System.Reflection;
using System.Text;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            IDBHelper db = SimpleFactory.CreateInstance();
            db.Query();

            Assembly assembly = Assembly.Load("DB.SqlServer");
            Type type = assembly.GetType("DB.SqlServer.GenericMethod");
            object oTest = Activator.CreateInstance(type);
            var Show = type.GetMethod("Show");

            var showGeneric = Show.MakeGenericMethod(new Type[] { 
                typeof(int),typeof(string),typeof(DateTime)
            });
            showGeneric.Invoke(oTest, new object[] { 123, "请输入账号", DateTime.Now });
     

            SqlServerHelper help = new SqlServerHelper();
            var company=help.Find<Company>(1);


            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(company.Name);
            String decodedString = utf8.GetString(encodedBytes);

            Console.WriteLine(decodedString);

            Console.ReadLine();
        }
    }
}
