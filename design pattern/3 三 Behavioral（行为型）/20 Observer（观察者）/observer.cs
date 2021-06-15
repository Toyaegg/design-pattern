using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象目标类
    abstract class AllyControlCenter
    {
        protected string allyName;
        protected List<OObserver> players = new List<OObserver>();

        public void SetAllyName(string name)
        {
            allyName = name;
        }

        public string GetAllyName()
        {
            return allyName;
        }

        public void Join(OObserver obs)
        {
            Console.WriteLine("{0}加入{1}。", obs.Name, allyName);
            players.Add(obs);
        }

        public void Quit(OObserver obs)
        {
            Console.WriteLine("{0}退出{1}。", obs.Name, allyName);
            players.Remove(obs);
        }

        public abstract void Notify(string name);
    }
    //抽象观察者
    interface OObserver
    {
        string Name { get; set; }
        void Help();
        void BeAttacked(AllyControlCenter acc);
    }
    //具体目标类
    class ConcreteAllyControlCenter : AllyControlCenter
    {
        public ConcreteAllyControlCenter(string name)
        {
            Console.WriteLine("{0}组建成功。", name);
            Console.WriteLine("------------------------------");
            allyName = name;
        }
        public override void Notify(string name)
        {
            Console.WriteLine("{0}战队紧急通知，盟友{1}遭到敌人攻击。", allyName, name);
            foreach (object player in players)
            {
                if (!((OObserver) player).Name.Equals(name))
                {
                    ((OObserver)player).Help();
                }
            }
        }
    }
    //具体观察者
    class Player : OObserver
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Player(string name)
        {
            this.name = name;
        }

        public void Help()
        {
            Console.WriteLine("盟友{0}支援你。", name);
        }

        public void BeAttacked(AllyControlCenter acc)
        {
            Console.WriteLine("{0}遭到敌人攻击。", name);
            acc.Notify(name);
        }
    }

    //////////////////////////////////////////.NET中的委托事件模型/////////////////////////////////////////////
    
    //eventSource.someEvent += new SomeEventHandler(someMethod);
    class TestEvent
    {
        public delegate void UserInput(object sender,EventArgs e);

        public event UserInput OnUserInput;

        public void Method()
        {
            bool flag = false;
            Console.WriteLine("请输入数字：");
            while (!flag)
            {
                if (Console.ReadLine() == "0")
                {
                    OnUserInput(this,new EventArgs());
                }
            }
        }
    }
}
