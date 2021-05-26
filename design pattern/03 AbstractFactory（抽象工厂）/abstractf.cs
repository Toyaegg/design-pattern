using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static design_pattern.CommonUtils.Utils;

namespace design_pattern
{
    //抽象工厂
    interface AbsFactory
    {
        AbsProductA CProductA();
        AbsProductB CProductB();
    }
    //抽象产品A
    interface AbsProductA
    {
        void Show();
    }
    //抽象产品B
    interface AbsProductB
    {
        void Show();
    }
    //具体产品AA
    class AProductA : AbsProductA
    {
        public void Show()
        {
            Print("AProductA");
        }
    }
    //具体产品AB
    class AProductB : AbsProductB
    {
        public void Show()
        {
            Print("AProductB");
        }
    }
    //具体产品BA
    class BProductA : AbsProductA
    {
        public void Show()
        {
            Print("BProductA");
        }
    }
    //具体产品BB
    class BProductB : AbsProductB
    {
        public void Show()
        {
            Print("BProductB");
        }
    }
    //具体工厂A
    class AbsAFactory : AbsFactory
    {
        public AbsProductA CProductA()
        {
            return new AProductA();
        }
        public AbsProductB CProductB()
        {
            return new AProductB();
        }
    }
    //具体工厂B
    class AbsBFactory : AbsFactory
    {
        public AbsProductA CProductA()
        {
            return new BProductA();
        }
        public AbsProductB CProductB()
        {
            return new BProductB();
        }
    }
}
