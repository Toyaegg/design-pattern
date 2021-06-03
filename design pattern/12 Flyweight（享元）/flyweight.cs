using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象享元类
    abstract class Flyweight
    {
        public abstract void FwOp(OutState os);
    }
    //具体享元类
    class ConcreteFlyweight : Flyweight
    {
        private string instrinsicState;

        public ConcreteFlyweight(string ins)
        {
            instrinsicState = ins;
        }

        public string GetInsState()
        {
            return instrinsicState;
        }

        public override void FwOp(OutState os)
        {
            Console.WriteLine(instrinsicState + "   " + os.state);
        }
    }
    //非共享具体享元类
    class UnsharedFlyweight : Flyweight
    {
        public override void FwOp(OutState os)
        {
            Console.WriteLine("UnsharedFlyweight  " + os.state);
        }
    }
    //享元工厂类
    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public Flyweight GetFlyweight(string key)
        {
            if (flyweights.ContainsKey(key))
            {
                Console.WriteLine("Have this key!");
                return (Flyweight) flyweights[key];
            }
            else
            {
                Console.WriteLine("Don't have this key!");
                Flyweight fw = new ConcreteFlyweight(key);
                flyweights.Add(key,fw);
                return fw;
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    class OutState
    {
        public string state;

        public OutState(string state)
        {
            this.state = state;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //复合享元类
    class CompositeFlyWeight : Flyweight
    {
        private Hashtable flyweights = new Hashtable();
        private string key = "composite";

        public Flyweight GetFlyweight()
        {
            if (flyweights.ContainsKey(key))
            {
                Console.WriteLine("Have this key!");
                return (Flyweight)flyweights[key];
            }
            else
            {
                Console.WriteLine("Don't have this key!");
                Flyweight fw = new ConcreteFlyweight(key);
                flyweights.Add(key,fw);
                return fw;
            }
        }
        public override void FwOp(OutState os)
        {
            Console.WriteLine("CompositeFlyWeight" + "   " + os.state);
        }

        public void Add(Flyweight flyweight)
        {
            Console.WriteLine("Add!");
            if (!flyweights.ContainsValue(flyweight))
            {
                Console.WriteLine("Don't have this value!");
                flyweights.Add(flyweight, flyweight);
                Console.WriteLine("Added!");
            }
            else
            {
                Console.WriteLine("Have this value!");
            }
        }

        public void Remove(Flyweight flyweight)
        {
            Console.WriteLine("Remove!");
            if (flyweights.ContainsValue(flyweight))
            {
                Console.WriteLine("Have this value!");
                flyweights.Remove(flyweight);
                Console.WriteLine("Removed!");
            }
            else
            {
                Console.WriteLine("Don't have this value!");
            }
        }
    }
}
