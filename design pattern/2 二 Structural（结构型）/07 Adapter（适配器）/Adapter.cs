using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace design_pattern
{
    //对象适配器
    //class Adapter : Target
    //{
    //    private Adaptee adaptee;
    //    public Adapter(Adaptee adaptee)
    //    {
    //        this.adaptee = adaptee;
    //    }
    //    public void Request()
    //    {
    //        adaptee.SpecificRequest();
    //    }
    //}

    //类适配器
    //class Adapter : Adaptee,Target
    //{
    //    public void Request()
    //    {
    //        base.SpecificRequest();
    //    }
    //}

    //适配器简单示例
    //抽象目标
    interface ISAdp
    {
        void add();
        void pp();
    }
    //适配者类A
    class AdapteeA
    {
        public string Pa()
        {
            return "APa";
        }
    }
    //适配者类B
    class AdapteeB
    {
        public string Pb()
        {
            return "BPb";
        }
    }
    //适配器类
    class AdapterMe : ISAdp
    {
        private AdapteeA adapteeA;
        private AdapteeB adapteeB;

        public AdapterMe()
        {
            adapteeA = new AdapteeA();
            adapteeB = new AdapteeB();
        }
        public void add()
        {
            Console.WriteLine(adapteeA.Pa() + adapteeB.Pb());
        }

        public void pp()
        {
            Console.WriteLine(adapteeA.Pa() + "<-->" + adapteeB.Pb());
        }
    }

    //缺省适配器
    //适配者接口
    interface IAbsAdpter
    {
        void AbsA();
        void AbsB();
    }
    //缺省适配器类
    abstract class AbsAdapter : IAbsAdpter
    {
        public void AbsA()
        {
            Console.WriteLine("AbsA");
        }

        public void AbsB()
        {
            Console.WriteLine("AbsB");
        }
    }
    //具体业务类
    class ConcreAbsAdapterA :　AbsAdapter
    {
        public void AbsA()
        {
            Console.WriteLine("ConcreAbsAdapterA");
        }
    }
    class ConcreAbsAdapterB : AbsAdapter
    {
        public void AbsB()
        {
            Console.WriteLine("ConcreAbsAdapterB");
        }
    }

    //双向适配器
    //class Adapter : Target, Adaptee
    //{
    //    private Adaptee adaptee;
    //    private Target tatget;
    //    public Adapter(Adaptee adaptee)
    //    {
    //        this.adaptee = adaptee;
    //    }
    //    public Adapter(Target tatget)
    //    {
    //        this.tatget = tatget;
    //    }
    //    public void Request()
    //    {
    //        adaptee.SpecificRequest();
    //    }
    //    public void SpecificRequest()
    //    {
    //        tatget.Request();
    //    }
    //}
}
