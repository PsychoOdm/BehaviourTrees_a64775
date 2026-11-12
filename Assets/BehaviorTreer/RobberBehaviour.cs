using UnityEngine;

public class RobberBehaviour : MonoBehaviour
{
    
    private BehaviorTreer tree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tree = new BehaviorTreer();
        Node steal = new Node("Steal Something");
        Node goToDiamond = new Node("Go to Diamond");
        Node goToVan = new Node("Go To Van");

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}