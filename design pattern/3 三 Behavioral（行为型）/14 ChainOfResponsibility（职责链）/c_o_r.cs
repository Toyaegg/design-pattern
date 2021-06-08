using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //订单类
    class PurchaseRequest
    {
        private double amount;
        private int number;
        private string purpose;

        public PurchaseRequest(double amount, int number, string purpose)
        {
            this.amount = amount;
            this.number = number;
            this.purpose = purpose;
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string Purpose
        {
            get
            {
                return purpose;
            }
            set
            {
                purpose = value;
            }
        }
    }
    //抽象处理者
    abstract class Approver
    {
        protected Approver successor;
        protected string name;

        public Approver(string name)
        {
            this.name = name;
        }

        public void SetSuccessor(Approver successer)
        {
            this.successor = successer;
        }

        public abstract void ProcessRequest(PurchaseRequest request);
    }
    //具体处理者
    class AA : Approver
    {
        public AA(string name) : base(name)
        {

        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 50000)
            {
                Console.WriteLine("AA{0} number {1} amount {2} purpose {3}",this.name,request.Number,request.Amount,request.Purpose);
            }
            else
            {
                this.successor.ProcessRequest(request);
            }
        }
    }
    //具体处理者
    class BB : Approver
    {
        public BB(string name) : base(name)
        {

        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000)
            {
                Console.WriteLine("BB{0} number {1} amount {2} purpose {3}", this.name, request.Number, request.Amount, request.Purpose);
            }
            else
            {
                this.successor.ProcessRequest(request);
            }
        }
    }
    //具体处理者
    class CC : Approver
    {
        public CC(string name) : base(name)
        {

        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 500000)
            {
                Console.WriteLine("CC{0} number {1} amount {2} purpose {3}", this.name, request.Number, request.Amount, request.Purpose);
            }
            else
            {
                this.successor.ProcessRequest(request);
            }
        }
    }
    //具体处理者
    class EE : Approver
    {
        public EE(string name) : base(name)
        {

        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 70000)
            {
                Console.WriteLine("EE{0} number {1} amount {2} purpose {3}", this.name, request.Number, request.Amount, request.Purpose);
            }
            else
            {
                this.successor.ProcessRequest(request);
            }
        }
    }
    //具体处理者
    class DD : Approver
    {
        public DD(string name) : base(name)
        {

        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            Console.WriteLine("DD{0} number {1} amount {2} purpose {3}", this.name, request.Number, request.Amount, request.Purpose);
        }
    }
}
