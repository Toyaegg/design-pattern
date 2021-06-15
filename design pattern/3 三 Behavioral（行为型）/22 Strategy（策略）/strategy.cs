using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //环境类
    class MovieTicket
    {
        private double price;
        private Discount discount;

        public void SetDiscount(Discount discount)
        {
            this.discount = discount;
        }

        public double Price
        {
            get
            {
                return discount.Calculate(price);
            }
            set
            {
                price = value;
            }
        }
    }
    //抽象策略类
    interface  Discount
    {
        double Calculate(double price);
    }
    //具体策略类
    class StudentDiscount : Discount
    {
        private const double DISCOUNT = 0.8;
        public double Calculate(double price)
        {
            Console.Write("学生票：");
            return price * DISCOUNT;
        }
    }
    //具体策略类
    class ChildrenDiscount : Discount
    {
        private const double DISCOUNT = 10;
        public double Calculate(double price)
        {
            Console.Write("儿童票：");
            return price - DISCOUNT;
        }
    }
    //具体策略类
    class VIPDiscount : Discount
    {
        private const double DISCOUNT = 0.5;
        public double Calculate(double price)
        {
            Console.Write("VIP票：");
            Console.Write("增加积分！");
            return price * DISCOUNT;
        }
    }
}
