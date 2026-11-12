using UnityEngine;

public class RobberBehaviour : MonoBehaviour
{
    BehaviorTreer tree;
    public GameObject diamond;
    public GameObject van;
    UnityEngine.AI.NavMeshAgent agent;

    public enum ActionState { IDLE, WORKING};
    ActionState state = ActionState.IDLE;
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
        return GoToLocation(diamond.transform.position);
    }

    public Node.Status GoToVan()
    {
        return GoToLocation(van.transform.position);
    }


    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) >=2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }

        else if (distanceToTarget < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }

        return Node.Status.RUNNING;
    }
    void Update()
    {
        
    }
}