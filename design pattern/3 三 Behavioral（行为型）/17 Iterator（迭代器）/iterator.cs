using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象迭代器
    interface IAbsIterator
    {
        void Next();
        bool IsLast();
        void Previous();
        bool IsFirst();
        object GetNextItem();
        object GetPreviousItem();
    }
    //抽象聚合类
    abstract class AbsObjList
    {
        protected List<object> objects = new List<object>();

        public AbsObjList(List<object> objects)
        {
            this.objects = objects;
        }

        public void AddObj(object obj)
        {
            this.objects.Add(obj);
        }

        public void Remove(object obj)
        {
            this.objects.Remove(obj);
        }

        public List<object> GetObjects()
        {
            return objects;
        }

        public abstract IAbsIterator CreateIterator();
    }
    //具体聚合类
    class ProductList : AbsObjList
    {
        public ProductList(List<object> producks) : base(producks)
        {
        }

        public override IAbsIterator CreateIterator()
        {
            return new ProductIterator(this);
        }
    }
    //具体迭代器
    class ProductIterator : IAbsIterator
    {
        private ProductList productList;
        private List<object> producks;
        private int cursor1;
        private int cursor2;

        public ProductIterator(ProductList list)
        {
            this.productList = list;
            this.producks = list.GetObjects();
            Reset();
        }

        void Reset()
        {
            cursor1 = 0;
            cursor2 = producks.Count - 1;
        }

        public void Next()
        {
            Console.WriteLine(cursor1);
            if (cursor1 < producks.Count)
            {
                cursor1++;
            }
        }

        public bool IsLast()
        {
            if(cursor1 == producks.Count)
            {
                Reset();
                return true;
            }

            return false;
        }

        public void Previous()
        {
            Console.WriteLine(cursor2);
            if (cursor2 > -1)
            {
                cursor2--;
            }
        }

        public bool IsFirst()
        {
            if(cursor2 == -1)
            {
                Reset();
                return true;
            }

            return false;
        }

        public object GetNextItem()
        {
            return producks[cursor1];
        }

        public object GetPreviousItem()
        {
            return producks[cursor2];
        }
    }

    /// 内部类实现迭代器 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    //抽象聚合类
    abstract class AbsObjListNew
    {
        protected static List<object> objects = new List<object>();

        public AbsObjListNew(List<object> Nobjects)
        {
            objects = Nobjects;
        }

        public void AddObj(object obj)
        {
            objects.Add(obj);
        }

        public void Remove(object obj)
        {
            objects.Remove(obj);
        }

        public List<object> GetObjects()
        {
            return objects;
        }

        public abstract IAbsIterator CreateIterator();
    }

    //具体聚合类
    class ProductListNew : AbsObjListNew
    {
        public ProductListNew(List<object> objects) : base(objects)
        {
        }

        public override IAbsIterator CreateIterator()
        {
            return new ProductIteratorNew();
        }
        
        //具体迭代器，内部类实现
        class ProductIteratorNew : IAbsIterator
        {
            private int cursor1;
            private int cursor2;

            public ProductIteratorNew()
            {
                Reset();
            }

            void Reset()
            {
                cursor1 = 0;
                cursor2 = objects.Count - 1;
            }

            public void Next()
            {
                Console.WriteLine(cursor1);
                if (cursor1 < objects.Count)
                {
                    cursor1++;
                }
            }

            public bool IsLast()
            {
                if (cursor1 == objects.Count)
                {
                    Reset();
                    return true;
                }

                return false;
            }

            public void Previous()
            {
                Console.WriteLine(cursor2);
                if (cursor2 > -1)
                {
                    cursor2--;
                }
            }

            public bool IsFirst()
            {
                if (cursor2 == -1)
                {
                    Reset();
                    return true;
                }

                return false;
            }

            public object GetNextItem()
            {
                return objects[cursor1];
            }

            public object GetPreviousItem()
            {
                return objects[cursor2];
            }
        }
    }

    /// .NET内置迭代器 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //public interface IEnumerable
    //{
    //    IEnumerator GetEnumerator();//工厂方法，获取迭代器
    //}

    //public interface Ienumerator
    //{
    //    object Current
    //    {
    //        get;
    //    }//返回当前集合中的元素
    //    bool MoveNext();//遍历集合，移至下一个元素
    //    void Reset();//恢复初始位置
    //}

    //通过扩展这两个接口，可以定义自己的聚合类和迭代器类
    //实现了IEnumerable的子类都可以对应定义一个迭代器，用于对其中的元素进行遍历

    class EnumTest
    {
        public static void Process(IEnumerable e)
        {
            IEnumerator i = e.GetEnumerator();

            while (i.MoveNext())
            {
                Console.WriteLine(i.Current.ToString());
            }
        }
    }
}
