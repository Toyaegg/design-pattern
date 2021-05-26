using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static design_pattern.CommonUtils.Utils;
namespace design_pattern
{
    //抽象产品
    //abstract class Product//简化前
    //{
    //    public void MethodSame()
    //    {
    //        Print("公共方法");
    //    }

    //    public abstract void MethodDiff();
    //}

    abstract class Product//简化后
    {
        public void MethodSame()
        {
            Print("公共方法");
        }

        public abstract void MethodDiff(); 
        public static Product GetProduct(string str)//工厂方法
        {
            Product product = null;
            if (str.Equals("A"))
            {
                product = new ProductA();
            }
            else
            {
                product = new ProductB();
            }

            return product;
        }
    }
    //具体产品A
    class ProductA : Product
    {
        public override void MethodDiff()
        {
            Print("a业务方法");
        }
    }
    //具体产品B
    class ProductB : Product
    {
        public override void MethodDiff()
        {
            Print("b业务方法");
        }
    }
    //工厂类
    //class Factory//简化前
    //{
    //    public static Product GetProduct(string str)
    //    {
    //        Product product = null;
    //        if (str.Equals("A"))
    //        {
    //            product = new ProductA();
    //        }
    //        else
    //        {
    //            product = new ProductB();
    //        }

    //        return product;
    //    }
    //}
}
