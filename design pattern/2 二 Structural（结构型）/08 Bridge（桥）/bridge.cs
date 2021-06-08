using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //辅助类
    class Matrix
    {
        
    }
    //实现类接口
    interface ImageImp
    {
        void DoPaint();
    }
    //具体实现类
    class WinImp : ImageImp
    {
        public void DoPaint()
        {
            Console.Write("WinImp : ");
        }
    }
    //具体实现类
    class LinImp : ImageImp
    {
        public void DoPaint()
        {
            Console.Write("LinImp : ");
        }
    }
    //具体实现类
    class UniImp : ImageImp
    {
        public void DoPaint()
        {
            Console.Write("UniImp : ");
        }
    }
    //抽象类
    abstract class Image
    {
        protected ImageImp imp;

        public void SetImageImp(ImageImp imp)
        {
            this.imp = imp;
        }

        public abstract void ParseFile(string fileName);
    }
    //扩充抽象类
    class PNG : Image
    {
        public override void ParseFile(string fileName)
        {
            Matrix m = new Matrix();
            imp.DoPaint();
            Console.WriteLine("{0}, PNG",fileName);
        }
    }
    //扩充抽象类
    class JPG : Image
    {
        public override void ParseFile(string fileName)
        {
            Matrix m = new Matrix();
            imp.DoPaint();
            Console.WriteLine("{0}, JPG", fileName);
        }
    }
    //扩充抽象类
    class GIF : Image
    {
        public override void ParseFile(string fileName)
        {
            Matrix m = new Matrix();
            imp.DoPaint();
            Console.WriteLine("{0}, GIF", fileName);
        }
    }
}
