using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BehaviorTreer : Node
{
    public struct NodeLevel
    {
        public int level;
        public Node node;
    }

    public BehaviorTreer()
    {
        name = "Tree";
    }

    public BehaviorTreer(string n)
    {
        name = n;
    }


    public override Status Process()
    {
        return children[currentChild].Process();
    }

    public void PrintTree()
    {
        string treePrintout = "";
        Stack<NodeLevel> nodeSrack = new Stack<NodeLevel>();
        Node currentNode = this;
        nodeSrack.Push(new NodeLevel { level = 0, node = currentNode });

        while (nodeSrack.Count != 0)
        {
            NodeLevel nextNode = nodeSrack.Pop();
            treePrintout += new string('-', nextNode.level) + nextNode.node.name + "\n";
            for (int i = nextNode.node.children.Count - 1; i >= 0; i--)
            {
                nodeSrack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.children[i] });
            }
        }
        Debug.Log(treePrintout);
    }
}