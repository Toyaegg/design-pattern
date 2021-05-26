using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象构件
    abstract class VisualComponent
    {
        public abstract void Display();
    }
    //具体构件
    class Window : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("显示窗体！");
        }
    }
    //具体构件
    class TextBox : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("显示文本框！");
        }
    }
    //具体构件
    class ListBox : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("显示列表框！");
        }
    }
    //抽象装饰类
    class ComponentDecorator : VisualComponent
    {
        private VisualComponent component;

        public ComponentDecorator(VisualComponent component)
        {
            this.component = component;
        }

        public override void Display()
        {
            component.Display();
        }
    }
    //具体装饰类
    class ScrollBarDecorator : ComponentDecorator
    {
        public ScrollBarDecorator(VisualComponent component) : base(component)
        {

        }

        public override void Display()
        {
            this.SetScrollBar();
            base.Display();
        }

        void SetScrollBar()
        {
            Console.WriteLine("增加滚动条！");
        }
    }
    //具体装饰类
    class BlackBoderDecorator : ComponentDecorator
    {
        public BlackBoderDecorator(VisualComponent component) : base(component)
        {

        }

        public override void Display()
        {
            this.SetScrollBar();
            base.Display();
        }

        void SetScrollBar()
        {
            Console.WriteLine("增加黑边框！");
        }
    }
}
