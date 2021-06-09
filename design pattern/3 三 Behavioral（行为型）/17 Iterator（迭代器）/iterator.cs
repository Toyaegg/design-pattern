using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    interface IAbsIterator
    {
        void Next();
        bool IsLast();
        void Previous();
        bool IsFirst();
        object GetNextItem();
        object GetPreviousItem();
    }
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
            if (cursor1 == producks.Count)
            {
                cursor1 = 0;
            }
        }

        public bool IsLast()
        {
            return (cursor1 == producks.Count);
        }

        public void Previous()
        {
            Console.WriteLine(cursor2);
            if (cursor2 > -1)
            {
                cursor2--;
            }
            if (cursor2 == -1)
            {
                cursor2 = producks.Count - 1;
            }
        }

        public bool IsFirst()
        {
            return (cursor2 == -1);
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
}
