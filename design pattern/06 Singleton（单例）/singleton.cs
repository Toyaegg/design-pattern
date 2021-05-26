using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //简单单例实现
    class Single
    {
        private static Single instance = null;

        private Single()
        {
            Console.WriteLine("Singleton");
        }

        public static Single GetInstance()
        {
            if (instance == null)
            {
                instance = new Single();
            }
            return instance;
        }
    }

    //饿汉式单例
    class ESingle
    {
        private static ESingle instance = new ESingle();

        private ESingle()
        {
            Console.WriteLine("EagerSingleton");
        }

        public static ESingle GetInstance()
        {
            return instance;
        }
    }

    //懒汉式单例加锁
    class LLSingle
    {
        private static LLSingle instance = null;

        //创建一个只读的辅助对象
        private static readonly object locker = new object();
        private LLSingle()
        {
            Console.WriteLine("LazyLockSingleton");
        }

        public static LLSingle GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LLSingle();
                    }
                }
            }
            return instance;
        }
    }
}
