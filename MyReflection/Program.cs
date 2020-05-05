using DB.Interface;
using System;
using System.Reflection;

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

            Console.ReadLine();
        }
    }
}
