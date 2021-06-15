using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //环境类
    class Account
    {
        private AccountState state;
        private string owner;
        private double balance = 0;

        public Account(string owner, double init)
        {
            this.owner = owner;
            balance = init;
            state = new NormalState(this);
            Console.WriteLine("{0}开户，初始金额为{1}", this.owner, init);
            Console.WriteLine("---------------------------------");
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public void SetState(AccountState state)
        {
            this.state = state;
        }

        public void Deposit(double amount)
        {
            Console.WriteLine("{0}存款{1}", owner, amount);
            state.Deposit(amount);
            Console.WriteLine("现在账户余额{0}", Balance);
            Console.WriteLine("现在账户状态{0}", state.GetType());
            Console.WriteLine("---------------------------------");
        }

        public void Withdraw(double amount)
        {
            Console.WriteLine("{0}取款{1}", owner, amount);
            state.Withdraw(amount);
            Console.WriteLine("现在账户余额{0}", Balance);
            Console.WriteLine("现在账户状态{0}", state.GetType());
            Console.WriteLine("---------------------------------");
        }

        public void ComputeInterest()
        {
            state.ComputeInterest();
        }
    }
    //抽象状态类
    abstract class AccountState
    {
        private Account acc;

        public Account Acc
        {
            get
            {
                return acc;
            }
            set
            {
                acc = value;
            }
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void ComputeInterest();
        public abstract void StateCheck();
    }
    //具体状态类
    class NormalState : AccountState
    {
        public NormalState(Account acc)
        {
            Acc = acc;
        }
        public NormalState(AccountState state)
        {
            Acc = state.Acc;
        }
        public override void Deposit(double amount)
        {
            Acc.Balance += amount;
            StateCheck();
        }

        public override void Withdraw(double amount)
        {
            Acc.Balance -= amount;
            StateCheck();
        }

        public override void ComputeInterest()
        {
            Console.WriteLine("正常状态，无须支付利息。");
        }

        public override void StateCheck()
        {
            if (Acc.Balance > -2000 && Acc.Balance <= 0)
            {
                Acc.SetState(new OverdraftState(this));
            }
            else if(Acc.Balance == -2000)
            {
                Acc.SetState(new RestrictedState(this));
            }
            else if(Acc.Balance < -2000)
            {
                Console.WriteLine("操作受限！");
            }
        }
    }
    class OverdraftState : AccountState
    {
        public OverdraftState(AccountState state)
        {
            Acc = state.Acc;
        }
        public override void Deposit(double amount)
        {
            Acc.Balance += amount;
            StateCheck();
        }

        public override void Withdraw(double amount)
        {
            Acc.Balance -= amount;
            StateCheck();
        }

        public override void ComputeInterest()
        {
            Console.WriteLine("计算利息！");
        }

        public override void StateCheck()
        {
            if (Acc.Balance > 0)
            {
                Acc.SetState(new NormalState(this));
            }
            else if (Acc.Balance == -2000)
            {
                Acc.SetState(new RestrictedState(this));
            }
            else if (Acc.Balance < -2000)
            {
                Console.WriteLine("操作受限！");
            }
        }
    }
    class RestrictedState : AccountState
    {
        public RestrictedState(AccountState state)
        {
            Acc = state.Acc;
        }
        public override void Deposit(double amount)
        {
            Acc.Balance += amount;
            StateCheck();
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("账户受限，取款失败！");
        }

        public override void ComputeInterest()
        {
            Console.WriteLine("计算利息！");
        }

        public override void StateCheck()
        {
            
            if (Acc.Balance > 0)
            {
                Acc.SetState(new RestrictedState(this));
            }
            else if (Acc.Balance > -2000)
            {
                Acc.SetState(new OverdraftState(this));
            }
        }
    }

    //////////////////////////////////////////////共享状态////////////////////////////////////////////////

    class Switch
    {
        private static SwitchState currentState, onState, offState;

        private string name;

        public Switch(string name)
        {
            this.name = name;
            onState = new OnState();
            offState = new Offtate();
            currentState = onState;
        }

        public void SetState(SwitchState state)
        {
            currentState = state;
        }

        public static SwitchState GetState(string type)
        {
            if (type.Equals("on"))
            {
                return onState;
            }
            else
            {
                return offState;
            }
        }

        public void On()
        {
            Console.Write(name);
            currentState.On(this);
        }

        public void Off()
        {
            Console.Write(name);
            currentState.Off(this);
        }
    }

    abstract class SwitchState
    {
        public abstract void On(Switch s);
        public abstract void Off(Switch s);
    }

    class OnState : SwitchState
    {
        public override void On(Switch s)
        {
            Console.WriteLine("已经打开！");
        }

        public override void Off(Switch s)
        {
            Console.WriteLine("关闭！");
            s.SetState(Switch.GetState("off"));
        }
    }

    class Offtate : SwitchState
    {
        public override void On(Switch s)
        {
            Console.WriteLine("打开！");
            s.SetState(Switch.GetState("on"));
        }

        public override void Off(Switch s)
        {
            Console.WriteLine("已经关闭！");
        }
    }

    //////////////////////////////////////////////使用环境类实现状态转换////////////////////////////////////////////////

    class Screen
    {
        private ScreenState currentState, normalState, largerState, largestState;

        public Screen()
        {
            normalState = new SNormalState();
            largerState = new SLargerState();
            largestState = new SLargestState();
            currentState = normalState;
            currentState.Display();
        }

        public void SetState(ScreenState state)
        {
            currentState = state;
        }

        public void Onclick()
        {
            if (currentState == normalState)
            {
                SetState(largerState);
                currentState.Display();
            }
            else if(currentState == largerState)
            {
                SetState(largestState);
                currentState.Display();
            }
            else if (currentState == largestState)
            {
                SetState(normalState);
                currentState.Display();
            }
        }
    }

    abstract class ScreenState
    {
        public abstract void Display();
    }

    class SNormalState : ScreenState
    {
        public override void Display()
        {
            Console.WriteLine("正常大小！");
        }
    }

    class SLargerState : ScreenState
    {
        public override void Display()
        {
            Console.WriteLine("二倍大小！");
        }
    }

    class SLargestState : ScreenState
    {
        public override void Display()
        {
            Console.WriteLine("四倍大小！");
        }
    }
}
