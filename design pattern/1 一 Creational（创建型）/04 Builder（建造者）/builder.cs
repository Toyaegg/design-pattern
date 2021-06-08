using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    class BuilderProduct
    {
        private string a;
        private string b;
        private string c;
        private string d;

        public string A { get { return a; } set { a = value; } }
        public string B { get { return b; } set { b = value; } }
        public string C { get { return c; } set { c = value; } }
        public string D { get { return d; } set { d = value; } }
    }

    abstract class Builder
    {
        protected BuilderProduct builderProduct = new BuilderProduct();

        public abstract void BuildA();
        public abstract void BuildB();
        public abstract void BuildC();
        public abstract void BuildD();

        public BuilderProduct GetProduct()
        {
            return builderProduct;
        }
    }

    class TBuilder : Builder
    {
        public override void BuildA()
        {
            builderProduct.A = "TA";
        }
        public override void BuildB()
        {
            builderProduct.B = "TB";
        }
        public override void BuildC()
        {
            builderProduct.C = "TC";
        }
        public override void BuildD()
        {
            builderProduct.D = "TD";
        }
    }

    class HBuilder : Builder
    {
        public override void BuildA()
        {
            builderProduct.A = "HA";
        }
        public override void BuildB()
        {
            builderProduct.B = "HB";
        }
        public override void BuildC()
        {
            builderProduct.C = "HC";
        }
        public override void BuildD()
        {
            builderProduct.D = "HD";
        }
    }

    class Director
    {
        //private Builder builder;

        //public Director(Builder builder)
        //{
        //    this.builder = builder;
        //}

        //public void SetBuilder(Builder builder)
        //{
        //    this.builder = builder;
        //}

        public BuilderProduct Construct(Builder builder)
        {
            builder.BuildA();
            builder.BuildB();
            builder.BuildC();
            builder.BuildD();
            return builder.GetProduct();
        }
    }
}
