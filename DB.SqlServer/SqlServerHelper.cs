using DB.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DB.SqlServer
{
    public class SqlServerHelper : IDBHelper
    {

        public SqlServerHelper()
        {
            Console.WriteLine("{0}被构造", this.GetType().Name);
        }

        public void Query()
        {
            Console.WriteLine("{0}.Query", this.GetType().Name);
        }

        public T Find<T>(int Id)
        {
            string connstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NorthwindTraders;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Type type = typeof(T);

            var fields = string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"));
            var tableName = type.Name;
            string strSql = $"select {fields} from {tableName} where Id=" + Id;

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                SqlCommand command = new SqlCommand(strSql,connection);
                connection.Open();//打开数据库连接
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                object oObject = Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    if (reader[prop.Name] != null)
                        prop.SetValue(oObject, reader[prop.Name]);
                    else
                        prop.SetValue(oObject, null);
                }
                return (T)oObject;
            }
        }
    }
}
