using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    public class Chessman
    {
        private string label;
        private int x;
        private int y;

        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Chessman(string label, int x, int y)
        {
            this.label = label;
            this.x = x;
            this.y = y;
        }

        internal ChessmanMemento Save()
        {
            return new ChessmanMemento(Label, X, Y);
        }

        internal void Restore(ChessmanMemento memento)
        {
            Label = memento.Label;
            X = memento.X;
            Y = memento.Y;
        }
    }

    internal class ChessmanMemento
    {
        private string label;
        private int x;
        private int y;

        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public ChessmanMemento(string label, int x, int y)
        {
            this.label = label;
            this.x = x;
            this.y = y;
        }
    }

    //public class MementoCaretaker
    //{
    //    private ChessmanMemento memento;

    //    internal ChessmanMemento GetMemento()
    //    {
    //        return memento;
    //    }

    //    internal void SetMemento(ChessmanMemento memento)
    //    {
    //        this.memento = memento;
    //    }
    //}

    //多次撤销
    public class MementoCaretaker
    {
        private ArrayList mementos = new ArrayList();

        internal ChessmanMemento GetMemento(int i)
        {
            return (ChessmanMemento)mementos[i];
        }

        internal void SetMemento(ChessmanMemento memento)
        {
            mementos.Add(memento);
        }
    }

    public class ChessPlay
    {
        public static void ChessDisplay(Chessman chess)
        {
            Console.WriteLine("棋子{0}的当前位置为：第{1}行第{2}列。", chess.Label,chess.X,chess.Y);
        }
    }
}
