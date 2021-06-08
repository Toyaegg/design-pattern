using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //子系统角色
    class SysA
    {
        public void SysMA()
        {
            Console.WriteLine("SysMA");
        }
    }
    //子系统角色
    class SysB
    {
        public void SysMB()
        {
            Console.WriteLine("SysMB");
        }
    }
    //子系统角色
    class SysC
    {
        public void SysMC()
        {
            Console.WriteLine("SysMC");
        }
    }
    //外观角色
    class FacadeIn
    {
        private SysA sysA = new SysA();
        private SysB sysB = new SysB();
        private SysC sysC = new SysC();

        public void FacadeMethod()
        {
            sysA.SysMA();
            sysB.SysMB();
            sysC.SysMC();
        }
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    //具体外观角色A
    class FacadeA : AbsFacade
    {
        private SysA sysA = new SysA();
        private SysB sysB = new SysB();
        private SysC sysC = new SysC();

        public override void FacadeMethod()
        {
            sysA.SysMA();
            sysB.SysMB();
            sysC.SysMC();
        }
    }
    //具体外观角色B
    class FacadeB : AbsFacade
    {
        private SysA sysA = new SysA();
        private SysB sysB = new SysB();
        private SysC sysC = new SysC();

        public override void FacadeMethod()
        {
            sysC.SysMC();
            sysB.SysMB();
            sysA.SysMA();
        }
    }
    //抽象外观类
    abstract class AbsFacade
    {
        public abstract void FacadeMethod();
    }
}
