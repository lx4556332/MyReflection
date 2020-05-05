using System;
using System.Collections.Generic;
using System.Text;

namespace DB.SqlServer
{
    public class GenericTest<T,W,X>
    {
        public void Show(T t, W w, X x)
        {
            Console.WriteLine("t.Type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    public class GenericMethod
    {
        public void Show<T,W,X>(T t, W w, X x)
        {
            Console.WriteLine("t.Type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }
    
    public class GenericDouble<T>
    {
        public void show<W, X>(T t, W w,X x)
        {
            Console.WriteLine("t.Type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }
}
