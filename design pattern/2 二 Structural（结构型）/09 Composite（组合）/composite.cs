using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象构件
    abstract class AbsFile
    {
        public abstract void Add(AbsFile absFile);
        public abstract void Remove(AbsFile absFile);
        public abstract AbsFile GetAbsFile(int index);
        public abstract void KillVirus();
    }
    //叶子构件
    class TextFile : AbsFile
    {
        private string name;

        public TextFile(string name)
        {
            this.name = name;
        }
        public override void Add(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override void Remove(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override AbsFile GetAbsFile(int index)
        {
            Console.WriteLine("no!");
            return null;
        }

        public override void KillVirus()
        {
            Console.WriteLine("Kill {0}' virus",name);
        }
    }
    //叶子构件
    class ImageFile : AbsFile
    {
        private string name;

        public ImageFile(string name)
        {
            this.name = name;
        }
        public override void Add(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override void Remove(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override AbsFile GetAbsFile(int index)
        {
            Console.WriteLine("no!");
            return null;
        }

        public override void KillVirus()
        {
            Console.WriteLine("Kill {0}' virus", name);
        }
    }
    //叶子构件
    class VideoFile : AbsFile
    {
        private string name;

        public VideoFile(string name)
        {
            this.name = name;
        }
        public override void Add(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override void Remove(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override AbsFile GetAbsFile(int index)
        {
            Console.WriteLine("no!");
            return null;
        }

        public override void KillVirus()
        {
            Console.WriteLine("Kill {0}' virus", name);
        }
    }
    //叶子构件
    class AudioFile : AbsFile
    {
        private string name;

        public AudioFile(string name)
        {
            this.name = name;
        }
        public override void Add(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override void Remove(AbsFile absFile)
        {
            Console.WriteLine("no!");
        }

        public override AbsFile GetAbsFile(int index)
        {
            Console.WriteLine("no!");
            return null;
        }

        public override void KillVirus()
        {
            Console.WriteLine("Kill {0}' virus", name);
        }
    }
    //容器构件
    class Folder : AbsFile
    {
        private List<AbsFile> filelist = new List<AbsFile>();
        private string name;

        public Folder(string name)
        {
            this.name = name;
        }
        public override void Add(AbsFile absFile)
        {
            filelist.Add(absFile);
        }

        public override void Remove(AbsFile absFile)
        {
            filelist.Remove(absFile);
        }

        public override AbsFile GetAbsFile(int index)
        {
            return (AbsFile) filelist[index];
        }

        public override void KillVirus()
        {
            Console.WriteLine("Kill {0}' virus", name);
            foreach (Object obj in filelist)
            {
                ((AbsFile)obj).KillVirus();
            }
        }
    }
}
