using DB.Interface;
using DB.Model;
using DB.SqlServer;
using Minio;
using Minio.Exceptions;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpoint = "127.0.0.1:9000";
            var accessKey = "minioadmin";
            var secretKey = "minioadmin";
            try
            {
                var minio = new MinioClient(endpoint, accessKey, secretKey);
                FileUpload.Run(minio).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //IDBHelper db = SimpleFactory.CreateInstance();
            //db.Query();

            //Assembly assembly = Assembly.Load("DB.SqlServer");
            //Type type = assembly.GetType("DB.SqlServer.GenericMethod");
            //object oTest = Activator.CreateInstance(type);
            //var Show = type.GetMethod("Show");

            //var showGeneric = Show.MakeGenericMethod(new Type[] { 
            //    typeof(int),typeof(string),typeof(DateTime)
            //});
            //showGeneric.Invoke(oTest, new object[] { 123, "请输入账号", DateTime.Now });
     

            //SqlServerHelper help = new SqlServerHelper();
            //var company=help.Find<Company>(1);


            //UTF8Encoding utf8 = new UTF8Encoding();
            //Byte[] encodedBytes = utf8.GetBytes(company.Name);
            //String decodedString = utf8.GetString(encodedBytes);

            //Console.WriteLine(decodedString);

            Console.ReadLine();
        }


    }
}
