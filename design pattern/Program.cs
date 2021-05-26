using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace design_pattern
{
    class Program
    {
        const string CXJStr = "design pattern";
        const string nameSpaceStr = "design_pattern.";

        static void Main(string[] args)
        {
            //SimpleFactory();//简单工厂
            //FactoryMethod();//工厂方法
            //AbstractFactory();//抽象工厂
            //Builder();//建造者
            //Prototype();//原型
            //Singleton();//单例
            //Adapter();//适配器
            //Bridge();//桥
            //Composite();//组合
            //Decorator();//装饰
            Facade();//外观
            Console.ReadLine();
        }

        static void SimpleFactory()
        {
            Product product;

            //product = Factory.GetProduct("A");//简化前
            product = Product.GetProduct("A");//简化后
            product.MethodSame();
            product.MethodDiff();

            //product = Factory.GetProduct("B");//简化前
            product = Product.GetProduct("B");//简化后
            product.MethodSame();
            product.MethodDiff();
        }

        static void FactoryMethod()
        {
            Factory factory;
            //Product product;

            //factory = new AFactory();
            //product = factory.FactoryMethod();
            //product.MethodSame();
            //product.MethodDiff();

            //factory = new BFactory();
            //product = factory.FactoryMethod();
            //product.MethodSame();
            //product.MethodDiff();

            //在XML文档中记录类名，通过反射的方法生成对象，隐藏工厂方法，引用System.Reflection
            factory = (Factory) Assembly.Load(CXJStr/*程序集名称*/).CreateInstance(nameSpaceStr + "AFactory"/*命名空间.类名*/);
            factory.FactoryMethod();

            factory = (Factory) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "BFactory");
            factory.FactoryMethod();
        }

        static void AbstractFactory()
        {
            AbsFactory factoy;
            AbsProductA pa;
            AbsProductB pb;

            factoy = (AbsFactory) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "AbsAFactory");
            pa = factoy.CProductA();
            pb = factoy.CProductB();
            pa.Show();
            pb.Show();

            factoy = (AbsFactory) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "AbsBFactory");
            pa = factoy.CProductA();
            pb = factoy.CProductB();
            pa.Show();
            pb.Show();
        }

        static void Builder()
        {
            //Builder builder = new TBuilder();
            Builder builder;
            Director director = new Director();
            BuilderProduct builderProduct;

            builder = (Builder) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "HBuilder");
            builderProduct = director.Construct(builder);
            Console.WriteLine(builderProduct.A);
            Console.WriteLine(builderProduct.B);
            Console.WriteLine(builderProduct.C);
            Console.WriteLine(builderProduct.D);

            builder = (Builder)Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "TBuilder");
            builderProduct = director.Construct(builder);
            Console.WriteLine(builderProduct.A);
            Console.WriteLine(builderProduct.B);
            Console.WriteLine(builderProduct.C);
            Console.WriteLine(builderProduct.D);
        }

        static void Prototype()
        {
            //普通克隆
            CPrototypeA prototypeA, copyA;
            prototypeA = new CPrototypeA();
            copyA = (CPrototypeA)prototypeA.Clone();
            Console.WriteLine("----A----");
            Console.WriteLine(prototypeA == copyA);
            Console.WriteLine(prototypeA.Att == copyA.Att);

            //浅克隆(同上)
            CPrototypeB prototypeB, copyB;
            prototypeB = new CPrototypeB();
            copyB = prototypeB.Clone();
            Console.WriteLine("----B----");
            Console.WriteLine(prototypeB == copyB);
            Console.WriteLine(prototypeB.Member == copyB.Member);

            //深克隆
            CPrototypeC prototypeC, copyC;
            prototypeC = new CPrototypeC();
            copyC = (CPrototypeC) prototypeC.Clone();
            Console.WriteLine("----C----");
            Console.WriteLine(prototypeC == copyC);
            Console.WriteLine(prototypeC.Member == copyC.Member);
        }

        static void Singleton()
        {
            Single s = Single.GetInstance();
            Single sc = Single.GetInstance();
            if (s == sc)
            {
                Console.WriteLine("s == sc");
            }
            ESingle es = ESingle.GetInstance();
            ESingle esc = ESingle.GetInstance();
            if (es == esc)
            {
                Console.WriteLine("es == esc");
            }
            LLSingle lls = LLSingle.GetInstance();
            LLSingle llsc = LLSingle.GetInstance();
            if (lls == llsc)
            {
                Console.WriteLine("lls == llsc");
            }
        }

        static void Adapter()
        {
            AdapterMe adapterMe;
            adapterMe = (AdapterMe) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "AdapterMe");
            adapterMe.add();
            adapterMe.pp();

            ConcreAbsAdapterA absAdapterA;
            absAdapterA = (ConcreAbsAdapterA) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "ConcreAbsAdapterA");
            absAdapterA.AbsA();
            absAdapterA.AbsB();
            ConcreAbsAdapterB absAdapterB;
            absAdapterB = (ConcreAbsAdapterB) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "ConcreAbsAdapterB");
            absAdapterB.AbsA();
            absAdapterB.AbsB();
        }

        static void Bridge()
        {
            Image image;
            ImageImp imp;

            image = (Image) Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "GIF");
            imp = (ImageImp)Assembly.Load(CXJStr).CreateInstance(nameSpaceStr + "WinImp");

            image.SetImageImp(imp);
            image.ParseFile("ddddd");
        }

        static void Composite()
        {
            AbsFile f1, f2, f3, f4, fd5, fd6, fd7;

            f1 = new TextFile("11.txt");
            f2 = new ImageFile("22.jpg");
            f3 = new VideoFile("33.avi");
            f4 = new AudioFile("44.mp3");
            fd5 = new Folder("aa");
            fd6 = new Folder("bb");
            fd7 = new Folder("cc");

            fd7.Add(fd6);
            fd7.Add(f2);
            fd7.Add(fd5);
            fd6.Add(f4);
            fd5.Add(f1);
            fd5.Add(f3);

            fd7.KillVirus();
        }

        static void Decorator()
        {
            VisualComponent component, componentSB, componentBB;

            component = new Window();
            componentSB = new ScrollBarDecorator(component);
            componentBB = new BlackBoderDecorator(componentSB);

            componentBB.Display();
        }

        static void Facade()
        {
            
        }
    }
}
