using System;
using System.Collections.Generic;
using System.Text;

namespace DB.SqlServer
{
    /// <summary>
    /// 单例模式 确保整个进程中只有一个实例
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _Singleton = null;

        private Singleton() {
            Console.WriteLine("Singleton被构造");
        }

        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
