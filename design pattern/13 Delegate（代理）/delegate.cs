using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //简单示例
    abstract class MyDelegate
    {
        public abstract void Request();
    }

    class RealSubject : MyDelegate
    {

        public override void Request()
        {
            Console.WriteLine("RealSubject Request");
        }
    }

    class Proxy : MyDelegate
    {
        private RealSubject realSubject = new RealSubject();

        public void PreRequest()
        {
            Console.WriteLine("Proxy PreRequest");
        }

        public override void Request()
        {
            PreRequest();
            realSubject.Request();
            PostRequest();
        }

        public void PostRequest()
        {
            Console.WriteLine("Proxy PostRequest");
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////
    
    //实例
    class Access
    {
        public bool Ver(string user)
        {
            Console.WriteLine("验证{0}是否合法",user);
            if (user.Equals("QAQ"))
            {
                Console.WriteLine("用户{0}登录成功", user);
                return true;
            }
            else
            {
                Console.WriteLine("用户{0}登录失败", user);
                return false;
            }
        }
    }

    class DelegateLog
    {
        public void Log(string user)
        {
            Console.WriteLine("更新，用户{0}查询次数+1", user);
        }
    }

    interface ISeacher
    {
        string DoSearch(string user, string key);
    }

    class RealSearcher : ISeacher
    {
        public string DoSearch(string user, string key)
        {
            Console.WriteLine("用户{0}使用关键词{1}查询", user, key);
            return "返回关键信息";
        }
    }

    class ProxySearcher : ISeacher
    {
        private RealSearcher realSearcher = new RealSearcher();
        private Access access;
        private DelegateLog delegateLog;
        public string DoSearch(string user, string key)
        {
            if (this.Ver(user))
            {
                string re = realSearcher.DoSearch(user, key);
                this.Log(user);
                return re;
            }
            else
            {
                return null;
            }
        }

        public bool Ver(string user)
        {
            access = new Access();
            return access.Ver(user);
        }

        public void Log(string user)
        {
            delegateLog = new DelegateLog();
            delegateLog.Log(user);
        }
    }
    //虚拟代理与缓冲代理
    //
}
