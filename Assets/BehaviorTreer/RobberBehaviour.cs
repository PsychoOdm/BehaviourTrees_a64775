using UnityEngine;

public class RobberBehaviour : MonoBehaviour
{
    BehaviorTreer tree;
    public GameObject diamond;
    public GameObject van;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();

        tree = new BehaviorTreer();
        Node steal = new Node("Steal Something");
        Leaf goToDiamond = new Leaf("Go to Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();

        tree.Process();
    }

    public Node.Status GoToDiamond()
    {
        agent.SetDestination(diamond.transform.position);
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToVan()
    {
        agent.SetDestination(van.transform.position);
        return Node.Status.SUCCESS;
    }

    void Update()
    {
        
    }
}