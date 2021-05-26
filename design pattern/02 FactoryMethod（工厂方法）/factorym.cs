using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象工厂
    //interface Factory
    //{
    //    Product FactoryMethod();
    //}
    abstract class Factory
    {
        public void FactoryMethod()
        {
            Product product = CProduct();//抽象产品
            product.MethodSame();
            product.MethodDiff();
        }

        public abstract Product CProduct();
    }
    //具体工厂A
    class AFactory : Factory
    {
        //public Product FactoryMethod()
        //{
        //    return new ProductA();
        //}
        public override Product CProduct()
        {
            return new ProductA();//具体产品A
        }
    }
    //具体工厂B
    class BFactory : Factory
    {
        //public Product FactoryMethod()
        //{
        //    return new ProductB();
        //}
        public override Product CProduct()
        {
            return new ProductB();//具体产品B
        }
    }
}
