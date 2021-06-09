using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace design_pattern
{
    //抽象命令类
    abstract class Command
    {
        public abstract void Execute();
    }
    //具体命令类
    class EComman : Command
    {
        private SystemExitClass seObj;

        public EComman()
        {
            seObj = new SystemExitClass();
        }
        public override void Execute()
        {
            seObj.Exit();
        }
    }
    class HComman : Command
    {
        private SystemHelpClass hcObj;

        public HComman()
        {
            hcObj = new SystemHelpClass();
        }
        public override void Execute()
        {
            hcObj.Help();
        }
    }

    //调用者
    class FunButton
    {
        private Command command;

        public Command Command
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
            }
        }

        public void Click()
        {
            Console.WriteLine("Click Button");
            command.Execute();
        }
    }
    //接收者
     class SystemExitClass
    {
        public void Exit()
        {
            Console.WriteLine("Exit");
        }
    }
     class SystemHelpClass
     {
         public void Help()
         {
             Console.WriteLine("Help");
         }
     }
}
