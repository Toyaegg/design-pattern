using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象类
    abstract class TMAccount
    {
        public bool Validate(string account, string password)
        {
            Console.WriteLine("账号：{0}",account);
            Console.WriteLine("密码：{0}", password);
            if (account.Equals("AA") && password.Equals("123456"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void CalculateInterest();

        public void Display()
        {
            Console.WriteLine("显示利息！");
        }

        public void Handle(string account, string password)
        {
            if (!Validate(account, password))
            {
                Console.WriteLine("账户或密码错误！");
                return;
            }
            CalculateInterest();
            Display();
        }
    }
    //具体子类
    class CurrentAccount : TMAccount
    {
        public override void CalculateInterest()
        {
            Console.WriteLine("按活期利率计算利息！");
        }
    }
    class SavingAccount : TMAccount
    {
        public override void CalculateInterest()
        {
            Console.WriteLine("按定期利率计算利息！");
        }
    }

    //////////////////////////////////////////////钩子方法使用//////////////////////////////////////////////////

    abstract class DataViewer
    {
        public abstract void GetData();
        public void ConvertData()
        {
            Console.WriteLine("将数据转换为XML格式！");
        }

        public abstract void DisplayData();

        public virtual bool IsNotXMLData()
        {
            return true;
        }

        public void Process()
        {
            GetData();
            if (IsNotXMLData())
            {
                ConvertData();
            }
            DisplayData();
        }
    }

    class XMLDataViewer : DataViewer
    {
        public override void GetData()
        {
            Console.WriteLine("从XML中获取数据。");
        }

        public override void DisplayData()
        {
            Console.WriteLine("以柱状图显示数据。");
        }

        public override bool IsNotXMLData()
        {
            return false;
        }
    }
}
