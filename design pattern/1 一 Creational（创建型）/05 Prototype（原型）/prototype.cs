using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    class CPrototypeA : Prototype
    {
        private string att;
        public string Att
        {
            get { return att; }
            set { att = value; }
        }

        public override Prototype Clone()
        {
            CPrototypeA cPrototype = new CPrototypeA();
            cPrototype.Att = att;
            return cPrototype;
        }
    }

    class Member
    {
        
    }

    class CPrototypeB
    {
        private Member member;

        public Member Member
        {
            get { return member; }
            set { member = value; }
        }

        public CPrototypeB Clone()
        {
            return (CPrototypeB) this.MemberwiseClone();
        }
    }

    class CPrototypeC : ICloneable
    {
        private Member member;

        public Member Member
        {
            get { return member; }
            set { member = value; }
        }
        public object Clone()
        {
            CPrototypeC copy = (CPrototypeC) this.MemberwiseClone();
            Member newMember = new Member();
            copy.Member = newMember;
            return copy;
        }

    }
}
