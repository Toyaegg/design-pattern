using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace design_pattern
{
    //抽象表达式
    abstract class AbsNode
    {
        public abstract string Intepret();
    }
    //非终结符表达式
    class AndNode : AbsNode
    {
        private AbsNode left;
        private AbsNode right;

        public AndNode(AbsNode left, AbsNode right)
        {
            this.left = left;
            this.right = right;
        }

        public override string Intepret()
        {
            return left.Intepret() + "再" + right.Intepret();
        }
    }

    class SentenceNode : AbsNode
    {
        private AbsNode direction;
        private AbsNode action;
        private AbsNode distance;

        public SentenceNode(AbsNode direction, AbsNode action, AbsNode distance)
        {
            this.direction = direction;
            this.action = action;
            this.distance = distance;
        }

        public override string Intepret()
        {
            return direction.Intepret() + action.Intepret() + distance.Intepret();
        }
    }

    class DirectionNode : AbsNode
    {
        private string direction;

        public DirectionNode(string direction)
        {
            this.direction = direction;
        }

        //终结符表达式
        public override string Intepret()
        {
            switch (direction)
            {
                case "up":
                {
                    return "向上";
                }
                case "down":
                {
                    return "向下";
                }
                case "left":
                {
                    return "向左";
                }
                case "right":
                {
                    return "向右";
                }
                default:
                {
                    return "无效指令";
                }
            }
        }
    }

    class ActionNode : AbsNode
    {
        private string action;

        public ActionNode(string action)
        {
            this.action = action;
        }

        public override string Intepret()
        {
            switch (action)
            {
                case "move":
                {
                    return "移动";
                }
                case "run":
                {
                    return "快速移动";
                }
                default:
                {
                    return "无效指令";
                }
            }
        }
    }

    class DistanceNode : AbsNode
    {
        private string distance;

        public DistanceNode(string distance)
        {
            this.distance = distance;
        }

        public override string Intepret()
        {
            return this.distance;
        }
    }

    //指令处理
    class InterpreterHandler
    {
        private AbsNode node;

        public void Handle(string instruction)
        {
            AbsNode left = null, right = null;
            AbsNode direction = null, action = null, distance = null;

            Stack stack = new Stack();

            string[] words = instruction.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Equals("and"))
                {
                    left = (AbsNode) stack.Pop();
                    string word1 = words[++i];
                    direction = new DirectionNode(word1);
                    string word2 = words[++i];
                    action = new ActionNode(word2);
                    string word3 = words[++i];
                    distance = new DistanceNode(word3);

                    right = new SentenceNode(direction,action,distance);
                    stack.Push(new AndNode(left,right));
                }
                else
                {
                    string word1 = words[i];
                    direction = new DirectionNode(word1);
                    string word2 = words[++i];
                    action = new ActionNode(word2);
                    string word3 = words[++i];
                    distance = new DistanceNode(word3);

                    left = new SentenceNode(direction,action,distance);
                    stack.Push(left);
                }
            }

            this.node = (AbsNode) stack.Pop();
        }

        public string Output()
        {
            return node.Intepret();
        }
    }
}
