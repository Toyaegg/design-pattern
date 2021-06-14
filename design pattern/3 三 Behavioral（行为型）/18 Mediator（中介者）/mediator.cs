using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象中介者
    abstract class AMediator
    {
        public abstract void ComponentChanged(MComponent c);
    }
    //具体中介者
    class ConcreteMediator : AMediator
    {
        public MButton addButton;
        public MList list;
        public MTextBox UserTextBox;
        public MComboBox cb;

        public override void ComponentChanged(MComponent c)
        {
            if (c == addButton)
            {
                Console.WriteLine("--单击添加按钮--");
                list.Update();
                cb.Update();
                UserTextBox.Update();
            }
            else if (c == list)
            {
                Console.WriteLine("--从列表框选择客户--");
                cb.Select();
                UserTextBox.SetText();
            }
            else if (c == cb)
            {
                Console.WriteLine("--从组合框选择客户--");
                cb.Select();
                UserTextBox.SetText();
            }
        }
    }
    //抽象同事类
    abstract class MComponent
    {
        protected AMediator mediator;

        public void SetMediator(AMediator mediator)
        {
            this.mediator = mediator;
        }

        //转发调用
        public void Changed()
        {
            mediator.ComponentChanged(this);
        }

        public abstract void Update();
    }
    //具体同事类
    class MButton : MComponent
    {
        public override void Update()
        {
            
        }
    }
    //具体同事类
    class MList : MComponent
    {
        public override void Update()
        {
            Console.WriteLine("列表框增加一项：AA");
        }

        public void Select()
        {
            Console.WriteLine("列表框增选中项：BB");
        }
    }
    //具体同事类
    class MComboBox : MComponent
    {
        public override void Update()
        {
            Console.WriteLine("组合框增加一项：AA");
        }

        public void Select()
        {
            Console.WriteLine("组合框增选中项：BB");
        }
    }
    //具体同事类
    class MTextBox : MComponent
    {
        public override void Update()
        {
            Console.WriteLine("客户信息增加成功后文本框清空。");
        }

        public void SetText()
        {
            Console.WriteLine("文本框显示：BB");
        }
    }
    //////////////////////////////扩展中介者与同事类/////////////////////////////////
    //新增具体同事类
    class MLabel : MComponent
    {
        public override void Update()
        {
            Console.WriteLine("文本标签内容改变，客户信息数加1。");
        }
    }
    //新增具体中介者类
    class NewMediator : ConcreteMediator
    {
        public MLabel label;
        public override void ComponentChanged(MComponent c)
        {
            if (c == addButton)
            {
                Console.WriteLine("--单击添加按钮--");
                list.Update();
                cb.Update();
                UserTextBox.Update();
                label.Update();
            }
            else if (c == list)
            {
                Console.WriteLine("--从列表框选择客户--");
                cb.Select();
                UserTextBox.SetText();
            }
            else if (c == cb)
            {
                Console.WriteLine("--从组合框选择客户--");
                cb.Select();
                UserTextBox.SetText();
            }
        }
    }
}
