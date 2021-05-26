using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern.CommonUtils
{
    class binary
    {
        public static void gg()
        {
            FileStream fs = new FileStream("ppt.dat", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            MyClass mc = new MyClass();
            bw.Write(mc.s);
            bw.Write(mc.s1);
            bw.Write(mc.s2);
            bw.Write(mc.s3);
            bw.Write(mc.s4);
            bw.Flush();
            bw.Close();
            fs.Close();
        }
        public static void hh()
        {
            FileStream fs = new FileStream("ppt.dat", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            MyClass mc = new MyClass();
            mc.s = br.ReadInt32();
            mc.s1 = br.ReadString();
            mc.s2 = br.ReadBoolean();
            mc.s3 = br.ReadInt64();
            mc.s4 = br.ReadChar();
            Console.WriteLine(mc.s);
            Console.WriteLine(mc.s1);
            Console.WriteLine(mc.s2);
            Console.WriteLine(mc.s3);
            Console.WriteLine(mc.s4);
            br.Close();
            fs.Close();
        }
    }

    class MyClass
    {
        public int s = 36621;
        public string s1 = "slahspdjaiojdpaojhphsdjilkaudp[aj;sdjfoishd";
        public bool s2 = true;
        public long s3 = 19651321911;
        public char s4 = 'd';
    }
}
