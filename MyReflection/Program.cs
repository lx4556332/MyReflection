using DB.Interface;
using System;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            IDBHelper db = SimpleFactory.CreateInstance();
            db.Query();
        }
    }
}
