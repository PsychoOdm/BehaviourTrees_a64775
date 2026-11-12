using UnityEngine;

public class RobberBehaviour : MonoBehaviour
{
    private BehaviorTreer tree;

    void Start()
    {
        tree = new BehaviorTreer();
        Node steal = new Node("Steal Something");
        Node goToDiamond = new Node("Go to Diamond");
        Node goToVan = new Node("Go To Van");

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();
    }

    void Update()
    {
        
    }
}